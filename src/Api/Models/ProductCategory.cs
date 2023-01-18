using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using RiskCenterStoreApi.Enumerations;


namespace RiskCenterStoreApi.Models
{
    [Serializable]
    [Table("product_categories")]
    public class ProductCategory
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
    }
}
