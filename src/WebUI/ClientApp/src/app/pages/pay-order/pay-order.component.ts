import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Order } from 'src/app/models/components/order';
import { PaymentCard } from 'src/app/models/components/PaymentCard';
import { ProcessPaymentInput } from 'src/app/models/components/ProcessPaymentInput';
import { PaymentService } from 'src/app/services/helpers/paymentService';

@Component({
  selector: 'app-pay-order',
  templateUrl: './pay-order.component.html',
  styleUrls: ['./pay-order.component.css']
})
export class PayOrderComponent implements OnInit {

  order: Order = new Order();
  resultPayment = "";
  constructor(private paymentService : PaymentService, private route : ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    // obtain params of route for get order data
    this.route.params.subscribe(params => {
      let orderId = params['orderId'];
      if(orderId){
        this.order.id = orderId;
      }
    });
  }

  async processPayment(paymentCard : PaymentCard) {
    let paymentInput = paymentCard as ProcessPaymentInput;

    paymentInput.orderId = this.order.id;

    let result = await this.paymentService.processPayment(paymentInput);

    if(result){
      this.resultPayment = result.code;
      if(result.processed){
        if(result.code == "APPROVED"){
          setTimeout(() => {
            this.router.navigateByUrl("/order/"+this.order.id+"?payment=approved");
          }, 3000);
        }
      }
      else {
        setTimeout(() => {
          this.resultPayment = ""
        }, 3000);
      }
    }
  }
}
