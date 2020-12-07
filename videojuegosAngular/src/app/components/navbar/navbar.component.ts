import { Component, OnInit, Inject, OnDestroy } from '@angular/core';
import { DOCUMENT } from '@angular/common';
import { UserService } from '../../services/user.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'],
})
export class NavbarComponent implements OnInit, OnDestroy {
  public isLog = false;
  public token: string;
  public userName: string;
  private subscription: Subscription = new Subscription();
  private subscriptionName: Subscription = new Subscription();
  public isAdmin: boolean;

  constructor(
    @Inject(DOCUMENT) public document: Document,
    private userService: UserService
  ) {
    /* this.subscription =this.userService.obs$.subscribe( token => {
      this.token = token;
      this.isLog = token !== '';
    });
    this.subscriptionName =this.userService.obsName$.subscribe( user => {
      this.userName = user;
    });*/
    this.subscription = this.userService
      .getObservable()
      .subscribe((isLogged) => {
        this.token = this.userService.getToken();
        this.isLog = this.token !== '';
        this.userName = this.userService.getUser();
        this.isAdmin = this.userService.isAdmin();
      });
  }

  ngOnInit(): void {
    this.userName = this.userService.getUser();
    this.isAdmin = this.userService.isAdmin();
  }
  ngOnDestroy(): void {
    this.subscription.unsubscribe();
    // this.subscriptionName.unsubscribe();
  }

  logout(): void {
    this.userService.logout();
  }
}
