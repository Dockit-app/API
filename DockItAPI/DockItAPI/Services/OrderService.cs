using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DockItAPI.Services
{
    public class OrderService
    {
        public void PostOrder(dynamic Order) {

            if (OrderSpacing.Get().IsOrderSpacingRequired())
            {

                DateTime orderTime = Order.SetOrderTime();
                var newOrderTime = OrderSpacing.Get().OffsetOrderTime(orderTime);

                Order.SetOrderTime(newOrderTime);

                //TODO: Add to Queue
            }

            else {
                //TODO: Send to POS API
            }
        }
    }
}
