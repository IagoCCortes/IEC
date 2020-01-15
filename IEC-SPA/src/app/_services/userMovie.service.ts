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

  addToMovieList(userId: number, movie: object) {
    return this.http.post(this.baseUrl + 'users/' + userId + '/movies', movie);
  }

  removeFromMovieList(userId: number, movieId: number) {
    return this.http.delete(this.baseUrl + 'users/' + userId + '/movies/' + movieId);
  }
}
