import { Component, OnInit } from '@angular/core';
import { MovieService } from 'src/app/_services/movie.service';
import { Movie } from 'src/app/_models/movie';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-movie-detail',
  templateUrl: './movie-detail.component.html',
  styleUrls: ['./movie-detail.component.css']
})
export class MovieDetailComponent implements OnInit {
  movie: Movie;
  runtime: string;

  constructor(private movieService: MovieService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe( data => {
      this.movie = data.movie;
    });

    const quotient = Math.floor(this.movie.runtime / 60);
    const remainder = this.movie.runtime % 60;

    this.runtime = quotient + 'h ' + remainder + 'm';
  }

  // getMovie(id: number) {
  //   this.movieService.getMovie(id).subscribe(response => {
  //     this.movie = response;
  //     console.log(response);
  //   }, error => {
  //     console.log(error);
  //   });
  // }
}
