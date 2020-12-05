import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { UserModel } from '../models/user.model';
import { of ,Observable} from 'rxjs';
import { LoginModel } from '../models/login.model';



@Injectable({
  providedIn: 'root'
})
export class UserService {
  private url = 'https://localhost:44357/api/Account';
  obs$;
  obsName$;
  
 constructor(private http: HttpClient) {
    this.obs$ = new Observable(observer => {
    let token;
    let user;
    setInterval(() => {
       token = this.getToken();
       observer.next(token);
      }, 1000)
    });
    this.obsName$ = new Observable(observer => {
      let user;
      setInterval(() => {
         user= this.getUser();
         observer.next(user);
        }, 1000)
      });
  }
 
  public registerUser(user: UserModel): Observable<any> {
    const data = { ...user };
    console.log(data);
    return this.http.post(`${this.url}/register`, data);
  }

  public loginUser(login: LoginModel): Observable<any> {
    const data = { ...login };
    return this.http.post(`${this.url}/login`, data);
  }
  public logout(): void {
    localStorage.removeItem('Token');
    localStorage.removeItem('Role');
  }
   saveTokenUser(rsp: any): void {
    localStorage.setItem('Token', rsp.token);
    localStorage.setItem('UserName', rsp.userName);
    localStorage.setItem('Role', rsp.role);
  }
   getToken(): string {
    return (localStorage.getItem('Token')) ? localStorage.getItem('Token') : '';
  }
   getUser(): string {
    return (localStorage.getItem('UserName')) ? localStorage.getItem('UserName') : '';
  }
  isAdmin(): boolean {
    return (localStorage.getItem('Role') === 'admin') ;
  }
  isAuthenticated(): boolean{
     return localStorage.getItem('Token') != null;
  }
 

}
