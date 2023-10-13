import { Component, Input, OnInit, inject, signal } from '@angular/core';

import { ProductsListComponent } from '@/components';
import type { IProductsResponse } from '@/models';
import { ShoppingService } from '@/services';

@Component({
  selector: 'app-shopping',
  standalone: true,
  imports: [ProductsListComponent],
  templateUrl: './shopping.component.html',
})
export class ShoppingComponent implements OnInit {
  @Input() userId = '';

  private readonly _shoppingSvc = inject(ShoppingService);

  shoppingProducts = signal<IProductsResponse[]>([]);

  ngOnInit(): void {
    this.retriveShoppingProducts(this.userId);
  }

  private retriveShoppingProducts(userId: string) {
    this._shoppingSvc.retriveShoppingProducts(userId).subscribe(({ data }) => {
      const products = data['userShoppingCart'].map<IProductsResponse>(
        ({ product, quantitySold, total }) => ({
          stock: quantitySold,
          description: product.description,
          id: product.id,
          imageUrl: product.imageUrl,
          name: product.name,
          price: total,
          userProductDetails: null,
        })
      );
      this.shoppingProducts.set(products);
    });
  }
}
