import { Component, OnInit, inject, signal } from '@angular/core';
import { CurrencyPipe, NgFor } from '@angular/common';

import { ShoppingService } from '@/services';
import type { IUserShoppingDetail } from '@/models';

@Component({
  selector: 'app-users-shopping',
  standalone: true,
  imports: [NgFor, CurrencyPipe],
  templateUrl: './users-shopping.component.html',
  styleUrls: ['./users-shopping.component.scss'],
})
export class UsersShoppingComponent implements OnInit {
  private readonly _shoppingSvc = inject(ShoppingService);

  shoppingDetails = signal<IUserShoppingDetail[]>([]);

  ngOnInit(): void {
    this.retrieveUserShoppingsDetail();
  }

  private retrieveUserShoppingsDetail() {
    this._shoppingSvc.retrieveUserShoppingsDetail().subscribe(({ data }) => {
      console.log({ data: data['usersShopping'] });
      this.shoppingDetails.set(data['usersShopping']);
    });
  }
}
