import { Component, OnInit } from '@angular/core';
import { Movie } from 'src/app/_models/movie';
import { ActivatedRoute } from '@angular/router';
import { GenericRestService } from 'src/app/_services/generic-rest.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { AuthService } from 'src/app/_services/auth.service';
import { OpenAuthModalService } from 'src/app/_services/openAuthModal.service';
import { BsModalService, BsModalRef } from 'ngx-bootstrap';
import { MovieModalComponent } from '../movie-modal/movie-modal.component';

@Component({
  selector: 'app-movie-detail',
  templateUrl: './movie-detail.component.html',
  styleUrls: ['./movie-detail.component.scss']
})
export class MovieDetailComponent implements OnInit {
  movie: Movie;
  runtime: string;
  infoFlag = false;
  bsModalRef: BsModalRef;

  constructor(private genericRestService: GenericRestService<Movie>, private route: ActivatedRoute,
              private authService: AuthService, private alertify: AlertifyService,
              private openAuthModal: OpenAuthModalService, private modalService: BsModalService) { }

  ngOnInit() {
    this.route.data.subscribe( data => {
      this.movie = data.movie;
    });

    const quotient = Math.floor(this.movie.runtime / 60);
    const remainder = this.movie.runtime % 60;

    this.runtime = quotient + 'h ' + remainder + 'm';
  }

  // action 1: add to watchlist
  // action 2: favorite
  checkBeforeAction(entityId: number, action: number) {
    if (!this.authService.loggedIn()) {
      this.openAuthModal.openModal();
      this.openAuthModal.logged.subscribe(() => {
        this.addToEntityList(entityId);
      });
    } else {
      if (action === 1) {
        this.addToEntityList(entityId);
      } else {
        this.toggleFavorite(entityId);
      }
    }
  }

  addToEntityList(entityId: number) {
    const data = {userProfileMovieStatusId: 1};
    this.genericRestService
    .postEntity('users/' + this.authService.decodedToken.UserProfileId + '/movies/' + this.movie.id, data)
    .subscribe(() => {
      this.alertify.success('You have added: ' + this.movie.title);
      this.movie.isInUserList = true;
    }, error => {
      this.alertify.error(error);
    });
  }

  toggleFavorite(entityId: number) {
    this.genericRestService
    .putEntity('users/' + this.authService.decodedToken.UserProfileId + '/movies/' + this.movie.id + '/favorite', {})
    .subscribe(() => {
      if (this.movie.isFavorited) {
        this.alertify.success('You have unfavorited: ' + this.movie.title);
        this.movie.isFavorited = false;
      } else {
        this.alertify.success('You have favorited: ' + this.movie.title);
        this.movie.isInUserList = true;
        this.movie.isFavorited = true;
      }
    }, error => {
      this.alertify.error(error);
    });
  }

  editRolesModal() {
    const initialState = {
      id: this.movie.id,
      title: this.movie.title
    };
    this.bsModalRef = this.modalService.show(MovieModalComponent, {initialState});
  }
}
