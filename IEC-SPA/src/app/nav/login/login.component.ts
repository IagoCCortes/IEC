import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { AuthService } from 'src/app/_services/auth.service';
import { User } from 'src/app/_models/user';
import { AlertifyService } from 'src/app/_services/alertify.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  @Output() userChange = new EventEmitter<User>();
  @Output() closeModal = new EventEmitter();
  loginForm: FormGroup;

  constructor(private authService: AuthService, private fb: FormBuilder, private alertify: AlertifyService) { }

  ngOnInit() {
    this.createLoginForm();
  }

  createLoginForm() {
    this.loginForm = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  login() {
    if (this.loginForm.valid) {
      const user = Object.assign({}, this.loginForm.value);
      this.userChange.emit(user);
      this.authService.login(user).subscribe(() => {
        this.alertify.success('Logged in successfully');
      }, error => {
          this.alertify.error(error);
          console.log(error);
      }, () => {
        this.closeModal.emit();
      });
    }
  }

}
