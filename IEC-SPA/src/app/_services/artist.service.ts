import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ArtistList } from '../_models/artist-list';
import { AbstractRestService } from './abstract-rest-service';

@Injectable({
  providedIn: 'root'
})
export class ArtistService extends AbstractRestService<ArtistList>{

  constructor(http: HttpClient) {
    super(http);
  }
}
