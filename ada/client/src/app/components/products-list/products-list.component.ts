import { CurrencyPipe, NgFor, NgIf } from '@angular/common';
import { Component, Input, OnInit, inject, signal } from '@angular/core';
import { Router } from '@angular/router';

import { ToastrService } from 'ngx-toastr';

import { UserProfiles } from '@/enums';
import type { ILoginResponse, IProductsResponse } from '@/models';
import { ShoppingService } from '@/services';
import { loadUserInfo } from '@/utils';
import { NavbarComponent } from '../';

@Component({
  selector: 'app-products-list',
  standalone: true,
  imports: [NgFor, NgIf, CurrencyPipe, NavbarComponent],
  templateUrl: './products-list.component.html',
})
export class ProductsListComponent implements OnInit {
  @Input() products: IProductsResponse[] = [];
  @Input() showShoppingCart = true;

  private readonly _toast = inject(ToastrService);
  private readonly _shoppingSvc = inject(ShoppingService);
  private readonly _router = inject(Router);
  private userInfo = signal<ILoginResponse>({
    fullName: '',
    id: '',
    identificationNumber: '',
    userProfile: UserProfiles.SHOPPING,
  });

  ngOnInit(): void {
    const currentUser = loadUserInfo();
    if (currentUser == null) {
      this._router.navigate(['/auth', 'login']);
      return;
    }

    this.userInfo.set(currentUser);
  }

  addShopppingCart({ id, name, stock }: IProductsResponse) {
    console.log({ id });
    // realizar validaciones de stock
    if (stock === 0) {
      this._toast.error(
        `No quedan más productos en Stock`,
        'Añadir al carrito'
      );
      return;
    }

    this._shoppingSvc
      .updateShoppingCart({
        productId: id,
        quantitySold: 1,
        userId: this.userInfo().id,
      })
      .subscribe(({ errors }) => {
        if (errors && errors?.length > 0) {
          errors?.forEach(e =>
            this._toast.error(e.message, 'Añadir al carrito')
          );
          return;
        }

        // restar al stock del producto
        this.products = this.products.map(p => {
          if (p.id == id) {
            return { ...p, stock: p.stock - 1 };
          }
          return p;
        });

        this._toast.success(
          `Se ha añadido correctamente el producto: ${name}`,
          'Añadir al carrito'
        );
      });
  }
}
