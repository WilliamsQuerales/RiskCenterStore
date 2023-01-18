using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using RiskCenterStoreApi.Enumerations;


namespace RiskCenterStoreApi.Models
{
    [Serializable]
    [Table("products")]
    public class Product
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        [ForeignKey("category_id")]
        [Column("category_id")]
        public ProductCategory Category { get; set; }
        [Column("url_image")]
        public string imageUrl { get; set; }
    }
}
