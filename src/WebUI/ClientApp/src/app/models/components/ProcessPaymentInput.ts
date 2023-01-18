import { PaymentCard } from "./PaymentCard";

export class ProcessPaymentInput extends PaymentCard
{
    orderId : number;
    
    constructor(){
        super()
        this.orderId = 0;
    }
}