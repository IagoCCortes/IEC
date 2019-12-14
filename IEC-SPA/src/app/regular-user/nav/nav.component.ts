import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  @Output() changedToAdmin = new EventEmitter<boolean>();
  isCollapsed = true;
  didVote = false;

  constructor() { }

  ngOnInit() {
  }

  changeToAdmin(admin: boolean) {
    this.changedToAdmin.emit(admin);
  }

  toggleCollapse() {
    this.isCollapsed = !this.isCollapsed;
  }
}
