using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RiskCenterStoreApi.Models;

namespace RiskCenterStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedController : ControllerBase
    {
        private StoreContext sContext;

        public SeedController (StoreContext context)
        {
            this.sContext = context;
        }

        [HttpGet]
        public ActionResult<bool> Seed() {
            InitProductCategories();
            InitProducts();
            InitOrders();

            return true;
        }

        private void InitProductCategories()
        {
            var categories = new List<ProductCategory>
            {

            new ProductCategory() { name ="Limpieza"},
            new ProductCategory() { name ="Almacén"},
            new ProductCategory() { name ="Conservas"},
            new ProductCategory() { name ="Conservas de Verdura y Legumbres"},
            new ProductCategory() { name ="Conserva de Pescado"},
            new ProductCategory() { name ="Limpieza Pisos y Muebles"},
            new ProductCategory() { name ="Limpiadores de Piso"}
            };

            this.sContext.ProductCategories.AddRange(categories);
            this.sContext.SaveChanges();

        }

        private void InitProducts() {
            var category1 = this.sContext.ProductCategories.FirstOrDefault(cat => cat.name == "Almacén");
            var category2 = this.sContext.ProductCategories.FirstOrDefault(cat => cat.name == "Conservas");
            var category3 = this.sContext.ProductCategories.FirstOrDefault(cat => cat.name == "Limpieza");

            var products = new List<Product> {
                new Product() {name= "Pasta Al Vacío Noquis 5 Estrellas 800 G", price = 50,imageUrl = "https://tatauy.vteximg.com.br/arquivos/ids/233172/Pasta-Al-Vacio-Noquis-5-Estrellas-800-Gr-1-15273.jpg?v=637739806140970000", Category =category1 },
                new Product() { name = "Yogur Semi Descremado Parmalat Durazno Sachet 1 L", price = 100 ,imageUrl = "https://tatauy.vteximg.com.br/arquivos/ids/547832/Yogur-Semi-Descremado-Parmalat-Durazno-Sachet-1-L-1-5942.jpg?v=638024172825500000", Category = category2} ,
                new Product() { name = "Huevos Colorados Ta-Ta 15 U", price = 300,imageUrl = "https://tatauy.vteximg.com.br/arquivos/ids/244086/Huevos-Colorados-Ta-Ta-15-U-1-8972.jpg?v=637750281949100000", Category =category3 } ,
                new Product() { name = "Palta Hass Importada", price = 300,imageUrl = "https://tatauy.vteximg.com.br/arquivos/ids/217345/Palta-Hass-Importada-1-U-1-159.jpg?v=637666581701470000", Category =category1 },
                new Product() { name = "Chorizo Angus Cheddar Y Barbacoa Al Vacío 3 U 370 Gr", price = 300 ,imageUrl = "https://tatauy.vteximg.com.br/arquivos/ids/223831/Chorizo-Angus-Cheddar-Y-Barbacoa-Al-Vac-o-3-U-330-Gr-1-10883.jpg?v=637681272432870000", Category = category2} ,
                new Product() { name = "Salchicha Parrillera Rausa Al Vacío", price = 500 ,imageUrl = "https://tatauy.vteximg.com.br/arquivos/ids/217578/Salchicha-Parrillera-Rausa-Al-Vacio-1-19846.jpg?v=637666583056300000", Category = category3} ,
                new Product() { name = "Butifarra Centenario 2 U", price = 500 ,imageUrl = "https://tatauy.vteximg.com.br/arquivos/ids/222898/Butifarra-Centenario-2-U-1-18681.jpg?v=637679222271600000", Category = category1} ,
                new Product() { name = "Salamin Snack Cattivelli 1 U", price = 300 ,imageUrl = "https://tatauy.vteximg.com.br/arquivos/ids/326556/Salami-Snack-Cattivelli-1-U-1-24871.jpg?v=637838409948130000", Category = category2} ,
                new Product() { name = "Empanadas Carne Ta-Ta 3 U", price = 500 ,imageUrl = "https://tatauy.vteximg.com.br/arquivos/ids/383906/Empanadas-Carne-Ta-Ta-3-U-1-11368.jpg?v=637907207613970000", Category = category3} ,
                new Product() { name = "Empanadas Queso Y Cebolla Ta-Ta 3 U", price = 500 ,imageUrl = "https://tatauy.vteximg.com.br/arquivos/ids/383893/Empanadas-Queso-Y-Cebolla-Ta-Ta-3-U-1-9185.jpg?v=637907207567970000", Category = category1} ,
                new Product() { name = "Empanadas Choclo y Jamón Ta-Ta 3 U", price = 300 ,imageUrl = "https://tatauy.vteximg.com.br/arquivos/ids/383895/Empanadas-Choclo-y-Jam-n-Ta-Ta-3-U-1-9255.jpg?v=637907207575170000", Category = category2} ,
                new Product() { name = "Carne Picada Especial Envasada al Vacío 450 G", price = 500 ,imageUrl = "https://tatauy.vteximg.com.br/arquivos/ids/244607/Carne-Picada-Especial-Envasada-al-Vac-o-450-Gr-1-8987.jpg?v=637751038040530000", Category = category3} ,
                new Product() { name = "Aguja Sin Hueso En Trozo 720 Gr", price = 500 ,imageUrl = "https://tatauy.vteximg.com.br/arquivos/ids/273945/Aguja-Sin-Hueso-En-Trozo-600-Gr-1-9291.jpg?v=637769182057870000", Category = category1} ,
                new Product() { name = "Lomo Del Campo A La Mesa 780 Gr", price = 500 ,imageUrl = "https://tatauy.vteximg.com.br/arquivos/ids/234168/Lomo-Del-Campo-A-La-Mesa-1-Kg-1-24718.jpg?v=637741534364570000", Category = category2} ,
                new Product() { name = "Postre Vainilla Calcar 125 G", price = 200 ,imageUrl = "https://tatauy.vteximg.com.br/arquivos/ids/245477/Postre-Vainilla-Calcar-125-Gr-1-2674.jpg?v=637752010113200000", Category = category3} ,
                new Product() { name = "Carbón Del Chaco 1 U", price = 200 ,imageUrl = "https://tatauy.vteximg.com.br/arquivos/ids/217932/Carbon-Del-Chaco-1-U-1-17732.jpg?v=637668093689770000", Category = category1} ,
                new Product() { name = "Bondiola de Cerdo 2 Kg", price = 500 ,imageUrl = "https://tatauy.vteximg.com.br/arquivos/ids/223743/Bondiola-de-Cerdo-2-8-Kg-1-9.jpg?v=637681270944730000", Category = category2} ,
                new Product() { name = "Chorizo Jorge Hermanos", price = 200 ,imageUrl = "https://tatauy.vteximg.com.br/arquivos/ids/217634/Chorizo-Jorge-Hermanos-1-23327.jpg?v=637666583277630000", Category = category3} ,
                new Product() { name = "Chorizo Parrillero Extra La Constancia 400 G", price = 500 ,imageUrl = "https://tatauy.vteximg.com.br/arquivos/ids/223745/Chorizo-Parrillero-Extra-La-Constancia-400-Gr-1-3869.jpg?v=637681270954600000", Category = category1} ,
                new Product() { name = "Pollo Con Menudos Av Del Oeste 2.5 Kg", price = 200 ,imageUrl = "https://tatauy.vteximg.com.br/arquivos/ids/223749/Pollo-Con-Menudos-Av-Del-Oeste-2-50-Kg-1-3893.jpg?v=637681270971130000", Category = category2} ,
                new Product() { name = "Muslo 1/4 En Bandeja Avícola Del Oeste 400 G", price = 500 ,imageUrl = "https://tatauy.vteximg.com.br/arquivos/ids/223750/Muslo-1-4-En-Bandeja-Av-cola-Del-Oeste-400-Gr-1-3897.jpg?v=637681270975530000", Category = category3} ,
                new Product() { name = "Falda Con Hueso 1.1 Kg", price = 500 ,imageUrl = "https://tatauy.vteximg.com.br/arquivos/ids/261252/Falda-Con-Hueso-1-1-Kg-1-13649.jpg?v=637762161883070000", Category = category2} ,
                new Product() { name = "Carne Picada Especial Envasada Al Vacío 800 G", price = 200 ,imageUrl = "https://tatauy.vteximg.com.br/arquivos/ids/229815/Carne-Picada-Especial-Envasada-Al-Vac-o-800-Gr-1-15239.jpg?v=637723392019130000", Category = category1} ,
                new Product() { name = "Aguja Sin Hueso 1 Kg", price = 500 ,imageUrl = "https://tatauy.vteximg.com.br/arquivos/ids/273988/Aguja-S-H-1-Kg-Aguja-S-H-1-00-Kg-1-10932.jpg?v=637769182197730000", Category = category2} ,
                new Product() { name = "Bondiola Porcionado 1.5 Kg", price = 500 ,imageUrl = "https://tatauy.vteximg.com.br/arquivos/ids/311270/Bondiola-Porcionado-1-24909.jpg?v=637822857857300000", Category = category3 }
            };

            this.sContext.Products.AddRange(products);
            this.sContext.SaveChanges();

        }

        private void InitOrders()
        {
            var product1 = this.sContext.Products.FirstOrDefault(product => product.name == "Palta Hass Importada");
            var product2 = this.sContext.Products.FirstOrDefault(product => product.name == "Lomo Del Campo A La Mesa 780 Gr");

            var orders = new List<Order> {
                new Order(){ customerName = "Ana", code= Guid.NewGuid().ToString("n").Substring(0,8), customerEmail="ana@mail.com", customerMobile="000111222", Product = product1, sessionId= "prueba" },
                new Order(){ customerName = "Williams", code= Guid.NewGuid().ToString("n").Substring(0,8), customerEmail="williams@mail.com",status= Enumerations.OrderStatus.REJECTED, customerMobile="222111000", Product = product2, sessionId= "prueba" },
                new Order(){ customerName = "Williams", code= Guid.NewGuid().ToString("n").Substring(0,8), customerEmail="williams@mail.com",status= Enumerations.OrderStatus.PAYED, customerMobile="222111000", Product = product2, sessionId= "prueba" }
            };
            
            this.sContext.Orders.AddRange(orders);
            this.sContext.SaveChanges();

        }
        ~SeedController()
        {
            this.sContext.Dispose();
        }
    }
}
