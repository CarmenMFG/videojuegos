import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { VideogameService } from '../../services/videogame.service';
import { VideoGameModel } from 'src/app/models/videogame.model';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  private subscription: Subscription = new Subscription();
  public videogames: VideoGameModel[] = new Array<VideoGameModel>();
  constructor(private router: Router, private videogameService: VideogameService) { }

  ngOnInit() {
    this.loadAllVideoGame();
  }
  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  
  goAddGame(): void{
     this.router.navigateByUrl('/videogame');
  }
  loadAllVideoGame(): void{
    Swal.fire({
      text: 'Espere por favor',
      allowOutsideClick: false,
      icon: 'info',
     });
    Swal.showLoading();
    this.subscription = this.videogameService.allGames()
      .subscribe(rsp => {
         Swal.close();
         if (rsp.success === true){
          this.videogames = rsp.data;
          this.videogames.forEach(game=>{
            if (game.coverPage!=null){
              game.coverPage = game.coverPage.replace(/['"]+/g, '');
            }
          })
          console.log(this.videogames);
        }else{
          Swal.fire({
            text: rsp.message,
            title: 'Error al cargar datos',
            icon: 'error',
          });
         }
       });
  }
}
