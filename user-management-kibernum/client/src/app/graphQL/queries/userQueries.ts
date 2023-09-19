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

export const RETRIEVE_USER_BY_ID = gql`
  query RetrieveUserById($id: UUID!) {
    userById(userId: $id) {
      id
      account
      type
      status
      password
    }
  }
`;

export const CREATE_USER_MUTATION = gql`
  mutation CreateUser($userInput: UserInputTypeInput!) {
    createUser(userInput: $userInput) {
      id
      account
      type
      status
    }
  }
`;

export const UPDATE_USER_MUTATION = gql`
  mutation UpdateUser($userInput: UserInputTypeInput!, $id: UUID!) {
    updateUser(id: $id, userInput: $userInput) {
      id
      account
      type
      status
    }
  }
`;
