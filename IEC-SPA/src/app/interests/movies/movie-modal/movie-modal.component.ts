import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap';
import { GenericRestService } from 'src/app/_services/generic-rest.service';
import { UserMovie } from 'src/app/_models/userMovie';
import { AuthService } from 'src/app/_services/auth.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { UserMovieStatusEnum } from 'src/app/_enums/userMovieStatusEnum.enum';

@Component({
  selector: 'app-movie-modal',
  templateUrl: './movie-modal.component.html',
  styleUrls: ['./movie-modal.component.scss']
})
export class MovieModalComponent implements OnInit {
  @Output() updateMovie = new EventEmitter();
  stars: number;
  id: number;
  title: string;
  userMovie: UserMovie;
  statuses = UserMovieStatusEnum;
  curStatus: string;
  isDataLoaded = false;

  constructor(
    public bsModalRef: BsModalRef,
    private genericRestService: GenericRestService<UserMovie>,
    private authService: AuthService,
    private alertify: AlertifyService
  ) {}

  ngOnInit() {
    this.genericRestService
      .getEntity(
        'users/' +
          this.authService.decodedToken.UserProfileId +
          '/movies/' +
          this.id
      )
      .subscribe(
        data => {
          this.userMovie = data;
          this.curStatus = this.statuses[this.userMovie.userProfileMovieStatusId];
          this.stars = this.userMovie.rating;
          this.isDataLoaded = true;
        },
        error => {
          this.alertify.error(error);
        }
      );
  }

  changeStatus(status: number) {
    this.userMovie.userProfileMovieStatusId = status;
    this.curStatus = this.statuses[status];
  }

  save() {
    this.genericRestService
      .putEntity(
        'users/' +
          this.authService.decodedToken.UserProfileId +
          '/movies/' +
          this.id,
          this.userMovie
      )
      .subscribe(() => {
        this.alertify.success('Changes saved');
        this.bsModalRef.hide();
      },
        error => {
          this.alertify.error(error);
        }
      );
  }
}
