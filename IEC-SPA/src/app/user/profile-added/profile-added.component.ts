import { Component, OnInit, Input } from '@angular/core';
import { GenericRestService } from 'src/app/_services/generic-rest.service';
import { UserMovie } from 'src/app/_models/userMovie';
import { AlertifyService } from 'src/app/_services/alertify.service';

@Component({
  selector: 'app-profile-added',
  templateUrl: './profile-added.component.html',
  styleUrls: ['./profile-added.component.scss']
})
export class ProfileAddedComponent implements OnInit {
  @Input() userId: number;
  movies: UserMovie[];

  constructor(private genericRestService: GenericRestService<UserMovie[]>, private alertify: AlertifyService) { }

  ngOnInit() {
    this.genericRestService.getEntity('users/' + this.userId + '/movies')
        .subscribe((data: any) => { this.movies = data.movies; }, error => {
          this.alertify.error(error);
        });
  }

}
