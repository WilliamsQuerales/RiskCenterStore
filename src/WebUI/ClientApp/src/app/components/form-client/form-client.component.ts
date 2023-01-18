import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Order } from 'src/app/models/components/order';

@Component({
  selector: 'app-form-client',
  templateUrl: './form-client.component.html',
  styleUrls: ['./form-client.component.css']
})
export class FormClientComponent implements OnInit {
  @Input() order : Order;
  @Input() isNewOrder : boolean;
  @Output() onSave : EventEmitter<any> = new EventEmitter();

  currentOrder : Order;
  constructor() { 
    this.order = new Order();
    this.currentOrder = new Order();
    this.isNewOrder = false;
  }

  ngOnInit(): void {
    if(this.order){
      this.currentOrder = {...this.order}
    }
  }

  saveNewOrder() {
    this.onSave.emit(this.currentOrder);
  }
}
