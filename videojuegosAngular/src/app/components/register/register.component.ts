import { Component, OnDestroy, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Subscription } from 'rxjs';
import { UserModel } from '../../models/user.model';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit, OnDestroy {
  user: UserModel;
  private subscription: Subscription = new Subscription();

  constructor(private userService: UserService) {

  }

  // tslint:disable-next-line: typedef
  ngOnInit() {
    this.user = new UserModel();
  }
  // tslint:disable-next-line: typedef
  ngOnDestroy() {

    this.subscription.unsubscribe();
  }

  // tslint:disable-next-line: typedef
  onSubmit(form: NgForm) {
    if (form.invalid) { return; }
    this.subscription = this.userService.registerUser(this.user)
      .subscribe(rsp => {
        this.userService.saveTokenUser(rsp.token, rsp.userName);
      });
  }


}
