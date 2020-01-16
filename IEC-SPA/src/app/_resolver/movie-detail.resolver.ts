import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, Router } from '@angular/router';
import { Movie } from '../_models/movie';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { GenericRestService } from '../_services/generic-rest.service';

@Injectable()
export class MovieDetailResolver implements Resolve<Movie> {
    constructor(private genericRestService: GenericRestService<Movie>, private router: Router) {}

    resolve(route: ActivatedRouteSnapshot): Observable<Movie> {
        return this.genericRestService.getEntity(route.params.id, 'movies').pipe(
            catchError(error => {
                this.router.navigate(['/movies']);
                return of(null);
            })
        );
    }
}
