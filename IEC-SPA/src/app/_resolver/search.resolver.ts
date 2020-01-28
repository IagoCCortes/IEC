import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AlertifyService } from '../_services/alertify.service';
import { GenericRestService } from '../_services/generic-rest.service';
import { SearchResult } from '../_models/searchResult';

@Injectable()
export class SearchResolver implements Resolve<SearchResult[]> {

    constructor(private genericRestService: GenericRestService<SearchResult>, private router: Router, private alertify: AlertifyService) {}

    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<SearchResult[]> {
        return this.genericRestService.getEntitiesStr(route.params.searchStr, 'search').pipe(
            catchError(error => {
                this.alertify.error('Problem retrieving data');
                // this.router.navigate(['/movies']);
                return of(null);
            })
        );
    }
}
