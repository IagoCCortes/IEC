import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';
import { User } from 'src/app/_models/user';
import { AuthService } from 'src/app/_services/auth.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { Router } from '@angular/router';
import { OpenAuthModalService } from 'src/app/_services/openAuthModal.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  @ViewChild('template', {static: false}) template: any;
  isCollapsed = true;
  modalRef: BsModalRef;
  config = {
    backdrop: true,
    ignoreBackdropClick: false
  };


  user: User;

  choice = 'Login';

  constructor(private modalService: BsModalService, public authService: AuthService,
              private alertify: AlertifyService, private router: Router,
              private openAuthModal: OpenAuthModalService) { }

  ngOnInit() {
    this.openAuthModal.openModal
    .subscribe(() => this.openModal(this.template, 'Login'));
  }

  openModal(template: TemplateRef<any>, choice: string) {
    this.choice = choice;
    this.modalRef = this.modalService.show(template, this.config);
  }

  closeModal() {
    this.modalRef.hide();
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
    this.router.navigate(['/movies']);
  }

  toggleCollapse() {
    this.isCollapsed = !this.isCollapsed;
  }
}
