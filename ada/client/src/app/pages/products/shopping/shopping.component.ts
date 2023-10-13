import { Component, Input, OnInit, inject, signal } from '@angular/core';

import { ProductsListComponent } from '@/components';
import type { IProductsResponse } from '@/models';
import { ShoppingService } from '@/services';

@Component({
  selector: 'app-shopping',
  standalone: true,
  imports: [ProductsListComponent],
  templateUrl: './shopping.component.html',
  styleUrls: ['./shopping.component.scss'],
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
      this.shoppingProducts.set(data['userShopping']);
    });
  }
}
