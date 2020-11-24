import { Component, OnInit, Inject, OnChanges } from '@angular/core';
import { DOCUMENT } from '@angular/common';
import { UserService } from '../../services/user.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  public isLog = false;
  public username: string;
  constructor(@Inject(DOCUMENT) public document: Document,
              private userService: UserService,
              private router: Router) { }

  ngOnInit(): void {
    this.username = this.userService.getUser();
    this.isLog = (this.username === '') ? false : true;
  }
  logout(): void{
    this.userService.logout();
  }
}
