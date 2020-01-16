import { Component, OnInit } from '@angular/core';
import { Pagination, PaginatedResult } from 'src/app/_models/pagination';
import { MovieService } from 'src/app/_services/movie.service';
import { ActivatedRoute } from '@angular/router';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { MovieList } from 'src/app/_models/movie-list';
import { ArtistService } from 'src/app/_services/artist.service';
import { ArtistList } from 'src/app/_models/artist-list';

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

  constructor(private artistService: ArtistService, private movieService: MovieService,
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
      this.artistService.getEntities('artists', this.pagination.currentPage, this.pagination.itemsPerPage, this.entityParams).
      subscribe((res: PaginatedResult<ArtistList[]>) => {
        this.entities = res.result;
        this.pagination = res.pagination;
      }, error => {
        this.alertify.error(error);
      });
    } else if (this.entityType === 'movies') {
      this.movieService.getEntities('movies', this.pagination.currentPage, this.pagination.itemsPerPage, this.entityParams).
      subscribe((res: PaginatedResult<MovieList[]>) => {
        this.entities = res.result;
        this.pagination = res.pagination;
      }, error => {
        this.alertify.error(error);
      });
    }
  }
}
