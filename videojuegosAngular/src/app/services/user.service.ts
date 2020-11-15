import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserModel } from '../models/user.model';


@Injectable({
  providedIn: 'root'
})
export class UserService {
  private url = 'https://localhost:44357/api/Account/';
  constructor(private http: HttpClient) {


  }
  logout() { }
  login(user: UserModel) { }

  registerUser(user: UserModel) {
    const data = { ...user };
    return this.http.post(`${this.url}/register`, data);
  }
}
