import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { UserModel } from '../models/user.model';
import { Observable } from 'rxjs';
import { LoginModel } from '../models/login.model';


@Injectable({
  providedIn: 'root'
})
export class UserService {
  private url = 'https://localhost:44357/api/Account';
  constructor(private http: HttpClient) {

  }
  //logout() { }



  public registerUser(user: UserModel): Observable<any> {
    const headers = new HttpHeaders();
    headers.append('Access-Control-Allow-Headers', 'Content-Type');
    headers.append('Access-Control-Allow-Methods', '*');
    headers.append('Access-Control-Allow-Origin', '*');
    const data = { ...user };
    console.log(data);
    return this.http.post(`${this.url}/register`, data, { headers });
  }

  public loginUser(login: LoginModel): Observable<any> {
    const headers = new HttpHeaders();
    headers.append('Access-Control-Allow-Headers', 'Content-Type');
    headers.append('Access-Control-Allow-Methods', '*');
    headers.append('Access-Control-Allow-Origin', '*');
    const data = { ...login };
    return this.http.post(`${this.url}/login`, data, { headers });
  }
   saveTokenUser(token: string, userName: string): void {
    localStorage.setItem('Token', token);
    localStorage.setItem('UserName', userName);
  }
   getToken(): string {
    return (localStorage.getItem('Token')) ? localStorage.getItem('Token') : '';
  }
   getUser(): string {
    return (localStorage.getItem('UserName')) ? localStorage.getItem('UserName') : '';
  }

}
