using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
