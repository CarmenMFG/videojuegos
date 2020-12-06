import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { UserModel } from '../models/user.model';
import { of ,Observable} from 'rxjs';
import { LoginModel } from '../models/login.model';

@Injectable({
  providedIn: 'root'
})
export class AdminUserService {
  private urlUsers = 'https://localhost:44357/api/User';
  
  constructor(private http: HttpClient) { }
  
   public allUsers(): Observable<any> {
    const headers: HttpHeaders = new HttpHeaders({
      Authorization: `Bearer ${localStorage.getItem('Token')}`
    });
    return this.http.get(`${this.urlUsers}`, { headers });
  }

  public deactiveUser(id: number): Observable<any> {
    const headers: HttpHeaders = new HttpHeaders({
      Authorization: `Bearer ${localStorage.getItem('Token')}`
    });
    return this.http.delete(`${this.urlUsers}/${id}`, { headers });
  }
  public activeUser(id: number): Observable<any> {
    const headers: HttpHeaders = new HttpHeaders({
      Authorization: `Bearer ${localStorage.getItem('Token')}`
    });
    return this.http.put(`${this.urlUsers}/${id}`,null, { headers });
  }
  public changeRol(id: number): Observable<any> {
    const headers: HttpHeaders = new HttpHeaders({
      Authorization: `Bearer ${localStorage.getItem('Token')}`
    });
    console.log(id);
    const data = { idUser: id};
    return this.http.post(`${this.urlUsers}/changeRolAdmin`, data , { headers });
  }

}
