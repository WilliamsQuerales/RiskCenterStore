using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using RiskCenterStoreApi.Enumerations;


namespace RiskCenterStoreApi.Models
{
    [Serializable]
    [Table("orders")]
    public class Order
    {
        [Key]
        public int id { get; set; }
        public string code { get; set;}
        [MaxLength(80)]
        [Column("customer_name")]
        public string customerName { get; set; }
        [MaxLength(120)]
        [Column("customer_email")]
        public string customerEmail { get; set; }
        [MaxLength(40)]
        [Column("customer_mobile")]
        public string customerMobile { get; set; }
        [MaxLength(20)]
        [Column(TypeName = "nvarchar(20)")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public OrderStatus status { get; set; } = OrderStatus.CREATED;
        [Column("created_at")]
        public DateTime createdAt { get; set; } = DateTime.Now;
        [Column("updated_at")]
        public DateTime updatedAt { get; set; } = DateTime.Now;
        //for business rules relation is 1 order - 1 product, but 1 product - many orders
        [ForeignKey("product_id")]
        [Column("product_id")]
        public Product Product { get; set; }

        [NotNull]
        [Column("session_id")]
        public string sessionId { get; set; } = "";
    }
}
