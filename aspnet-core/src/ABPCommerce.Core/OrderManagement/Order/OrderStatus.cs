namespace ABPCommerce.OrderManagement.Order
{
    public enum OrderStatus : byte
    {
        Pending,
        Processing,
        Shipping,
        Completed,
        Returned
    }
}
