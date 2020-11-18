import { Component, OnInit } from '@angular/core';
import { LoginModel } from '../../models/login.model';
import { NgForm } from '@angular/forms';
import { Subscription } from 'rxjs';
import { UserService } from '../../services/user.service';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginModel: LoginModel;
  private subscription: Subscription = new Subscription();

  constructor(private userService: UserService) { }

  // tslint:disable-next-line: typedef
  ngOnInit() {
    this.loginModel = new LoginModel();
  }
  // tslint:disable-next-line: typedef
  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

  // tslint:disable-next-line: typedef
  login(form: NgForm) {
    if (form.invalid) { return; }
    this.subscription = this.userService.loginUser(this.loginModel)
      .subscribe(rsp => {
         this.userService.saveTokenUser(rsp.token, rsp.userName);
      }, ( err ) => {
        console.log(err);
      });

  }

}
