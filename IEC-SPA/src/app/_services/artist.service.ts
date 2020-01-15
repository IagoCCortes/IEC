import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { HttpClient, HttpParams } from "@angular/common/http";
import { Artist } from "../_models/artist";
import { Observable } from "rxjs";
import { ArtistList } from "../_models/artist-list";
import { PaginatedResult } from "../_models/pagination";
import { map } from "rxjs/operators";

@Injectable({
  providedIn: "root"
})
export class ArtistService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getArtists(
    page?,
    itemsPerPage?,
    artistParams?
  ): Observable<PaginatedResult<ArtistList[]>> {
    const paginatedResult: PaginatedResult<ArtistList[]> = new PaginatedResult<
      ArtistList[]
    >();

    let params = new HttpParams();

    if (page != null && itemsPerPage != null) {
      params = params.append("pageNumber", page);
      params = params.append("pageSize", itemsPerPage);
    }

    if (artistParams != null) {
      params = params.append("oderBy", artistParams.orderBy);
    }

    return this.http
      .get<ArtistList[]>(this.baseUrl + "artists", {
        observe: "response",
        params
      })
      .pipe(
        map(response => {
          paginatedResult.result = response.body;
          if (response.headers.get("Pagination") != null) {
            paginatedResult.pagination = JSON.parse(
              response.headers.get("Pagination")
            );
          }
          return paginatedResult;
        })
      );
  }

  getArtist(id: number): Observable<Artist> {
    return this.http.get<Artist>(this.baseUrl + "artists/" + id);
  }
}
