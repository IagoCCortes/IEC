import { Component, OnInit } from '@angular/core';
import { Pagination, PaginatedResult } from 'src/app/_models/pagination';
import { ActivatedRoute } from '@angular/router';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { MovieList } from 'src/app/_models/movie-list';
import { ArtistList } from 'src/app/_models/artist-list';
import { GenericRestService } from 'src/app/_services/generic-rest.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {
  entityType: string;
  entities: any[];
  entityParams: any = {};
  pagination: Pagination;
  maxSize = 5;

  constructor(private moviesRestService: GenericRestService<MovieList>,
              private artistsRestService: GenericRestService<ArtistList>,
              private route: ActivatedRoute, private alertify: AlertifyService) { }

  ngOnInit() {
    this.route.data.subscribe( data => {
      this.entities = data.entities.result;
      this.pagination = data.entities.pagination;
      this.entityType = data.entities.entityType;
    });
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
