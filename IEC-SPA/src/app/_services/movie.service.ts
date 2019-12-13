import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Movie } from '../_models/movie';
import { Observable } from 'rxjs';

@Injectable()
export class MovieService {
    baseUrl = environment.apiUrl;

    constructor(private http: HttpClient) { }

    getMovies(): Observable<Movie[]> {
        return this.http.get<Movie[]>(this.baseUrl + 'movies');
    }

    getMovie(id: number): Observable<Movie> {
        return this.http.get<Movie>(this.baseUrl + 'movies/' + id);
    }

}
