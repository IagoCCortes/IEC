import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { UserMovie } from '../_models/userMovie';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserMovieService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getUserMovie(id: number): Observable<UserMovie> {
    return this.http.get<UserMovie>(this.baseUrl + 'users/' + id + '/movies');
  }
}
