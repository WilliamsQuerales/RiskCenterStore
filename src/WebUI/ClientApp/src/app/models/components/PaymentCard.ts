export class PaymentCard
{
    cardNumber : string;
    brand : string;
    cardHolder : string;
    expiredDate : string;
    cvv : number;

    constructor(){
        this.cardNumber = "";
        this.brand = "VISA";
        this.cardHolder = "";
        this.expiredDate = "";
        this.cvv = 0;
    }
}