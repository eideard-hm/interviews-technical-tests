import { NgFor, NgIf } from '@angular/common';
import { Component, OnInit, inject, signal } from '@angular/core';
import {
  FormBuilder,
  ReactiveFormsModule,
  Validators,
  type AbstractControl,
  type FormGroup,
} from '@angular/forms';
import { Router } from '@angular/router';

import { type GraphQLError } from 'graphql';

import { LoginService } from '@services';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [ReactiveFormsModule, NgIf, NgFor],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  private readonly _fb = inject(FormBuilder);
  private readonly _loginSvc = inject(LoginService);
  private readonly _router = inject(Router);

  loginForm!: FormGroup;
  loginResponseError = signal<readonly GraphQLError[]>([]);

  get loginFormControls(): { [key: string]: AbstractControl } {
    return this.loginForm.controls;
  }

  ngOnInit(): void {
    this.loginForm = this.startLoginForm();
  }

  private startLoginForm(): FormGroup {
    return this._fb.group({
      identificationNumber: [
        '',
        [Validators.required, Validators.maxLength(10)],
      ],
      password: ['', [Validators.required, Validators.minLength(3)]],
    });
  }

  save(): void {
    if (this.loginForm.invalid) {
      return;
    }

    this._loginSvc.login(this.loginForm.value).subscribe(({ errors, data }) => {
      if (errors && !data?.['login']) {
        this.loginResponseError.set(errors);
      }

      if (data?.['login']) {
        sessionStorage.setItem('USER_INFO', JSON.stringify(data?.['login']));
        this._router.navigate(['/products'], { replaceUrl: true });
      }
    });
  }
}
