import { Injectable, inject } from '@angular/core';

import { Apollo } from 'apollo-angular';
import { BehaviorSubject, type Observable } from 'rxjs';

import { IUserResponse } from '../models';
import { RETRIEVE_ALL_USERS } from '../graphQL';

@Injectable({
  providedIn: 'root',
})
export class UsersService {
  private usersSubject = new BehaviorSubject<IUserResponse[]>([]);
  private loadingSubject = new BehaviorSubject<boolean>(false);
  private readonly apollo = inject(Apollo);

  constructor() {
    this.retrieveAllUsers();
  }

  get users$(): Observable<IUserResponse[]> {
    return this.usersSubject.asObservable();
  }

  get loading$(): Observable<boolean> {
    return this.loadingSubject.asObservable();
  }

  private retrieveAllUsers() {
    this.apollo
      .watchQuery({
        query: RETRIEVE_ALL_USERS,
      })
      .valueChanges.subscribe(({ data, loading }: any) => {
        this.usersSubject.next(data.users);
        this.loadingSubject.next(loading);
      });
  }
}
