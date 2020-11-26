import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
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
  dataGame : VideoGameModel;
  private subscription: Subscription = new Subscription();
  constructor(private actRoute: ActivatedRoute,
              private videogameService: VideogameService) {
    this.idVideogame = this.actRoute.snapshot.params.id;
   }
   ngOnDestroy(): void {

    this.subscription.unsubscribe();
  }

  ngOnInit(): void {
     this.getDataVideoGame();
  }
  getDataVideoGame(): void{
    this.subscription = this.videogameService.getVideoGame(this.idVideogame)
    .subscribe(rsp => {
     if (rsp.success === true){
      this.dataGame = rsp.data;
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
