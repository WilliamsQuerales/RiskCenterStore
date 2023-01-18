import { Injectable } from "@angular/core";
import { ProcessPaymentInput } from "src/app/models/components/ProcessPaymentInput";
import { ApiURL } from "./constants";
import { ProxyService } from "./proxyService";

@Injectable()
export class PaymentService {
    constructor(private proxyService: ProxyService) {
    }
 
    public async processPayment(input : ProcessPaymentInput) {
        
        return await this.proxyService.postAsync(ApiURL+"/payment/process-payment",input);
        
    }

}