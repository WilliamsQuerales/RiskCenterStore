using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RiskCenterStoreApi.DataTypes.Order;
using RiskCenterStoreApi.Enumerations;
using RiskCenterStoreApi.Models;

namespace RiskCenterStoreApi.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private StoreContext sContext;
        private ProductController CProduct;

        public OrderController (StoreContext context)
        {
            this.sContext = context;
            CProduct = new ProductController (sContext);
        }

        [HttpGet("get-orders")]
        public ActionResult<IEnumerable<Order>> GetOrders() {
            return sContext.Orders.ToList();
        }

        [HttpGet("get-session-orders")]
        public ActionResult<IEnumerable<Order>> GetSessionOrders()
        {
            string sessionId = "new session" /*HttpContext.Session.Id*/;

            return sContext.Orders.Where(order => order.sessionId == sessionId).ToList();
        }

        [HttpGet("get-order/{orderId}")]
        public ActionResult<Order> GetOrder(int orderId)
        {
            return sContext.Orders.Include(o => o.Product).FirstOrDefault(order => order.id == orderId);
        }


        [HttpPost("save")]
        public ActionResult<Order> saveOrder(SaveOrderInput input){
            var order = new Order();
            // set new auto-generated code
            order.code = Guid.NewGuid().ToString("n").Substring(0, 8).ToUpper();

            order.customerName = input.customerName;
            order.customerEmail = input.customerEmail;
            order.customerMobile = input.customerMobile;

            // initial order staus is CREATED
            order.status = OrderStatus.CREATED;

            // set sessionId
            order.sessionId = "new session"/*HttpContext.Session.Id*/;

            // obtain product
            Product product = CProduct.GetProduct(input.productId).Value;
            
            if(product != null)
            {
                // set product and save in DB
                order.Product = product;
                sContext.Orders.Add(order);

                sContext.SaveChanges();

                return order;
            }
            
            return null;
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
            this.CProduct = null;
        }
    }
}
