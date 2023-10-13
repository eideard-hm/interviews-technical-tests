import { Component, DestroyRef, OnInit, inject, signal } from '@angular/core';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';

import { ProductsListComponent } from '@/components';
import type { IProductsResponse } from '@/models';
import { ProductService } from '@/services';

@Component({
  selector: 'app-list',
  standalone: true,
  imports: [ProductsListComponent],
  templateUrl: './list.component.html',
})
export class ListComponent implements OnInit {
  private readonly _productSvc = inject(ProductService);
  private readonly _destroyRef = inject(DestroyRef);

  products = signal<IProductsResponse[]>([]);

  ngOnInit(): void {
    this.retrieveAllProducts();
  }

  private retrieveAllProducts() {
    this._productSvc
      .retriveProducts()
      .pipe(takeUntilDestroyed(this._destroyRef))
      .subscribe(({ data }) => {
        this.products.set(data['allProducts']);
      });
  }
}
