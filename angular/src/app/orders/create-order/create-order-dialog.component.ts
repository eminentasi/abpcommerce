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
  BillingAddressDto,
  OrderDto,
  OrdersServiceProxy,
  ShippingAddressDto
} from '@shared/service-proxies/service-proxies';
import { filter as _filter } from 'lodash-es';
import { AppOrderStatus } from '@shared/AppEnums';

@Component({
  templateUrl: 'create-order-dialog.component.html'
})
export class CreateOrderDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  order: OrderDto = new OrderDto();
  AppOrderStatus = AppOrderStatus;

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _orderService: OrdersServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this.order.shippingAddress = new ShippingAddressDto();
    this.order.billingAddress = new BillingAddressDto();
  }

  save(): void {
    this.saving = true;
    
    this._orderService.create(this.order).subscribe(
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
