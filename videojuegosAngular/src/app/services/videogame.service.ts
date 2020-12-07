import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { VideoGameModel } from '../models/videogame.model';

@Injectable({
  providedIn: 'root',
})
export class VideogameService {
  private url = 'https://localhost:44357/api/VideoGame';
  private token: string;

  constructor(private http: HttpClient) {
    this.token = localStorage.getItem('Token');
  }
  public saveVideoGame(game: VideoGameModel): Observable<any> {
    this.token = localStorage.getItem('Token');

    const headers: HttpHeaders = new HttpHeaders({
      Authorization: `Bearer ${this.token}`,
    });
    const data = { ...game };
    return this.http.post(`${this.url}`, data, { headers });
  }

  public allSystems(): Observable<any> {
    this.token = localStorage.getItem('Token');

    const headers: HttpHeaders = new HttpHeaders({
      Authorization: `Bearer ${this.token}`,
    });
    return this.http.get(`${this.url}/systems`, { headers });
  }
  public allSupports(): Observable<any> {
    this.token = localStorage.getItem('Token');

    const headers: HttpHeaders = new HttpHeaders({
      Authorization: `Bearer ${this.token}`,
    });
    return this.http.get(`${this.url}/supports`, { headers });
  }
  public allGames(): Observable<any> {
    this.token = localStorage.getItem('Token');

    const headers: HttpHeaders = new HttpHeaders({
      Authorization: `Bearer ${this.token}`,
    });

    return this.http.get(`${this.url}/getAll`, { headers });
  }
  public getVideoGame(id: number): Observable<any> {
    this.token = localStorage.getItem('Token');

    const headers: HttpHeaders = new HttpHeaders({
      Authorization: `Bearer ${this.token}`,
    });
    return this.http.get(`${this.url}/${id}`, { headers });
  }
  public deleteVideoGame(id: number): Observable<any> {
    this.token = localStorage.getItem('Token');

    const headers: HttpHeaders = new HttpHeaders({
      Authorization: `Bearer ${this.token}`,
    });
    return this.http.delete(`${this.url}/${id}`, { headers });
  }
}
