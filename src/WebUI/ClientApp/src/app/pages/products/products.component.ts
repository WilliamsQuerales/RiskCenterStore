import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/models/components/product';
import { Pagination } from 'src/app/models/helpers/pagination';
import { ProductService } from 'src/app/services/productService';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {

  constructor(private productService: ProductService) { }

  // paginatedProducts: Product[] = []
  pagination = new Pagination();

  products : Product[]= []
  async ngOnInit() {
    this.pagination.paginationSize = 8;
    await this.loadProducts()
    // this.paginateProducts(0);
  }

  async loadProducts(){
    this.products = await this.productService.getProducts();
    this.pagination.totalItems = this.products.length;
  }

//   paginateProducts(currentPage: number){
//     this.pagination.currentPage = currentPage;
//     let currentIndexInit = Math.ceil(this.pagination.currentPage / this.pagination.paginationSize);
//     let currentIndexEnd = currentIndexInit + this.pagination.paginationSize;
//     this.paginatedProducts = this.products.filter((product,index) => index >= currentIndexInit && index < currentIndexEnd)
//   }
}
