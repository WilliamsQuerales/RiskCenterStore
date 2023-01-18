using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RiskCenterStoreApi.Enumerations
{
    [Serializable]
    public enum OrderStatus
    {
        [Description("Created")]
        CREATED,
        [Description("Payed")]
        PAYED,
        [Description("Rejected")]
        REJECTED
    }

    public enum BrandCard
    {
        [Description("VISA")]
        VISA,
        [Description("MASTERCARD")]
        MASTERCARD,
    }
    [Serializable]
    public enum PaymentResultCode
    {
        [Description("Approved")]
        APPROVED,
        [Description("Invalid Data")]
        INVALIDDATA,
        [Description("Rejected")]
        REJECTED,
    }
}
