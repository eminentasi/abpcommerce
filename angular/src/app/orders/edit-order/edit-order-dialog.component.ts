import {
  Component,
  Injector,
  OnInit,
  Output,
  EventEmitter
} from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { AppComponentBase } from '@shared/app-component-base';
import {
  OrdersServiceProxy,
  OrderDto
} from '@shared/service-proxies/service-proxies';
import { filter as _filter } from 'lodash-es';
import { AppOrderStatus, AppPaymentMethod } from '@shared/AppEnums';

@Component({
  templateUrl: 'edit-order-dialog.component.html'
})
export class EditOrderDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  order: OrderDto = new OrderDto();
  id: number;
  total = 0;
  AppOrderStatus = AppOrderStatus;
  AppPaymentMethod = AppPaymentMethod;

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _orderService: OrdersServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._orderService.get(this.id).subscribe((result: OrderDto) => {
      this.order = result;
      const sum = this.order.orderDetails.reduce((sum, current) => sum + current.unitPrice * current.quantity, 0);
      this.total = sum;
    });
    
  }

  save(): void {
    this.saving = true;

    this._orderService.update(this.order).subscribe(
      () => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.bsModalRef.hide();
        this.onSave.emit();
      },
      () => {
        this.saving = false;
      }
    );
  }
}
