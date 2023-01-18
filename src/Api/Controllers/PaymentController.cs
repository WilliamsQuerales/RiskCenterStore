using Microsoft.AspNetCore.Mvc;
using RiskCenterStoreApi.DataTypes.Payment;
using RiskCenterStoreApi.Enumerations;
using RiskCenterStoreApi.Models;

namespace RiskCenterStoreApi.Controllers
{
    [Route("api/payment")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        OrderController orderController;
        public PaymentController(StoreContext context)
        {
            this.orderController = new OrderController(context);
        }

        [HttpPost("process-payment")]
        public ActionResult<ProcessPaymentResult> ProcessPayment(ProcessPaymentInput input)
        {
            ProcessPaymentResult result = new ProcessPaymentResult();

            result = ValidateCard(input);
            
            if(result.processed && result.code == PaymentResultCode.APPROVED)
            {
                orderController.ChangeStatusOrder(input.orderId, OrderStatus.PAYED);

            }
            else if (result.processed && result.code == PaymentResultCode.REJECTED)
            {
                orderController.ChangeStatusOrder(input.orderId, OrderStatus.REJECTED);
            }

            return result;
            

        }
        private ProcessPaymentResult ValidateCard(ProcessPaymentInput input)
        {
            var result = new ProcessPaymentResult();

            List<string> validCards = new List<string>() { "4007000000027", "4111111111111111" };
            if (input.brand == BrandCard.VISA.ToString())
            {
                string cardNumber = input.cardNumber.Trim();
                if (!string.IsNullOrEmpty(cardNumber)) {
                    if (validCards.Contains(cardNumber)) {
                        result.processed = true;
                        result.code = PaymentResultCode.APPROVED;
                    }
                    else
                    {
                        if (cardNumber == "4005580000000040")
                        {
                            result.processed = true;
                            result.code = PaymentResultCode.REJECTED;
                        }
                    }
                }
            }

            return result;
        }
    }

}
