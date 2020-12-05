import { Component, OnDestroy, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Subscription } from 'rxjs';
import { UserModel } from '../../models/user.model';
import { UserService } from '../../services/user.service';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit, OnDestroy {
  user: UserModel;
  remember = false;
  private subscription: Subscription = new Subscription();

  constructor(private userService: UserService,
              private router: Router) { }

  ngOnInit(): void {
    this.user = new UserModel();
    if (localStorage.getItem('Remember') !== '' && localStorage.getItem('UserName')){
      this.user.user = localStorage.getItem('UserName');
      this.remember = true;
  }
  }
  ngOnDestroy(): void {

    this.subscription.unsubscribe();
  }

  onSubmit(form: NgForm): void {
    if (form.invalid) { return; }
    this.subscription = this.userService.registerUser(this.user)
      .subscribe(rsp => {
        if (rsp.userName !==''){
          this.userService.saveTokenUser(rsp);
          this.router.navigateByUrl('/home');
          localStorage.setItem('Remember', this.remember ? 'true' : '' );
        }else{
          Swal.fire({
            text: 'Invalid username or email',
            title: 'Error',
            icon: 'error',
          });
        }
      }, (err) => {
        console.log(err);
        Swal.fire({
          text: 'Error during registration',
          title: 'Error',
          icon: 'error',
        });
      });
  }
}
