import { Component, OnInit } from '@angular/core';
import { GenericRestService } from 'src/app/_services/generic-rest.service';
import { UserMovie } from 'src/app/_models/userMovie';

@Component({
  selector: 'app-profile-added',
  templateUrl: './profile-added.component.html',
  styleUrls: ['./profile-added.component.scss']
})
export class ProfileAddedComponent implements OnInit {

  constructor(genericRestService: GenericRestService<UserMovie[]>) { }

  ngOnInit() {
  }

}
