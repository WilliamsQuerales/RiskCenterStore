import { StatusOrder } from "src/app/shared/helpers/Enumerations";
import { Product } from "./product";

export class Order {
        id: number;
        code: string;
        customerName: string;
        customerEmail: string;
        customerMobile: string;
        status: StatusOrder;
        createdAt?: Date;
        updatedAt?: Date;
        product?: Product;
        
    constructor(){
        this.id = 0;
        this.code ="";
        this.customerName="";
        this.customerEmail="";
        this.customerMobile="";
        this.status= StatusOrder.CREATED;
    }
}