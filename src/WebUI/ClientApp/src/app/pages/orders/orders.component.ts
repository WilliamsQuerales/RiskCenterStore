import { Component, OnInit } from '@angular/core';
import { StatusOrder } from 'src/app/shared/helpers/Enumerations';
import { Order } from 'src/app/models/components/order';
import { TraslateService } from 'src/app/services/helpers/traslateService';
import { OrderService } from 'src/app/services/orderService';
import { Pagination } from 'src/app/models/helpers/pagination';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css']
})

export class OrdersComponent implements OnInit {

  constructor(private orderService: OrderService, private traslateService: TraslateService) { }

  orders: Order[] = [];

  //alias StatusOrder to html
  StatusOrder = StatusOrder;
  ngOnInit(): void {
    this.loadOrders();
  }

  async loadOrders(){
    if(location.href.includes("my-orders")){
      this.orders = await this.orderService.getMyOrders();
    }
    else {
      this.orders = await this.orderService.getOrders();
    }
  }

  getStatusDescription(status: StatusOrder) {
    return this.traslateService.getTraslationStatusOrder(status)
  }

  getClassStatus(status: StatusOrder) {
    return "order-"+status.toString().toLowerCase();
  }
}
