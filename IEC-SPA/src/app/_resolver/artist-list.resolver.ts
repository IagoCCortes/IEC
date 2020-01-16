import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { ArtistList } from '../_models/artist-list';
import { AlertifyService } from '../_services/alertify.service';
import { GenericRestService } from '../_services/generic-rest.service';

@Injectable()
export class ArtistListResolver implements Resolve<ArtistList[]> {
    pageNumber = 1;
    pageSize = 12;

    constructor(private genericRestService: GenericRestService<ArtistList>, private router: Router, private alertify: AlertifyService) {}

    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<ArtistList[]> {
        return this.genericRestService.getEntities('artists', this.pageNumber, this.pageSize).pipe(
            catchError(error => {
                this.alertify.error('Problem retrieving data');
                // this.router.navigate(['/artists']);
                return of(null);
            })
        );
    }
}
