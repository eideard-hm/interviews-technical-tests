import { Injectable, inject } from '@angular/core';

import { Apollo } from 'apollo-angular';

import { IUserCreateInput, IUserResponse } from '../models';
import {
  CREATE_USER_MUTATION,
  RETRIEVE_USER_BY_ID,
  UPDATE_USER_MUTATION,
} from '../graphQL';

@Injectable({
  providedIn: 'root',
})
export class UsersMutationsService {
  private readonly apollo = inject(Apollo);

  createUser(input: IUserCreateInput) {
    return this.apollo.mutate<IUserResponse>({
      mutation: CREATE_USER_MUTATION,
      variables: {
        userInput: input,
      },
    });
  }

  updateUser(input: IUserCreateInput, id: string) {
    return this.apollo.mutate<IUserResponse>({
      mutation: UPDATE_USER_MUTATION,
      variables: {
        userInput: input,
        id,
      },
    });
  }

  retrieveUserById(userId: string) {
    return this.apollo.watchQuery<{ userById: IUserResponse }>({
      variables: { id: userId },
      query: RETRIEVE_USER_BY_ID,
    }).valueChanges;
  }
}
