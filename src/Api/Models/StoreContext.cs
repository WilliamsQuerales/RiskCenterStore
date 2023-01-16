using Microsoft.EntityFrameworkCore;

namespace RiskCenterStoreApi.Models
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions options) : base(options) {
        
        }
    }
}
