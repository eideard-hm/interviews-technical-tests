import { gql } from 'apollo-angular';

export const SHOPPING_CART = gql`
  mutation updateStock($shoppingCartInput: ShoppingCartInputTypeInput!) {
    addProductToShoppingCart(shoppingCartInput: $shoppingCartInput) {
      productId
      userId
    }
  }
`;
