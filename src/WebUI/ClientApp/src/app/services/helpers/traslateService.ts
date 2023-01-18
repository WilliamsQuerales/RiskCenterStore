import { Injectable } from "@angular/core";
import { StatusOrder } from "src/app/shared/helpers/Enumerations";

@Injectable()
export class TraslateService {
    getTraslationStatusOrder(statusOrder: StatusOrder) {
        switch(statusOrder){
            case StatusOrder.CREATED:
                return "Creado";
            case StatusOrder.PAYED:
                return "Pagado";
            case StatusOrder.REJECTED:
                return "Rechazado";
            default: return "Indefinido"
        }
    }

}