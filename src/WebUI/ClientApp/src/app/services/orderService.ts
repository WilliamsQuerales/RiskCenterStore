import { Injectable } from "@angular/core";
import { NewOrderInput } from "../models/components/newOrderInput";
import { Order } from "../models/components/order";
import { ApiURL } from "./helpers/constants";
import { ProxyService } from "./helpers/proxyService";

@Injectable()
export class OrderService {

    constructor(private proxyService: ProxyService) {
    }
 
    public async getOrders() {
        let orders = await this.proxyService.getAsync(ApiURL+"/order/get-orders")
        return orders.map((order: any) => {
            return (order as Order);
        });
    }

    public async getMyOrders() {
        let orders = await this.proxyService.getAsync(ApiURL+"/order/get-session-orders")
        return orders.map((order: any) => {
            return (order as Order);
        });
    }

    public async getOrder(id : number) {
        let order = await this.proxyService.getAsync(ApiURL+"/order/get-order/"+id)
        return (order as Order);
    }

    public async SaveOrder(order : NewOrderInput){
        let newOrder = await this.proxyService.postAsync(ApiURL+"/order/save",order)

        return (newOrder as Order)
    }
    }