import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'IEC-SPA';
  admin = false;

  onChangedToAdmin(admin: boolean) {
    this.admin = admin;
  }
}
