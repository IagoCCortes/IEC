import { environment } from 'src/environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PaginatedResult } from '../_models/pagination';
import { map } from 'rxjs/operators';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class GenericRestService<T> {
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
      for (const entityParam of entityParams) {
        if (Array.isArray(entityParam.values)) {
          entityParam.values.forEach(element => {
            params = params.append(entityParam.param, element);
          });
        } else {
          params = params.append(entityParam.param, entityParam.values);
        }
      }
    }

    return this.http.get<T[]>(this.baseUrl + entity, { observe: 'response', params })
      .pipe(map(response => {
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

  getEntity(path: string): Observable<T> {
    return this.http.get<T>(this.baseUrl + path);
  }

  postEntity(url: string, entity: object) {
    return this.http.post(this.baseUrl + url, entity);
  }

  putEntity(url: string, entity: object) {
    return this.http.put(this.baseUrl + url, entity);
  }

  deleteEntity(url: string) {
    return this.http.delete(this.baseUrl + url);
  }
}
