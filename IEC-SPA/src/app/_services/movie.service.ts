import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Movie } from '../_models/movie';
import { Observable } from 'rxjs';
import { MovieList } from '../_models/movie-list';
import { PaginatedResult } from '../_models/pagination';
import { map } from 'rxjs/operators';

@Injectable()
export class MovieService {
    baseUrl = environment.apiUrl;

    constructor(private http: HttpClient) { }

    getMovies(page?, itemsPerPage?, movieParams?): Observable<PaginatedResult<MovieList[]>> {
        const paginatedResult: PaginatedResult<MovieList[]> = new PaginatedResult<MovieList[]>();

        let params = new HttpParams();

        if (page != null && itemsPerPage != null) {
          params = params.append('pageNumber', page);
          params = params.append('pageSize', itemsPerPage);
        }

        if (movieParams != null) {
            params = params.append('oderBy', movieParams.orderBy);
        }

        return this.http.get<MovieList[]>(this.baseUrl + 'movies', {observe: 'response', params})
        .pipe(
            map(response => {
              paginatedResult.result = response.body;
              if (response.headers.get('Pagination') != null) {
                paginatedResult.pagination = JSON.parse(response.headers.get('Pagination'));
              }
              return paginatedResult;
            })
        );
    }

    getMovie(id: number): Observable<Movie> {
        return this.http.get<Movie>(this.baseUrl + 'movies/' + id);
    }

}
