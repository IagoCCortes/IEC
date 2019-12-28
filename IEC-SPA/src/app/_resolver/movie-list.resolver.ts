import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable, of } from 'rxjs';
import { MovieService } from '../_services/movie.service';
import { catchError } from 'rxjs/operators';
import { MovieList } from '../_models/movie-list';

@Injectable()
export class MovieListResolver implements Resolve<MovieList[]> {
    constructor(private movieService: MovieService, private router: Router) {}

    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<MovieList[]> {
        return this.movieService.getMovies().pipe(
            catchError(error => {
                this.router.navigate(['/movies']);
                return of(null);
            })
        );
    }
}
