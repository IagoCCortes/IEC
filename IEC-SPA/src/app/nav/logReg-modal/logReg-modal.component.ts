import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { AuthService } from 'src/app/_services/auth.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { BsModalRef } from 'ngx-bootstrap';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './logReg-modal.component.html',
  styleUrls: ['./logReg-modal.component.scss']
})
export class LogRegModalComponent implements OnInit {
  @Output() logged = new EventEmitter();
  registerForm: FormGroup;
  loginForm: FormGroup;
  choice: string;

  constructor(private authService: AuthService, private fb: FormBuilder,
              private alertify: AlertifyService, public bsModalRef: BsModalRef,
              private router: Router) { }

  ngOnInit() {
    this.createRegisterForm();
    this.createLoginForm();
  }

  changeChoice(choice: string) {
    this.choice = choice;
  }

  createRegisterForm() {
    this.registerForm = this.fb.group({
      username: ['', [Validators.required, Validators.minLength(6), Validators.maxLength(15)]],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(16)]],
      confirmPassword: ['', Validators.required]
    }, {validator: this.passwordMatchValidator});
  }

  passwordMatchValidator(g: FormGroup) {
    return g.get('password').value === g.get('confirmPassword').value ? null : {mismatch: true};
  }

  register() {
    if (this.registerForm.valid) {
      const user = Object.assign({}, this.registerForm.value);
      this.authService.register(user).subscribe(() => {
        this.alertify.success('Registered successfully');
      }, error => {
          this.alertify.error(error);
      }, () => {
          this.authService.login(user).subscribe(() => {
            this.logged.emit();
            this.bsModalRef.hide();
            this.router.navigate(['']);
        });
      });
    }
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
      this.authService.login(user).subscribe(() => {
        this.alertify.success('Logged in successfully');
        this.logged.emit();
      }, error => {
          this.alertify.error(error);
          console.log(error);
      }, () => {
        this.bsModalRef.hide();
        this.router.navigate(['']);
      });
    }
  }

}
