import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { MovieList } from '../_models/movie-list';
import { AlertifyService } from '../_services/alertify.service';
import { GenericRestService } from '../_services/generic-rest.service';

@Injectable()
export class MovieListResolver implements Resolve<MovieList[]> {
    pageNumber = 1;
    pageSize = 14;

    constructor(private genericRestService: GenericRestService<MovieList>, private router: Router, private alertify: AlertifyService) {}

    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<MovieList[]> {
        return this.genericRestService.getEntities('movies', this.pageNumber, this.pageSize).pipe(
            catchError(error => {
                this.alertify.error('Problem retrieving data');
                // this.router.navigate(['/movies']);
                return of(null);
            })
        );
    }
}
