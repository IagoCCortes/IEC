import { Component, OnInit } from '@angular/core';
import { Movie } from 'src/app/_models/movie';
import { ActivatedRoute } from '@angular/router';
import { GenericRestService } from 'src/app/_services/generic-rest.service';

@Component({
  selector: 'app-movie-detail',
  templateUrl: './movie-detail.component.html',
  styleUrls: ['./movie-detail.component.scss']
})
export class MovieDetailComponent implements OnInit {
  movie: Movie;
  runtime: string;

  constructor(private genericRestService: GenericRestService<Movie>, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe( data => {
      this.movie = data.movie;
    });

    const quotient = Math.floor(this.movie.runtime / 60);
    const remainder = this.movie.runtime % 60;

    this.runtime = quotient + 'h ' + remainder + 'm';
  }
}
