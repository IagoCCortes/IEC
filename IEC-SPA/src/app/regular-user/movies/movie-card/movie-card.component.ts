import { Component, OnInit, Input } from '@angular/core';
import { Movie } from 'src/app/_models/movie';
import { UserService } from 'src/app/_services/user.service';
import { AuthService } from 'src/app/_services/auth.service';
import { AlertifyService } from 'src/app/_services/alertify.service';

@Component({
  selector: 'app-movie-card',
  templateUrl: './movie-card.component.html',
  styleUrls: ['./movie-card.component.css']
})
export class MovieCardComponent implements OnInit {
  @Input() movie: Movie;

  constructor(private userService: UserService, private authService: AuthService, private alertify: AlertifyService) { }

  ngOnInit() {
  }

  addToMovieList(movieId: number) {
    const data = {movieId, userMovieStatusId: 1};
    this.userService.addToMovieList(this.authService.decodedToken.UserProfileId, data)
    .subscribe(() => {
      this.alertify.success('You have added: ' + this.movie.title);
    }, error => {
      this.alertify.error(error);
    });
  }
}
