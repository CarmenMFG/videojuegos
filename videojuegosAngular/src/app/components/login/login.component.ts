import { Component, OnDestroy, OnInit } from '@angular/core';
import { LoginModel } from '../../models/login.model';
import { NgForm } from '@angular/forms';
import { Subscription } from 'rxjs';
import { UserService } from '../../services/user.service';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit, OnDestroy {
  loginModel: LoginModel;
  remember = false;
  private subscription: Subscription = new Subscription();

  constructor(private userService: UserService,
              private router: Router) { }

  ngOnInit(): void {
    this.loginModel = new LoginModel();
    if (localStorage.getItem('Remember') !== '' && localStorage.getItem('UserName')){
        this.loginModel.user = localStorage.getItem('UserName');
        this.remember = true;
    }

  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  login(form: NgForm): void {
    if (form.invalid) { return; }
    this.subscription = this.userService.loginUser(this.loginModel)
      .subscribe(rsp => {
        if (rsp.userName !== ''){
            this.userService.saveTokenUser(rsp);
            this.router.navigateByUrl('/home');
            localStorage.setItem('Remember', this.remember ? 'true' : '' );
       }else{
          Swal.fire({
            text: 'Invalid username or pasword',
            title: 'Error',
            icon: 'error',
          });
        }
     }, (err) => {
          console.log(err);
          Swal.fire({
            text: 'Error authentication ',
            title: 'Error',
            icon: 'error',
          });
      });

  }

}
