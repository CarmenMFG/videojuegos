import { Component, OnInit, Inject, OnDestroy } from '@angular/core';
import { DOCUMENT } from '@angular/common';
import { UserService } from '../../services/user.service';
import { Router } from '@angular/router';
import {Subscription} from 'rxjs';


@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit,OnDestroy {
  public isLog = false;
  userName: string;
  private subscription: Subscription = new Subscription();

  constructor(@Inject(DOCUMENT) public document: Document, private userService: UserService,
              private router: Router) {
    this.subscription =this.userService.obs$.subscribe( user => {
      this.userName = user;
      this.isLog = user !== '';
    });
  }

  ngOnInit(): void {
  }
  ngOnDestroy(): void {
   this.subscription.unsubscribe();
  }

  logout(): void{
    this.userService.logout();
  }
}
