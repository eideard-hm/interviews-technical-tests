import { Component, OnDestroy } from '@angular/core';

import { Subject } from 'rxjs';

@Component({
  standalone: true,
  template: '',
})
export class AutoUnsubcribeComponent implements OnDestroy {
  protected destroyed$ = new Subject<void>();

  ngOnDestroy(): void {
    this.destroyed$.complete();
    this.destroyed$.next();
  }
}
