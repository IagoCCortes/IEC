import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { AuthService } from 'src/app/_services/auth.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { MovieList } from 'src/app/_models/movie-list';
import { UserMovieService } from 'src/app/_services/userMovie.service';
import { OpenAuthModalService } from 'src/app/_services/openAuthModal.service';

@Component({
  selector: 'app-movie-card',
  templateUrl: './movie-card.component.html',
  styleUrls: ['./movie-card.component.css']
})
export class MovieCardComponent implements OnInit {
  @Input() movie: MovieList;

  constructor(private userMovieService: UserMovieService, private authService: AuthService, 
              private alertify: AlertifyService, private openAuthModal: OpenAuthModalService) { }

  ngOnInit() {
  }

  addToMovieList(movieId: number) {
    if (!this.authService.loggedIn()) {
      this.openAuthModal.openModal.emit();
    } else {
      const data = {movieId, userProfileMovieStatusId: 1};
      this.userMovieService.addToMovieList(this.authService.decodedToken.UserProfileId, data)
      .subscribe(() => {
        this.alertify.success('You have added: ' + this.movie.title);
        this.movie.isInMovieList = true;
      }, error => {
        this.alertify.error(error);
      });
    }
  }

  removeFromMovieList(movieId: number) {
    this.userMovieService.removeFromMovieList(this.authService.decodedToken.UserProfileId, movieId)
    .subscribe(() => {
      this.alertify.success('You have removed: ' + this.movie.title);
      this.movie.isInMovieList = false;
    }, error => {
      this.alertify.error(error);
    });
  }
}
