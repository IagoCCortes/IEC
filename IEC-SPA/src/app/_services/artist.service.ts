import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Artist } from '../_models/artist';
import { Observable } from 'rxjs';
import { ArtistList } from '../_models/artist-list';

@Injectable({
  providedIn: 'root'
})
export class ArtistService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getArtists(): Observable<ArtistList[]> {
    return this.http.get<ArtistList[]>(this.baseUrl + 'artists');
  }

  getArtist(id: number): Observable<Artist> {
    return this.http.get<Artist>(this.baseUrl + 'artists/' + id);
  }

}
