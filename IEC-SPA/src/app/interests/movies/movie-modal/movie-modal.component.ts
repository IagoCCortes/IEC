import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap';

@Component({
  selector: 'app-movie-modal',
  templateUrl: './movie-modal.component.html',
  styleUrls: ['./movie-modal.component.scss']
})
export class MovieModalComponent implements OnInit {
  @Output() updateMovie = new EventEmitter();
  stars: 0;
  title: string;
  curStatus = {returnVal: '1', displayVal: 'To Watch'};

  constructor(public bsModalRef: BsModalRef) { }

  ngOnInit() {
  }

  updateRoles() {
    // this.updateMovie.emit(this.roles);
    this.bsModalRef.hide();
  }

}
