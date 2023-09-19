import { gql } from 'apollo-angular';

export const RETRIEVE_ALL_USERS = gql`
  {
    users {
      id
      account
      type
      status
    }
  }
`;
