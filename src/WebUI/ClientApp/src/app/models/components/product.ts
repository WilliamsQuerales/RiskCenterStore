import { Category } from "./category";

export class Product {
    id: number;
    name: string;
    price: number;
    imageUrl: string;
    category: Category;
    isFavorite?: boolean
    
    constructor(){
        this.id = 0;
        this.name  ="";
        this.price = 0;
        this.imageUrl  ="";
        this.name  ="";
        this.category = new Category();
    }
}