import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { ArtistService } from '../_services/artist.service';
import { ArtistList } from '../_models/artist-list';

@Injectable()
export class ArtistListResolver implements Resolve<ArtistList[]> {
    constructor(private artistService: ArtistService, private router: Router) {}

    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<ArtistList[]> {
        return this.artistService.getArtists().pipe(
            catchError(error => {
                this.router.navigate(['/artists']);
                return of(null);
            })
        );
    }
}
