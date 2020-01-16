import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { ArtistService } from '../_services/artist.service';
import { Artist } from '../_models/artist';

@Injectable()
export class ArtistDetailResolver implements Resolve<Artist> {
    constructor(private artistService: ArtistService, private router: Router) {}

    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<Artist> {
        return this.artistService.getEntity(route.params.id, 'artists').pipe(
            catchError(error => {
                this.router.navigate(['/artists']);
                return of(null);
            })
        );
    }
}
