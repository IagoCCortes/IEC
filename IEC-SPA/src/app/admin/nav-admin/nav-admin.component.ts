import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-nav-admin',
  templateUrl: './nav-admin.component.html',
  styleUrls: ['./nav-admin.component.css']
})
export class NavAdminComponent implements OnInit {
  @Output() changedToAdmin = new EventEmitter<boolean>();
  isCollapsed = true;

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
