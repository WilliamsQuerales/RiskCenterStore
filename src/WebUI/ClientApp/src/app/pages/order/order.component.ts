import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Order } from 'src/app/models/components/order';
import { OrderService } from 'src/app/services/orderService';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css']
})
export class OrderComponent implements OnInit {
  constructor(private orderService: OrderService, private route : ActivatedRoute) { }

  order: Order = new Order();
  
  ngOnInit(): void {
    // obtain params of route for get order data
    this.route.params.subscribe(params => {
      let orderId = params['orderId'];

      if(orderId){
       this.getDataOrder(orderId)
      }
    });
  }

  async getDataOrder(orderId: number){
    this.order = await this.orderService.getOrder(orderId);
  }
}
