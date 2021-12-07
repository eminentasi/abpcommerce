import { Component, Injector } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {
  PagedListingComponentBase,
  PagedRequestDto
} from '@shared/paged-listing-component-base';
import {
  OrderDto,
  OrdersServiceProxy,
  OrderDtoPagedResultDto
} from '@shared/service-proxies/service-proxies';
import { CreateOrderDialogComponent } from './create-order/create-order-dialog.component';
import { EditOrderDialogComponent } from './edit-order/edit-order-dialog.component';

class PagedOrdersRequestDto extends PagedRequestDto {
  keyword: string;
  isActive: boolean | null;
}

@Component({
  templateUrl: './orders.component.html',
  animations: [appModuleAnimation()]
})
export class OrdersComponent extends PagedListingComponentBase<OrderDto> {
  orders: OrderDto[] = [];
  keyword = '';
  isActive: boolean | null;
  advancedFiltersVisible = false;

  constructor(
    injector: Injector,
    private _orderService: OrdersServiceProxy,
    private _modalService: BsModalService
  ) {
    super(injector);
  }

  list(
    request: PagedOrdersRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;
    request.isActive = this.isActive;

    this._orderService
      .getAll(
        request.keyword,
        request.skipCount,
        request.maxResultCount
      )
      .pipe(
        finalize(() => {
          finishedCallback();
        })
      )
      .subscribe((result: OrderDtoPagedResultDto) => {
        this.orders = result.items;
        this.showPaging(result, pageNumber);
      });
  }

  delete(order: OrderDto): void {
    abp.message.confirm(
      this.l('OrderDeleteWarningMessage', order.id),
      undefined,
      (result: boolean) => {
        if (result) {
          this._orderService
            .delete(order.id)
            .pipe(
              finalize(() => {
                abp.notify.success(this.l('SuccessfullyDeleted'));
                this.refresh();
              })
            )
            .subscribe(() => {});
        }
      }
    );
  }

  createOrder(): void {
    this.showCreateOrEditOrderDialog();
  }

  editOrder(order: OrderDto): void {
    this.showCreateOrEditOrderDialog(order.id);
  }

  showCreateOrEditOrderDialog(id?: number): void {
    let createOrEditOrderDialog: BsModalRef;
    if (!id) {
      createOrEditOrderDialog = this._modalService.show(
        CreateOrderDialogComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditOrderDialog = this._modalService.show(
        EditOrderDialogComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );
    }

    createOrEditOrderDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }

  clearFilters(): void {
    this.keyword = '';
    this.isActive = undefined;
    this.getDataPage(1);
  }
}
