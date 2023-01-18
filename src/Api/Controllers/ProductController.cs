using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RiskCenterStoreApi.Models;

namespace RiskCenterStoreApi.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private StoreContext sContext;
        
        public ProductController (StoreContext context)
        {
            sContext = context;
        }

        [HttpGet]
        [HttpGet("get-products")]
        public ActionResult<IEnumerable<Product>> GetProducts() {
            return this.sContext.Products.Include(p => p.Category).ToList();
        }

        [HttpGet("get-product/{productId}")]
        public ActionResult<Product> GetProduct(int productId)
        {
            return sContext.Products.Include(p => p.Category).FirstOrDefault(product => product.id == productId);
        }

        ~ProductController()
        {
            sContext.Dispose();
        }
    }
}
