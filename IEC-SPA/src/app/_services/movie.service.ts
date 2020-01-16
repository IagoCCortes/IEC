import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MovieList } from '../_models/movie-list';
import { AbstractRestService } from './abstract-rest-service';

@Injectable()
export class MovieService extends AbstractRestService<MovieList> {

    constructor(http: HttpClient) {
      super(http);
    }
}
