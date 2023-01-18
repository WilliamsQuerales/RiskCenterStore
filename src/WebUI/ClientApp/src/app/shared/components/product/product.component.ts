import { Component, Input, OnInit } from '@angular/core';
import { Product } from 'src/app/models/components/product';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  @Input() product : Product = new Product();
  @Input() inOrder : boolean = false;

  constructor() { 
  }

  ngOnInit(): void {

  }

  getIconFavorite() { 
    return `https://www.svgrepo.com/show/${this.product.isFavorite ? '485737' : '13666'}/heart.svg`
  }

  toogleFavorite() {
    this.product.isFavorite = !this.product.isFavorite
  }
}
