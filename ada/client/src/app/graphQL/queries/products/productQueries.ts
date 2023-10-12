import { gql } from 'apollo-angular';

export const ALL_PRODUCTS = gql`
  query retrieveAllProducts {
    allProducts {
      id
      name
      stock
      description
      imageUrl
      price
      userProductDetails {
        userId
      }
    }
  }
`;
