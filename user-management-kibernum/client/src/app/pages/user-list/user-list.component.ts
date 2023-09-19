import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserManagementLayoutComponent } from 'src/app/layouts';

@Component({
  selector: 'app-user-list',
  standalone: true,
  imports: [CommonModule, UserManagementLayoutComponent],
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss'],
})
export class UserListComponent {}
