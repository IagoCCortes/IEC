import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Movie } from '../_models/movie';
import { Observable, of } from 'rxjs';
import { MovieService } from '../_services/movie.service';
import { catchError } from 'rxjs/operators';

@Injectable()
export class MovieListResolver implements Resolve<Movie[]> {
    constructor(private movieService: MovieService, private router: Router) {}

    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<Movie[]> {
        return this.movieService.getMovies().pipe(
            catchError(error => {
                this.router.navigate(['/movies']);
                return of(null);
            })
        );
    }
}
