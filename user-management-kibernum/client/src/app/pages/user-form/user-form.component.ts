import { NgFor } from '@angular/common';
import { Component, Input, OnInit, inject } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';

import { statusMocks, typesMocks } from 'src/app/data';
import { UserManagementLayoutComponent } from 'src/app/layouts';
import { UsersMutationsService } from 'src/app/services';

@Component({
  selector: 'app-user-form',
  standalone: true,
  imports: [NgFor, ReactiveFormsModule, UserManagementLayoutComponent],
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.scss'],
})
export class UserFormComponent implements OnInit {
  @Input() userId = '';

  private readonly router = inject(Router);
  private readonly fb = inject(FormBuilder);
  private readonly userMutationSvc = inject(UsersMutationsService);

  status = statusMocks;
  types = typesMocks;
  userForm!: FormGroup;
  title = 'Registrar Usuario';

  ngOnInit(): void {
    console.log({ userId: this.userId });
    this.validateAction();
    this.userForm = this.startUserForm();
  }

  private validateAction() {
    if (this.userId) {
      this.title = 'Actualizar Usuario';
      this.retrieveUserInfo();
    } else {
      this.title = 'Registrar Usuario';
    }
  }

  private startUserForm(): FormGroup {
    return this.fb.group({
      id: [''],
      account: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(3)]],
      type: ['Docente', Validators.required],
      status: ['Activo', [Validators.required]],
    });
  }

  private retrieveUserInfo() {
    this.userMutationSvc.retrieveUserById(this.userId).subscribe(({ data }) => {
      const { userById } = data;
      console.log({ userById });
      this.userForm.setValue({ ...userById });
    });
  }

  save(): void {
    if (this.userForm.invalid) {
      return;
    }

    console.log('Save reactive form ->', this.userForm.value);
    const userSent = { ...this.userForm.value };
    delete userSent.id;

    if (this.userId) {
      this.userMutationSvc
        .updateUser(userSent, this.userId)
        .subscribe(({ data }) => {
          if (data) this.router.navigate(['/']);

          console.log('Ocurrio un error');
        });
    } else {
      this.userMutationSvc.createUser(userSent).subscribe(({ data }) => {
        if (data) this.router.navigate(['/']);

        console.log('Ocurrio un error');
      });
    }
  }
}
