import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { UserModel } from '../models/user.model';
import {Subject ,Observable} from 'rxjs';
import { LoginModel } from '../models/login.model';



@Injectable({
  providedIn: 'root'
})
export class UserService {
  loadServiceSubject : Subject<any> = new Subject();
  loadService$ : Observable<any> = this.loadServiceSubject.asObservable();
  private url = 'https://localhost:44357/api/Account';
  obs$;
  obsName$;
  
 constructor(private http: HttpClient) {
  /*  this.obs$ = new Observable(observer => {
    let token;
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
      });*/
  }
  // --Register and Login user
   public registerUser(user: UserModel): Observable<any> {
    const data = { ...user };
    return this.http.post(`${this.url}/register`, data);
  }

  public loginUser(login: LoginModel): Observable<any> {
    const data = { ...login };
    return this.http.post(`${this.url}/login`, data);
  }
 
  // -- Method with localstorage
  public logout(): void {
    localStorage.removeItem('Token');
    localStorage.removeItem('Role');
    this.changeUser(false);
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
 
  //Observables
  getObservable():Observable<any>{
    return this.loadService$;
  }
  changeUser(userLog :boolean){
    this.loadServiceSubject.next(userLog);
  }

}
