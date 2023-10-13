import { Injectable, inject } from '@angular/core';

import { Apollo } from 'apollo-angular';

import type {
  IData,
  IProductsResponse,
  IShoppingCardInput,
  IShoppingCartResponse,
  IUserShoppingCartResoponse,
  IUserShoppingDetail,
} from '@/models';
import { SHOPPING_CART, SHOPPING_PRODUCTS, USERS_SHOPPINGS } from '@/graphQL';

@Injectable({
  providedIn: 'root',
})
export class ShoppingService {
  private readonly _apollo = inject(Apollo);

  retriveShoppingProducts(userId: string) {
    return this._apollo.watchQuery<
      IData<IUserShoppingCartResoponse[]>,
      Variables
    >({
      query: SHOPPING_PRODUCTS,
      variables: { userId },
    }).valueChanges;
  }

  retrieveUserShoppingsDetail() {
    return this._apollo.watchQuery<IData<IUserShoppingDetail[]>>({
      query: USERS_SHOPPINGS,
    }).valueChanges;
  }

  updateShoppingCart(shoppingCart: IShoppingCardInput) {
    return this._apollo.mutate<
      IData<IShoppingCartResponse>,
      ShoppingCartVariable
    >({
      mutation: SHOPPING_CART,
      variables: { shoppingCartInput: shoppingCart },
      errorPolicy: 'all',
    });
  }
}

type Variables = {
  userId: string;
};

type ShoppingCartVariable = {
  shoppingCartInput: IShoppingCardInput;
};
