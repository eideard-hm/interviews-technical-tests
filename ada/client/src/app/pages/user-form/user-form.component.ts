import { NgFor } from '@angular/common';
import { Component, DestroyRef, OnInit, inject, signal } from '@angular/core';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

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
  private readonly router = inject(Router);
  private readonly fb = inject(FormBuilder);
  private readonly userMutationSvc = inject(UsersMutationsService);
  private readonly destroyRef = inject(DestroyRef);
  private readonly activatedRoute = inject(ActivatedRoute);
  private userId = signal('');

  status = signal(statusMocks);
  types = signal(typesMocks);
  userForm!: FormGroup;
  title = signal('Registrar Usuario');

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(p => {
      this.userId.set(p['userId'] || '');
      console.log({ userId: p['userId'] });

      this.userForm = this.startUserForm();
      this.validateAction();
    });
  }

  private validateAction() {
    if (this.userId()) {
      this.title.set('Actualizar Usuario');
      this.retrieveUserInfo();
    } else {
      this.title.set('Registrar Usuario');
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
    this.userMutationSvc
      .retrieveUserById(this.userId())
      .pipe(takeUntilDestroyed(this.destroyRef))
      .subscribe(({ data }) => {
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

    if (this.userId()) {
      this.userMutationSvc
        .updateUser(userSent, this.userId())
        .subscribe(({ data }) => {
          if (data) this.router.navigate(['/']);

          console.log('Ocurrio un error');
        });
    } else {
      this.userMutationSvc
        .createUser(userSent)
        .subscribe(({ data, errors }) => {
          if (data) this.router.navigate(['/']);
          else {
            console.error({ errors });
            console.log('Ocurrio un error');
          }
        });
    }
  }
}
