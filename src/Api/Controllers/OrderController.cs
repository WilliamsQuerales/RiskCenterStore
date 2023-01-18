using Microsoft.AspNetCore.Mvc;
using RiskCenterStoreApi.Enumerations;
using RiskCenterStoreApi.Models;

namespace RiskCenterStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private StoreContext sContext;

        public OrderController (StoreContext context)
        {
            this.sContext = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Order>> GetOrders() {
            return sContext.Orders.ToList();
        }

        [HttpPost]
        public ActionResult<Order> saveOrder(Order input){
            var order = new Order();
            order.code = Guid.NewGuid().ToString("n").Substring(0, 8).ToUpper();

            order.customerName = input.customerName;
            order.customerEmail = input.customerEmail;
            order.customerMobile = input.customerMobile;

            var result = sContext.Orders.Add(order);

            sContext.SaveChanges();

            return order;
        }
        internal OrderStatus ChangeStatusOrder ( int orderId, OrderStatus newStatus)
        {
            var order = this.sContext.Orders.FirstOrDefault(order => order.id == orderId);

            if(order != null)
            {
                order.status = newStatus;
                order.updatedAt = DateTime.Now;

                sContext.SaveChanges();
            }

            return newStatus;
        }
        ~OrderController()
        {
            this.sContext.Dispose();
        }
    }
}
