import { Component, DestroyRef, OnInit, inject, signal } from '@angular/core';
import { CurrencyPipe, NgFor } from '@angular/common';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';

import type { IProductsResponse } from '@/models';
import { ProductService } from '@/services';

@Component({
  selector: 'app-list',
  standalone: true,
  imports: [NgFor, CurrencyPipe],
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss'],
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
