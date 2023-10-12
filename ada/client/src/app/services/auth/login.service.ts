import { Injectable, inject } from '@angular/core';

import { Apollo } from 'apollo-angular';

import { LOGIN } from '@graphQL';
import type { IData, ILogin, ILoginResponse } from '@models';

@Injectable({
  providedIn: 'root',
})
export class LoginService {
  private readonly apollo = inject(Apollo);

  login(login: ILogin) {
    return this.apollo.mutate<IData<ILoginResponse>, Variables>({
      mutation: LOGIN,
      variables: {
        credential: login,
      },
      errorPolicy: 'all',
    });
  }
}

type Variables = {
  credential: ILogin;
};
