import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthService } from 'src/app/_services/auth.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { User } from 'src/app/_models/user';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  @Output() userChange = new EventEmitter<User>();
  @Output() closeModal = new EventEmitter();
  registerForm: FormGroup;

  constructor(private fb: FormBuilder, private authService: AuthService, private alertify: AlertifyService) { }

  ngOnInit() {
    this.createRegisterForm();
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
      this.userChange.emit(user);
      this.authService.register(user).subscribe(() => {
        this.alertify.success('Registered successfully');
      }, error => {
          this.alertify.error(error);
      }, () => {
          this.authService.login(user).subscribe(() => {
            this.closeModal.emit();
        });
      });
    }
  }
}
