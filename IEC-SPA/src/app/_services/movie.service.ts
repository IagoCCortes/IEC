import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Movie } from '../_models/movie';
import { Observable } from 'rxjs';
import { MovieList } from '../_models/movie-list';

@Injectable()
export class MovieService {
    baseUrl = environment.apiUrl;

    constructor(private http: HttpClient) { }

    getMovies(): Observable<MovieList[]> {
        return this.http.get<MovieList[]>(this.baseUrl + 'movies/GetMovies');
    }

    getMovie(id: number): Observable<Movie> {
        return this.http.get<Movie>(this.baseUrl + 'movies/GetMovie/' + id);
    }

}
