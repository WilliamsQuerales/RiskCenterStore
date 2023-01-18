import { Component, Input, OnInit } from '@angular/core';
import { Order } from 'src/app/models/components/order';
import { TraslateService } from 'src/app/services/helpers/traslateService';
import { StatusOrder } from 'src/app/shared/helpers/Enumerations';

@Component({
  selector: 'app-form-order',
  templateUrl: './form-order.component.html',
  styleUrls: ['./form-order.component.css']
})
export class FormOrderComponent implements OnInit {

  @Input() order : Order = new Order();
  // alias to use enum in html
  StatusOrder = StatusOrder;
  constructor(private traslateService: TraslateService) { }
  ngOnInit(): void {
  }

  getStatusDescription() {
    return this.traslateService.getTraslationStatusOrder(this.order.status)
  }

  getButtonTitle(){
    return this.order.status == StatusOrder.CREATED ? "Pagar": "Reintentar Pago"
  }

  getClassStatus(){
      return "order-"+this.order.status.toString().toLowerCase();
  }
}
