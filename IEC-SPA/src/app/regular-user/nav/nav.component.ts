import { Component, OnInit, Output, EventEmitter, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { User } from 'src/app/_models/user';
import { AuthService } from 'src/app/_services/auth.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  // @Output() changedToAdmin = new EventEmitter<boolean>();
  isCollapsed = true;
  modalRef: BsModalRef;
  config = {
    backdrop: true,
    ignoreBackdropClick: false
  };

  user: User;

  registerForm: FormGroup;
  loginForm: FormGroup;

  choice = 'Login';

  constructor(private modalService: BsModalService,
              private fb: FormBuilder,
              private authService: AuthService,
              private alertify: AlertifyService,
              private router: Router) { }

  ngOnInit() {
    this.createRegisterForm();
    this.createLoginForm();
  }

  // changeToAdmin(admin: boolean) {
  //   this.changedToAdmin.emit(admin);
  // }

  openModal(template: TemplateRef<any>, choice: string) {
    this.choice = choice;
    this.modalRef = this.modalService.show(template, this.config);
  }

  createRegisterForm() {
    this.registerForm = this.fb.group({
      username: ['', [Validators.required, Validators.minLength(6), Validators.maxLength(15)]],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(16)]],
      confirmPassword: ['', Validators.required]
    }, {validator: this.passwordMatchValidator});
  }

  createLoginForm() {
    this.loginForm = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  passwordMatchValidator(g: FormGroup) {
    return g.get('password').value === g.get('confirmPassword').value ? null : {mismatch: true};
  }

  register() {
    if (this.registerForm.valid) {
      this.user = Object.assign({}, this.registerForm.value);
      this.authService.register(this.user).subscribe(() => {
        this.alertify.success('Registered successfully');
      }, error => {
          this.alertify.error(error);
      }, () => {
          this.authService.login(this.user).subscribe(() => {
          // this.router.navigate(['/movies']);
        });
      });
    }
  }

  login() {
    if (this.loginForm.valid) {
      this.user = Object.assign({}, this.loginForm.value);
      this.authService.login(this.user).subscribe(() => {
        this.alertify.success('Logged in successfully');
      }, error => {
          this.alertify.error(error);
          console.log(error);
      }, () => {
        this.modalRef.hide();
        // this.router.navigate(['/movies']);
      });
    }
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
