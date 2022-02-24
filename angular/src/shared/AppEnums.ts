import { OrderStatus, PaymentMethod, TenantAvailabilityState } from '@shared/service-proxies/service-proxies';


export class AppTenantAvailabilityState {
    static Available: number = TenantAvailabilityState._1;
    static InActive: number = TenantAvailabilityState._2;
    static NotFound: number = TenantAvailabilityState._3;
}

export class AppOrderStatus {
    static Pending: number = OrderStatus._0;
    static Processing: number = OrderStatus._1;
    static Shipping: number = OrderStatus._2;
    static Completed: number = OrderStatus._3;
    static Returned: number = OrderStatus._4;
    static getName(val: OrderStatus) {
        switch (val) {
            case OrderStatus._0:
                return 'Pending';
            case OrderStatus._1:
                return 'Processing';
            case OrderStatus._2:
                return 'Shipping';
            case OrderStatus._3:
                return 'Completed';
            case OrderStatus._4:
                return 'Returned';
            default:
                return '';
        }
    };
}

export class AppPaymentMethod {
    static Transfer: number = PaymentMethod._0;
    static CreditCard: number = PaymentMethod._1;
    static getName(val: PaymentMethod) {
        switch (val) {
            case PaymentMethod._0:
                return 'Transfer';
            case PaymentMethod._1:
                return 'CreditCard';
            default:
                return '';
        }
    };
}