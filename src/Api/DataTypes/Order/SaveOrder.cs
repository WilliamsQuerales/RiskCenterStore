using RiskCenterStoreApi.Enumerations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RiskCenterStoreApi.DataTypes.Order
{
    public class SaveOrderInput
    {
        public int productId { get; set; }
        public string customerName { get; set; }
        public string customerEmail { get; set; }
        public string customerMobile { get; set; }
    }
}
