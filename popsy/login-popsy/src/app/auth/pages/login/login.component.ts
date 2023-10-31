import { NgIf } from '@angular/common';
import { Component, OnInit, inject } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
  type AbstractControl,
} from '@angular/forms';

import { LoginService } from '../../services/login.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [ReactiveFormsModule, NgIf],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  private readonly _fb = inject(FormBuilder);
  private readonly _loginSvc = inject(LoginService);

  loginForm!: FormGroup;

  get loginFormControls(): { [key: string]: AbstractControl } {
    return this.loginForm.controls;
  }

  ngOnInit(): void {
    this.loginForm = this.createForm();
  }

  private createForm(): FormGroup {
    return this._fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
    });
  }

  validateLogin() {
    console.log('We there validate the login ', this.loginForm.value);
    if (!this.loginForm.valid) return;

    // send the credencials to the API
    this._loginSvc.login(this.loginForm.value).subscribe();
  }
}
