import { AsyncPipe, NgFor, NgIf } from '@angular/common';
import { Component, OnInit, inject } from '@angular/core';

import { type Observable } from 'rxjs';

import { UserManagementLayoutComponent } from 'src/app/layouts';
import { IUserResponse } from 'src/app/models';
import { UsersService } from 'src/app/services';

@Component({
  selector: 'app-user-list',
  standalone: true,
  imports: [NgIf, AsyncPipe, NgFor, UserManagementLayoutComponent],
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss'],
})
export class UserListComponent implements OnInit {
  private readonly userSvc = inject(UsersService);

  users$!: Observable<IUserResponse[]>;
  loading$!: Observable<boolean>;

  ngOnInit(): void {
    this.retriveUsers();
    this.loading();
  }

  private retriveUsers() {
    this.users$ = this.userSvc.users$;
  }

  private loading() {
    this.loading$ = this.userSvc.loading$;
  }
}
