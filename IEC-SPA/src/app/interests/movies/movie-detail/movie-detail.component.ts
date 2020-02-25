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

  checkBeforeAddingToList(entityId: number) {
    if (!this.authService.loggedIn()) {
      this.openAuthModal.openModal();
      this.openAuthModal.logged.subscribe(() => {
        this.addToEntityList(entityId);
      });
    } else {
      this.addToEntityList(entityId);
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

  removeFromEntityList(entityId: number) {
    this.genericRestService
    .deleteEntity('users/' + this.authService.decodedToken.UserProfileId + '/movies/' + entityId)
    .subscribe(() => {
      this.alertify.success('You have removed: ' + this.movie.title);
      this.movie.isInUserList = false;
    }, error => {
      this.alertify.error(error);
    });
  }

  editRolesModal() {
    const initialState = {
      title: this.movie.title
    };
    this.bsModalRef = this.modalService.show(MovieModalComponent, {initialState});
    // this.bsModalRef.content.updateSelectedRoles.subscribe((values) => {
    //   const rolesToUpdate = {
    //     roleNames: [...values.filter(el => el.checked === true).map(el => el.name)]
    //   };
    //   if (rolesToUpdate) {
    //     this.genericRestService.postEntity('admin/editRoles/' + user.userName, {roleNames: rolesToUpdate.roleNames})
    //     .subscribe(() => {
    //       user.roles = [...rolesToUpdate.roleNames];
    //     }, error => this.alertify.error(error));
    //   }
    // });
  }
}
