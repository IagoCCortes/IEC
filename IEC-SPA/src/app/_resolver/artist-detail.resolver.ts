import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Artist } from '../_models/artist';
import { GenericRestService } from '../_services/generic-rest.service';

@Injectable()
export class ArtistDetailResolver implements Resolve<Artist> {
    constructor(private genericRestService: GenericRestService<Artist>, private router: Router) {}

    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<Artist> {
        return this.genericRestService.getEntity(route.params.id, 'artists').pipe(
            catchError(error => {
                this.router.navigate(['/artists']);
                return of(null);
            })
        );
    }
}
