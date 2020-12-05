import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { VideoGameModel } from 'src/app/models/videogame.model';
import { Subscription } from 'rxjs';
import { VideogameService } from '../../services/videogame.service';
import { SystemModel } from '../../models/system.model';
import Swal from 'sweetalert2';
import { SupportModel } from '../../models/support.model';
import { ChangeDetectorRef } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'app-videogame',
  templateUrl: './videogame.component.html',
  styleUrls: ['./videogame.component.css']
})
export class VideogameComponent implements OnInit, OnDestroy {
 
 public forma: FormGroup;
 public game: VideoGameModel = new VideoGameModel();
 private subscription: Subscription = new Subscription();
 private subscriptionEdit: Subscription = new Subscription();
 public systems: SystemModel[] = new Array<SystemModel>();
 public supports: SupportModel[] = new Array<SupportModel>();
 public dataGame: VideoGameModel = new VideoGameModel();

 public idVideogame;
 constructor(private fb: FormBuilder,
             private videogameService: VideogameService,
             private cd: ChangeDetectorRef,
             private router: Router,
             private actRoute: ActivatedRoute) { 
     this.createForm();
     this.idVideogame = this.actRoute.snapshot.params.id;
  }

   ngOnInit(): void {
    this.loadSystems();
    this.loadSupports();
    if (this.idVideogame !== 'new'){
      this.getDataVideoGame();
    }
   }
  
  ngOnDestroy(): void {
    this.subscription.unsubscribe();
    this.subscriptionEdit.unsubscribe();
  }

  createForm(): void{
    this.forma = this.fb.group({
      title: ['',[Validators.required, Validators.minLength(3)]],
      // tslint:disable-next-line:no-trailing-whitespace
      developer: [''], 
      barCode: [''],
      redump: [''],
      genre: [''],
      distributor: [''],
      region: [''],
      language: [''],
      notes: [''],
      description : [''],
      system: [null],
      support: [null],
      coverPage: [null,[Validators.required]],
      releaseDate:['']
    });
   }
   editVideoGame(){
      if (this.dataGame.releaseDate!==null){
        let dateRelease = this.dataGame.releaseDate.toString().substr(0, 10);
        this.forma.controls['releaseDate'].patchValue(dateRelease);
      }
      this.forma.controls['title'].patchValue(this.dataGame.title);
      this.forma.controls['developer'].patchValue(this.dataGame.developer);
      this.forma.controls['barCode'].patchValue(this.dataGame.barCode);
      this.forma.controls['redump'].patchValue(this.dataGame.redump);
      this.forma.controls['genre'].patchValue(this.dataGame.genre);
      this.forma.controls['distributor'].patchValue(this.dataGame.distributor);
      this.forma.controls['region'].patchValue(this.dataGame.region);
      this.forma.controls['language'].patchValue(this.dataGame.language);
      this.forma.controls['notes'].patchValue(this.dataGame.notes);
      this.forma.controls['system'].patchValue(this.dataGame.idSystem);
      this.forma.controls['support'].patchValue(this.dataGame.idSupport);
      this.forma.controls['description'].patchValue(this.dataGame.description);
    

  }
   getDataVideoGame(){
    this.subscriptionEdit = this.videogameService.getVideoGame(this.idVideogame)
    .subscribe(rsp => {
     if (rsp.success === true){
 
      this.dataGame = rsp.data;
      this.editVideoGame();
      if ( this.dataGame.coverPage != null){
        this.dataGame.coverPage =  this.dataGame.coverPage.replace(/['"]+/g, '');
      }
    }else{ 
       Swal.fire({
         text: rsp.message,
         title: 'Error al cargar datos',
         icon: 'error',
       });
     }
     });
  }
   save(): void{
    this.createModel();
    if (this.idVideogame === 'new'){
      this.subscription = this.videogameService.addVideoGame(this.game)
              .subscribe(rsp => {
              if (rsp.success === true){
                Swal.fire({
                  text: rsp.message,
                  title: 'Add videogame',
                  icon: 'success'
                }).then((result) => {
                  this.router.navigateByUrl('/home');
                });
                this.cleancomponent();
               }else{
                Swal.fire({
                  text: rsp.message,
                  title: 'Error',
                  icon: 'error',
                });
              }
     });
  }else{
       this.game.id = this.dataGame.id;
       if (this.forma.controls['coverPage'].value === null){
         this.game.coverPage = this.dataGame.coverPage;
      }
       this.subscriptionEdit = this.videogameService.modifyVideoGame(this.game)
            .subscribe(rsp => {
            if (rsp.success === true){
              Swal.close();
              Swal.fire({
                text: rsp.message,
                title: 'Modify videogame',
                icon: 'success',
              }).then((result)=>{
                this.router.navigateByUrl('/home');
              });
              this.cleancomponent()
            }else{
              Swal.fire({
                text: rsp.message,
                title: 'Error',
                icon: 'error',
              });
            }
            });
   }
  }
  loadSystems(): void{
    this.subscription = this.videogameService.allSystems()
      .subscribe(rsp => {
        if (rsp.success === true){
          this.systems = rsp.data;
        }else{
          Swal.fire({
            text: rsp.message,
            title: 'Error',
            icon: 'error',
          });
         }
       });
  }
    loadSupports(): void{
      this.subscription = this.videogameService.allSupports()
      .subscribe(rsp => {
        if (rsp.success === true){
          this.supports = rsp.data;
        }else{
          Swal.fire({
            text: rsp.message,
            title: 'Error',
            icon: 'error',
          });
         }
       });
    }
    onFileChange(event): void {
      console.log(event.target.name);
      const reader = new FileReader();
      if(event.target.files && event.target.files.length) {
        const [file] = event.target.files;
        reader.readAsDataURL(file);
        reader.onload = () => {
         if (event.target.name === 'coverPage'){
            this.forma.patchValue({
              coverPage: reader.result
           });
         }
         this.cd.markForCheck();
        };
      }
    }
    createModel(): void{
    this.game.title = this.forma.controls[ 'title' ].value;
    this.game.developer = this.forma.controls[ 'developer' ].value;
    this.game.barCode = this.forma.controls[ 'barCode' ].value;
    this.game.redump = this.forma.controls[ 'redump' ].value;
    this.game.genre = this.forma.controls[ 'genre' ].value;
    this.game.distributor = this.forma.controls[ 'distributor' ].value;
    this.game.region = this.forma.controls[ 'region' ].value;
    this.game.language = this.forma.controls[ 'language' ].value;
    this.game.notes = this.forma.controls[ 'notes' ].value;
    this.game.description = this.forma.controls[ 'description' ].value;
    this.game.idSystem = this.forma.controls[ 'system' ].value;
    this.game.idSupport = this.forma.controls[ 'support' ].value;
    this.game.coverPage = JSON.stringify(this.forma.controls['coverPage'].value);
    this.game.releaseDate = new Date(this.forma.controls["releaseDate"].value);
  
  }

 cleancomponent(): void{
  this.forma.reset();
  this.game = null;
  this.dataGame = null;
 }
 showSwalDelete(): void{
  Swal.fire({
    text: 'Are you sure to delete the game?',
    allowOutsideClick: false,
    icon: 'info',
    showCancelButton: true,
    confirmButtonColor: '#3085d6',
    cancelButtonColor: '#d33',
    confirmButtonText: 'Yes, delete it!',
   }).then((result) => {
     if (result.isConfirmed){
      this.subscription = this.videogameService.deleteVideoGame(this.dataGame.id)
      .subscribe(rsp => {
        if (rsp.success === true){
          Swal.close();
          Swal.fire({
            text: rsp.message,
            title: 'Delete game',
            icon: 'success',
          });
          this.router.navigateByUrl('/home');
        }else{
          Swal.fire({
            text: rsp.message,
            title: 'Error',
            icon: 'error',
          });
        }
        });
   }});
  }

  goToAction(action: string): void{
    switch (action) {
      case 'delete': {
        this.showSwalDelete();
        break;
      }
      case 'save': {
        this.save();
        break;
      }
      default: {
         break;
       }
   }

  }

}
