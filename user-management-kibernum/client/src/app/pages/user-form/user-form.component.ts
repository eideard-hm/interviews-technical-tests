import { Component, OnInit, inject } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';

import { UserManagementLayoutComponent } from 'src/app/layouts';

@Component({
  selector: 'app-user-form',
  standalone: true,
  imports: [ReactiveFormsModule, UserManagementLayoutComponent],
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.scss'],
})
export class UserFormComponent implements OnInit {
  private readonly fb = inject(FormBuilder);

  userForm!: FormGroup;

  ngOnInit(): void {
    this.userForm = this.startUserForm();
  }

  private startUserForm(): FormGroup {
    return this.fb.group({
      account: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(3)]],
      type: [null, Validators.required],
      status: [null, [Validators.required]],
    });
  }

  save(): void {
    if (this.userForm.invalid) {
      return;
    }
    console.log('Save reactive form ->', this.userForm.value);
  }
}
