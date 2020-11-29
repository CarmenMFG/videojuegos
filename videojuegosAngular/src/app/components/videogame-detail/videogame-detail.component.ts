import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { ActivatedRoute, Router} from '@angular/router';
import Swal from 'sweetalert2';
import { VideoGameModel } from '../../models/videogame.model';
import { VideogameService } from '../../services/videogame.service';


@Component({
  selector: 'app-videogame-detail',
  templateUrl: './videogame-detail.component.html',
  styleUrls: ['./videogame-detail.component.css']
})
export class VideogameDetailComponent implements OnInit {
  idVideogame: number;
  dataGame : VideoGameModel= null;
  private subscription: Subscription = new Subscription();
  constructor(private actRoute: ActivatedRoute,
              private videogameService: VideogameService,
              private router: Router) {
    this.idVideogame = this.actRoute.snapshot.params.id;
   }
  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

 ngOnInit() {
    this.getDataVideoGame();
  }
  getDataVideoGame(){
    Swal.fire({
      text: 'Espere por favor',
      allowOutsideClick: false,
      icon: 'info',
     });
    Swal.showLoading();
    this.subscription = this.videogameService.getVideoGame(this.idVideogame)
    .subscribe(rsp => {
     if (rsp.success === true){
      Swal.close();
      this.dataGame = rsp.data;
      if ( this.dataGame.coverPage!=null){
        this.dataGame.coverPage =  this.dataGame.coverPage.replace(/['"]+/g, '');
      }
     // this.dataGame.coverPage=this.sanitization.bypassSecurityTrustStyle(this.dataGame.coverPage);
      console.log(this.dataGame);
     }else{
       Swal.fire({
         text: rsp.message,
         title: 'Error al cargar datos',
         icon: 'error',
       });
     }
     });
  }
  goHome(): void{
    this.router.navigateByUrl('/home');
 }
 showSwalDelete():void{
  Swal.fire({
    text: '¿Está seguro de borrar el juego?',
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
            title: 'Borrar videojuego',
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
  goToEdit(): void {
   this.router.navigate(['/videogame', this.dataGame.id]);
  }
}
