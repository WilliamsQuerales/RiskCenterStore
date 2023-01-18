import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './shared/components/nav-menu/nav-menu.component';
import { OrdersComponent } from './pages/orders/orders.component';
import { ProductComponent } from './shared/components/product/product.component';
import { ProxyService } from './services/helpers/proxyService';
import { ProductService } from './services/productService';
import { OrderService } from './services/orderService';
import { TraslateService } from './services/helpers/traslateService';
import { OrderComponent } from './pages/order/order.component';
import { NewOrderComponent } from './pages/new-order/new-order.component';
import { ProductsComponent } from './pages/products/products.component';
import { FormClientComponent } from './components/form-client/form-client.component';
import { PayOrderComponent } from './pages/pay-order/pay-order.component';
import { PaymentCardComponent } from './components/payment-card/payment-card.component';
import { PaymentService } from './services/helpers/paymentService';
import { FormOrderComponent } from './components/form-order/form-order.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    ProductsComponent,
    ProductComponent,
    OrdersComponent,
    OrderComponent,
    NewOrderComponent,
    FormOrderComponent,
    PayOrderComponent,
    FormClientComponent,
    PaymentCardComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      {path: "", component: ProductsComponent},
      {path: "store", component: ProductsComponent},
      {path: "orders", component: OrdersComponent},
      {path: "my-orders", component: OrdersComponent},
      {path: "order/new/:productId", component: NewOrderComponent},
      {path: "order/:orderId", component: OrderComponent},
      {path: "order/:orderId/pay", component: PayOrderComponent}
    ]),
  ],
  providers: [
    ProxyService,
    ProductService,
    OrderService,
    TraslateService,
    PaymentService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
