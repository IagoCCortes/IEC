import { Component, OnInit, Input } from '@angular/core';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { AuthService } from 'src/app/_services/auth.service';
import { OpenAuthModalService } from 'src/app/_services/openAuthModal.service';
import { UserMovie } from 'src/app/_models/userMovie';
import { GenericRestService } from 'src/app/_services/generic-rest.service';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.css']
})
export class CardComponent implements OnInit {
  @Input() entity: any;
  @Input() entityType: string;

  constructor(private genericRestService: GenericRestService<UserMovie>, private authService: AuthService,
              private alertify: AlertifyService, private openAuthModal: OpenAuthModalService) { }

  ngOnInit() {
  }

  addToEntityList(entityId: number) {
    if (!this.authService.loggedIn()) {
      this.openAuthModal.openModal.emit();
    } else {
      const data = {movieId: entityId, userProfileMovieStatusId: 1};
      this.genericRestService.postEntity('users/' + this.authService.decodedToken.UserProfileId + '/' + this.entityType, data)
      .subscribe(() => {
        this.alertify.success('You have added: ' + this.entity.title);
        this.entity.isInUserList = true;
        console.log(this.entity);
      }, error => {
        this.alertify.error(error);
      });
    }
  }

  removeFromEntityList(entityId: number) {
    this.genericRestService.deleteEntity('users/' + this.authService.decodedToken.UserProfileId + '/movies/' + entityId)
    .subscribe(() => {
      this.alertify.success('You have removed: ' + this.entity.title);
      this.entity.isInUserList = false;
    }, error => {
      this.alertify.error(error);
    });
  }
}
