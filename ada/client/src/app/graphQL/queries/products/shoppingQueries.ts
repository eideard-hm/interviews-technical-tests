import { gql } from 'apollo-angular';

export const SHOPPING_PRODUCTS = gql`
  query userShopping($userId: UUID!) {
    userShopping(userId: $userId) {
      id
      name
      stock
      description
      imageUrl
      price
    }
  }
`;

export const USERS_SHOPPINGS = gql`
  query usersShopping {
    usersShopping {
      unitPrice
      quantitySold
      total
      product {
        name
      }
      user {
        fullName
        identificationNumber
      }
    }
  }
`;
