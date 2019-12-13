import { Component, OnInit } from '@angular/core';
import { MovieService } from 'src/app/_services/movie.service';
import { Movie } from 'src/app/_models/movie';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-movie-list',
  templateUrl: './movie-list.component.html',
  styleUrls: ['./movie-list.component.css']
})
export class MovieListComponent implements OnInit {
  movies: Movie[];

  constructor(private movieService: MovieService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe( data => {
      this.movies = data.movies;
    });
  }

  // getMovies() {
  //   this.movieService.getMovies().subscribe(response => {
  //     this.movies = response;
  //   }, error => {
  //     console.log(error);
  //   });
  // }
}
