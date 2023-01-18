using RiskCenterStoreApi.Enumerations;
using System.Text.Json.Serialization;

namespace RiskCenterStoreApi.DataTypes.Payment
{
    public class ProcessPaymentInput
    {
        public int orderId { get; set; }
        public string cardNumber { get; set; }
        public string brand { get; set; }
        public string cardHolder { get; set; }
        public string expiredDate { get; set; }
        public int CVV { get; set; }
    }

    public class ProcessPaymentResult
    {
        public bool processed { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PaymentResultCode code { get; set; } = PaymentResultCode.INVALIDDATA;
    }

}
