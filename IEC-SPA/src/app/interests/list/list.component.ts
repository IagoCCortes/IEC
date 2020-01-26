import { Component, OnInit } from '@angular/core';
import { Pagination, PaginatedResult } from 'src/app/_models/pagination';
import { ActivatedRoute } from '@angular/router';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { MovieList } from 'src/app/_models/movie-list';
import { ArtistList } from 'src/app/_models/artist-list';
import { GenericRestService } from 'src/app/_services/generic-rest.service';
import { MovieGenres } from 'src/app/_enums/movie-genres.enum';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {
  entityType: string;
  entities: any[];
  entityParams: any = {};
  pagination: Pagination;
  maxSize = 5;
  genres: any;
  genreKeys: any;

  constructor(private moviesRestService: GenericRestService<MovieList>,
              private artistsRestService: GenericRestService<ArtistList>,
              private route: ActivatedRoute, private alertify: AlertifyService) { }

  ngOnInit() {
    this.route.data.subscribe( data => {
      this.entities = data.entities.result;
      this.pagination = data.entities.pagination;
      this.entityType = data.entities.entityType;
    });

    if (this.entityType === 'movies') {
      this.genres = MovieGenres;
      this.genreKeys = Object.keys(MovieGenres).filter(key => isNaN(Number(MovieGenres[key])));
      // index 0 - Genres
      this.entityParams = [{param: 'orderBy', values: ''},
                           {param: 'genreIds', values: []}];
    } else if (this.entityType === 'artists') {
      this.entityParams = [{param: 'orderBy', values: ''}];
    }
  }

  orderByChanged(orderBy: string) {
    this.entityParams[0].values = orderBy;
    this.loadEntities();
  }

  genresChanged(genreId: number): void {
    if (!this.entityParams[1].values.includes(genreId)) {
      this.entityParams[1].values.push(genreId);
    } else {
      const index = this.entityParams[1].values.indexOf(genreId);
      if (index > -1) {
        this.entityParams[1].values.splice(index, 1);
      }
    }
    this.loadEntities();
  }

  pageChanged(event: any): void {
    this.pagination.currentPage = event.page;
    this.loadEntities();
  }

  loadEntities() {
    if (this.entityType === 'artists') {
      this.artistsRestService.getEntities('artists', this.pagination.currentPage, this.pagination.itemsPerPage, this.entityParams).
      subscribe((res: PaginatedResult<ArtistList[]>) => {
        this.entities = res.result;
        this.pagination = res.pagination;
      }, error => {
        this.alertify.error(error);
      });
    } else if (this.entityType === 'movies') {
      this.moviesRestService.getEntities('movies', this.pagination.currentPage, this.pagination.itemsPerPage, this.entityParams).
      subscribe((res: PaginatedResult<MovieList[]>) => {
        this.entities = res.result;
        this.pagination = res.pagination;
      }, error => {
        this.alertify.error(error);
      });
    }
  }
}
