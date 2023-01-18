import { Injectable } from "@angular/core";
import { Product } from "../models/components/product";
import { ApiURL } from "./helpers/constants";
import { ProxyService } from "./helpers/proxyService";

@Injectable()
export class ProductService {

    constructor(private proxyService: ProxyService) {
    }
 
    public async getProducts() {
        let products = await this.proxyService.getAsync(ApiURL+"/product/get-products")
        return products.map((product: any) => {
            let newProduct = product as Product;
            return newProduct;
        });
    }

    public async getProduct(id : number) {
        let product = await this.proxyService.getAsync(ApiURL+"/product/get-product/"+id)
        return (product as Product);
    }
}