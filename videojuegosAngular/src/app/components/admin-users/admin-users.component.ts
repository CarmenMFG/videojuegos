import { Component, OnInit } from '@angular/core';
import { UserService } from '../../services/user.service';
import { UserModel } from '../../models/user.model';
import Swal from 'sweetalert2';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-admin-users',
  templateUrl: './admin-users.component.html',
  styleUrls: ['./admin-users.component.css']
})
export class AdminUsersComponent implements OnInit {
  public users: UserModel[] = new Array<UserModel>();
  private subscription: Subscription = new Subscription();
  constructor(private userService: UserService) { }

  ngOnInit(): void {
  this.loadAllUser();
  }
  loadAllUser(): void{
    Swal.fire({
      text: 'Espere por favor',
      allowOutsideClick: false,
      icon: 'info',
     });
    Swal.showLoading();
    this.subscription = this.userService.allUsers()
      .subscribe(rsp => {
         Swal.close();
         if (rsp.success === true){
          this.users = rsp.data;
          console.log(this.users);
         }else{
          Swal.fire({
            text: rsp.message,
            title: 'Error load data',
            icon: 'error',
          });
         }
       });
  }
  showSwalDelete(id:number): void{
    Swal.fire({
      text: 'Are you sure to delete user ?',
      allowOutsideClick: false,
      icon: 'info',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!',
     }).then((result) => {
       if (result.isConfirmed){
         console.log("Borrar",id);
       /* this.subscription = this.userService.deleteUser(id)
        .subscribe(rsp => {
          if (rsp.success === true){
            Swal.close();
            Swal.fire({
              text: rsp.message,
              title: 'Deleted user',
              icon: 'success',
            });
           }else{
            Swal.fire({
              text: rsp.message,
              title: 'Error',
              icon: 'error',
            });
          }
          });*/
     }});
    }
   async showSwalEdit(id: number){
      const { value: role } = await Swal.fire({
        title: 'Select field validation',
        input: 'select',
        inputOptions: {
           admin: 'Administrator',
            user: 'User'
        },
        inputPlaceholder: 'Select a role',
        showCancelButton: true,
        inputValidator: (value) => {
          return new Promise((resolve) => {
             resolve();
          });
        }
      });
      console.log(role);
    }

}
