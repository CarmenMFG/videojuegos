import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';
import Swal from 'sweetalert2';
import { VideoGameModel } from '../../models/videogame.model';
import { VideogameService } from '../../services/videogame.service';

@Component({
  selector: 'app-videogame-detail',
  templateUrl: './videogame-detail.component.html',
  styleUrls: ['./videogame-detail.component.css'],
})
export class VideogameDetailComponent implements OnInit {
  idVideogame: number;
  dataGame: VideoGameModel = null;
  private subscription: Subscription = new Subscription();
  constructor(
    private actRoute: ActivatedRoute,
    private videogameService: VideogameService,
    private router: Router
  ) {
    this.idVideogame = this.actRoute.snapshot.params.id;
  }
  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  ngOnInit() {
    this.getDataVideoGame();
  }
  getDataVideoGame() {
    this.subscription = this.videogameService
      .getVideoGame(this.idVideogame)
      .subscribe((rsp) => {
        if (rsp.success === true) {
          this.dataGame = rsp.data;
          console.log(rsp.data);
          if (this.dataGame.coverPage !== null) {
            this.dataGame.coverPage = this.dataGame.coverPage.replace(
              /['"]+/g,
              ''
            );
          }
        } else {
          Swal.fire({
            text: rsp.message,
            title: 'Error loading data',
            icon: 'error',
          });
        }
      });
  }
  goHome(): void {
    this.router.navigateByUrl('/home');
  }
  showSwalDelete(): void {
    Swal.fire({
      text: 'Are you sure to delete game ?',
      allowOutsideClick: false,
      icon: 'info',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!',
    }).then((result) => {
      if (result.isConfirmed) {
        this.subscription = this.videogameService
          .deleteVideoGame(this.dataGame.id)
          .subscribe((rsp) => {
            if (rsp.success === true) {
              Swal.close();
              Swal.fire({
                text: rsp.message,
                title: 'Delete game',
                icon: 'success',
              });

              this.router.navigateByUrl('/home');
            } else {
              Swal.fire({
                text: rsp.message,
                title: 'Error',
                icon: 'error',
              });
            }
          });
      }
    });
  }
  goToEdit(): void {
    this.router.navigate(['/videogame', this.dataGame.id]);
  }
  goToAction(action: string): void {
    switch (action) {
      case 'delete': {
        this.showSwalDelete();
        break;
      }
      case 'edit': {
        this.goToEdit();
        break;
      }
      case 'goHome':{
        this.router.navigateByUrl('/home');
        break;
      }
      default: {
        break;
      }
    }
  }
}
