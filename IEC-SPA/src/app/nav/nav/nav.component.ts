import { Component, OnInit } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';
import { User } from 'src/app/_models/user';
import { AuthService } from 'src/app/_services/auth.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { Router } from '@angular/router';
import { LogRegModalComponent } from '../logReg-modal/logReg-modal.component';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  isCollapsed = true;
  modalRef: BsModalRef;
  config = {
    backdrop: true,
    ignoreBackdropClick: false
  };

  user: User;

  choice = 'Login';

  constructor(private modalService: BsModalService, public authService: AuthService,
              private alertify: AlertifyService, private router: Router) { }

  ngOnInit() {
  }

  openModal(choice: string) {
    const initialState = { choice };
    this.choice = choice;
    this.modalRef = this.modalService.show(LogRegModalComponent, {initialState});
  }

  loggedIn() {
    return this.authService.loggedIn();
  }

  logout() {
    localStorage.removeItem('token');
    localStorage.removeItem('user');
    this.authService.decodedToken = null;
    this.authService.currentUser = null;
    this.alertify.message('Logged out');
    this.router.navigate(['']);
  }

  toggleCollapse() {
    this.isCollapsed = !this.isCollapsed;
  }
}
