import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NewOrderInput } from 'src/app/models/components/newOrderInput';
import { Order } from 'src/app/models/components/order';
import { OrderService } from 'src/app/services/orderService';
import { ProductService } from 'src/app/services/productService';

@Component({
  selector: 'app-new-order',
  templateUrl: './new-order.component.html',
  styleUrls: ['./new-order.component.css']
})
export class NewOrderComponent implements OnInit {

  constructor(private productService: ProductService, private orderService: OrderService, private route : ActivatedRoute, private router : Router) { }
  order: Order = new Order();

  ngOnInit(): void {
    // obtain params of route for get order data
    this.route.params.subscribe(params => {
      let productId = params['productId'];
      if(productId){
        this.initNewDataOrder(productId)
      }
    });
  }
  
  async initNewDataOrder(productId: number){
    let product = await this.productService.getProduct(productId);

    if(product){
      this.order.product = product;
    }
  }

  async saveNewOrder(orderData: Order) {
    
    let newOrder = new NewOrderInput();
    
    newOrder.customerName = orderData.customerName;
    newOrder.customerEmail = orderData.customerEmail;
    newOrder.customerMobile = orderData.customerMobile;
    if(this.order.product){
      newOrder.productId = this.order.product.id;
      let result = await this.orderService.SaveOrder(newOrder);
      
      if(result){
        this.router.navigate(["/order",result.id,"pay"]);
      }
    }
    else {
      // error
    }
  }
}
