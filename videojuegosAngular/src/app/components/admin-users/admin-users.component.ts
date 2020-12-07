import { Component, OnInit } from '@angular/core';
import { UserModel } from '../../models/user.model';
import Swal from 'sweetalert2';
import { Subscription } from 'rxjs';
import { AdminUserService } from '../../services/admin-user.service';

@Component({
  selector: 'app-admin-users',
  templateUrl: './admin-users.component.html',
  styleUrls: ['./admin-users.component.css'],
})
export class AdminUsersComponent implements OnInit {
  public users: UserModel[] = new Array<UserModel>();
  private subscription: Subscription = new Subscription();
  constructor(private adminUserService: AdminUserService) {}

  ngOnInit(): void {
    this.loadAllUser();
  }
  loadAllUser(): void {
    Swal.fire({
      text: 'Espere por favor',
      allowOutsideClick: false,
      icon: 'info',
    });
    Swal.showLoading();
    this.subscription = this.adminUserService.allUsers().subscribe((rsp) => {
      Swal.close();
      if (rsp.success === true) {
        this.users = rsp.data;
        console.log(this.users);
      } else {
        Swal.fire({
          text: rsp.message,
          title: 'Error load data',
          icon: 'error',
        });
      }
    });
  }
  showSwalDeactive(id: number): void {
    Swal.fire({
      text: 'Are you sure to delete user ?',
      allowOutsideClick: false,
      icon: 'info',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!',
    }).then((result) => {
      if (result.isConfirmed) {
        this.subscription = this.adminUserService
          .deactiveUser(id)
          .subscribe((rsp) => {
            if (rsp.success === true) {
              Swal.close();
              Swal.fire({
                text: rsp.message,
                title: 'Deleted user',
                icon: 'success',
              });
              this.loadAllUser();
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
  showSwalActive(id: number): void {
    Swal.fire({
      text: 'Are you sure to active user ?',
      allowOutsideClick: false,
      icon: 'info',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, active it!',
    }).then((result) => {
      if (result.isConfirmed) {
        this.subscription = this.adminUserService
          .activeUser(id)
          .subscribe((rsp) => {
            if (rsp.success === true) {
              Swal.close();
              Swal.fire({
                text: rsp.message,
                title: 'Actived user',
                icon: 'success',
              });
              this.loadAllUser();
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
  async showSwalEdit(id: number) {
    const { value: role } = await Swal.fire({
      title: 'Select field validation',
      input: 'select',
      inputOptions: {
        admin: 'Administrator',
        user: 'User',
      },
      inputPlaceholder: 'Select a role',
      showCancelButton: true,
      inputValidator: (value) => {
        return new Promise((resolve) => {
          resolve();
        });
      },
    });
    if (role == 'admin') {
      this.subscription = this.adminUserService
        .changeRol(id)
        .subscribe((rsp) => {
          if (rsp.success === true) {
            Swal.close();
            Swal.fire({
              text: rsp.message,
              title: 'Rol changed',
              icon: 'success',
            });
            this.loadAllUser();
          } else {
            Swal.fire({
              text: rsp.message,
              title: 'Error',
              icon: 'error',
            });
          }
        });
    }
  }
}
