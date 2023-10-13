import { gql } from 'apollo-angular';

export const SHOPPING_PRODUCTS = gql`
  query userShoppingCart($userId: UUID!) {
    userShoppingCart(userId: $userId) {
      quantitySold
      total
      product {
        id
        name
        description
        imageUrl
      }
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
