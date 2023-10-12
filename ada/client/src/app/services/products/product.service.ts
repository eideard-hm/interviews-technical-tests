import { Injectable, inject } from '@angular/core';

import { Apollo } from 'apollo-angular';

import { ALL_PRODUCTS } from '@/graphQL';
import type { IData, IProductsResponse } from '@/models';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  private readonly _apollo = inject(Apollo);

  retriveProducts() {
    return this._apollo.watchQuery<IData<IProductsResponse[]>>({
      query: ALL_PRODUCTS,
    }).valueChanges;
  }
}
