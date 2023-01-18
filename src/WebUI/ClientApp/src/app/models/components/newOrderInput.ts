export class NewOrderInput {
    productId: number;
    customerName: string;
    customerEmail: string;
    customerMobile: string;

    constructor(){
        this.productId = 0;
        this.customerName = "";
        this.customerEmail = "";
        this.customerMobile = "";
    }
}