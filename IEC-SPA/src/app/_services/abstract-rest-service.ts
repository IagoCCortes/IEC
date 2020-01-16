import { environment } from 'src/environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PaginatedResult } from '../_models/pagination';
import { map } from 'rxjs/operators';

export abstract class AbstractRestService<T> {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getEntities(entity: string, page?, itemsPerPage?, entityParams?): Observable<PaginatedResult<T[]>> {
    const paginatedResult: PaginatedResult<T[]> = new PaginatedResult<T[]>();

    let params = new HttpParams();

    if (page != null && itemsPerPage != null) {
      params = params.append('pageNumber', page);
      params = params.append('pageSize', itemsPerPage);
    }

    if (entityParams != null) {
      params = params.append('oderBy', entityParams.orderBy);
    }

    return this.http
      .get<T[]>(this.baseUrl + entity, { observe: 'response', params })
      .pipe(
        map(response => {
          paginatedResult.result = response.body;
          if (response.headers.get('Pagination') != null) {
            paginatedResult.pagination = JSON.parse(
              response.headers.get('Pagination')
            );
          }
          paginatedResult.entityType = entity;
          return paginatedResult;
        })
      );
  }

  getEntity(id: number, entity: string): Observable<T> {
    return this.http.get<T>(this.baseUrl + entity + '/' + id);
  }
}
