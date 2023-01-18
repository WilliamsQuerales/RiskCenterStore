using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RiskCenterStoreApi.Models;

namespace RiskCenterStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private StoreContext sContext;

        public ProductController (StoreContext context)
        {
            this.sContext = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts() {
            return sContext.Products.ToList();
        }

        ~ProductController()
        {
            this.sContext.Dispose();
        }
    }
}
