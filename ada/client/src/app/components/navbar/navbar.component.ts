import { Component, OnInit, inject, signal } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { NgIf } from '@angular/common';

import { UserProfiles } from '@/enums';
import type { ILoginResponse } from '@/models';
import { loadUserInfo } from '@/utils';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [RouterLink, NgIf],
  templateUrl: './navbar.component.html',
})
export class NavbarComponent implements OnInit {
  private readonly _router = inject(Router);

  user = signal<ILoginResponse>({
    fullName: '',
    id: '',
    identificationNumber: '',
    userProfile: UserProfiles.SHOPPING,
  });

  get userIsAdmin() {
    return this.user().userProfile === UserProfiles.ADMIN;
  }

  ngOnInit(): void {
    this.verifyUserSession();
  }

  private verifyUserSession() {
    const userLoaded = loadUserInfo();

    if (userLoaded == null) {
      this._router.navigate(['auth', 'login']);
      return;
    }

    this.user.set(userLoaded);
  }
}
