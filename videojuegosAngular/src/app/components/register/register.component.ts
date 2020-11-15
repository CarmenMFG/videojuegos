import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UserModel } from '../../models/user.model';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  user: UserModel;

  constructor(private userService: UserService) {

   }


  ngOnInit() {
    this.user = new UserModel();
  }
  onSubmit(form: NgForm) {
    if (form.invalid){ return; }
    this.userService.registerUser(this.user)
                    .subscribe(rsp =>{
                      console.log(rsp);
                    });
 }


}
