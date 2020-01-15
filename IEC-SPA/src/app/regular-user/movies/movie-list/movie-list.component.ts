import { Component, OnInit } from '@angular/core';
import { MovieService } from 'src/app/_services/movie.service';
import { ActivatedRoute } from '@angular/router';
import { MovieList } from 'src/app/_models/movie-list';
import { Pagination, PaginatedResult } from 'src/app/_models/pagination';
import { AlertifyService } from 'src/app/_services/alertify.service';

@Component({
  selector: 'app-movie-list',
  templateUrl: './movie-list.component.html',
  styleUrls: ['./movie-list.component.css']
})
export class MovieListComponent implements OnInit {
  movies: MovieList[];
  movieParams: any = {};
  pagination: Pagination;
  maxSize = 5;

  constructor(private movieService: MovieService, private route: ActivatedRoute, private alertify: AlertifyService) { }

  ngOnInit() {
    this.route.data.subscribe( data => {
      this.movies = data.movies.result;
      this.pagination = data.movies.pagination;
    });
  }

  pageChanged(event: any): void {
    this.pagination.currentPage = event.page;
    this.loadMovies();
  }

  loadMovies() {
    this.movieService.getMovies(this.pagination.currentPage, this.pagination.itemsPerPage, this.movieParams).
      subscribe((res: PaginatedResult<MovieList[]>) => {
      this.movies = res.result;
      this.pagination = res.pagination;
    }, error => {
      this.alertify.error(error);
    });
  }
}
