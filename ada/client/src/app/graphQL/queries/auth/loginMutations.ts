import { gql } from 'apollo-angular';

export const LOGIN = gql`
  mutation Login($credential: LoginInputTypeInput!) {
    login(loginInputType: $credential) {
      id
      fullName
      identificationNumber
      userProfile
    }
  }
`;
