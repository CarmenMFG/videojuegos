import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { VideoGameModel } from 'src/app/models/videogame.model';
import { Subscription } from 'rxjs';
import { VideogameService } from '../../services/videogame.service';
import { SystemModel } from '../../models/system.model';
import Swal from 'sweetalert2';
import { SupportModel } from '../../models/support.model';
import { ChangeDetectorRef } from '@angular/core';


@Component({
  selector: 'app-videogame',
  templateUrl: './videogame.component.html',
  styleUrls: ['./videogame.component.css']
})
export class VideogameComponent implements OnInit, OnDestroy {
 
 public forma: FormGroup;
 public game: VideoGameModel = new VideoGameModel();
 private subscription: Subscription = new Subscription();
 public systems: SystemModel[] = new Array<SystemModel>();
 public supports: SupportModel[]= new Array<SupportModel>();
 
 constructor(private fb: FormBuilder,
             private videogameService: VideogameService,
             private cd: ChangeDetectorRef) { 
     this.createForm();
  }

  async ngOnInit() {
    this.loadSystems();
    this.loadSupports();
   }
  
  ngOnDestroy(): void {

    this.subscription.unsubscribe();
  }

  createForm(): void{
    this.forma = this.fb.group({
      title: ['',[Validators.required,Validators.minLength(3)]],
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
      coverPage: [null]
    });
   }

   save(): void{
     if (this.forma.invalid){
       return Object.values(this.forma.controls).forEach(control => {
         control.markAsTouched();
       });
     }
     this.createModel();
     this.subscription = this.videogameService.addVideoGame(this.game)
     .subscribe(rsp => {console.log(rsp)});
     this.forma.reset();
   }
  loadSystems(){
    this.subscription = this.videogameService.allSystems()
      .subscribe(rsp => {
        console.log(rsp);
        if (rsp.success === true){
          this.systems = rsp.data;
        }else{
          Swal.fire({
            text: rsp.message,
            title: 'Error al cargar datos',
            icon: 'error',
          });
         }
       });
  }
    loadSupports(): void{
      this.subscription = this.videogameService.allSupports()
      .subscribe(rsp => {
        console.log(rsp);
        if (rsp.success === true){
          this.supports = rsp.data;
        }else{
          Swal.fire({
            text: rsp.message,
            title: 'Error al cargar datos',
            icon: 'error',
          });
         }
       });
    }

    onFileChange(event): void {
      const reader = new FileReader();
   
      if(event.target.files && event.target.files.length) {
        const [file] = event.target.files;
        reader.readAsDataURL(file);
    
        reader.onload = () => {
          this.forma.patchValue({
            coverPage: reader.result
         });
        
          // need to run CD since file load runs outside of zone
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
    this.game.coverPage = this.forma.controls['coverPage'].value;
  }

}
