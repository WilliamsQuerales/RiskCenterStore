import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { PaymentCard } from 'src/app/models/components/PaymentCard';

@Component({
  selector: 'app-payment-card',
  templateUrl: './payment-card.component.html',
  styleUrls: ['./payment-card.component.css']
})
export class PaymentCardComponent implements OnInit {
  @Output() toPay : EventEmitter<any> = new EventEmitter();

  paymentCard : PaymentCard
  constructor() {
    this.paymentCard = new PaymentCard();
   }

  ngOnInit(): void {

  }

  async payOrder() {
    this.toPay.emit(this.paymentCard);
  }
}
