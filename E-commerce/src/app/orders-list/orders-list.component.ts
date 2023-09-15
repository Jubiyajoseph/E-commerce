import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ProductService } from '../product.service';
import { LoginService } from '../login/Login.service';
import { AddressService } from '../address/address.service';
import { IorderDetails } from '../iorder-details';
import { OrderService } from '../order.service';

@Component({
  selector: 'app-orders-list',
  templateUrl: './orders-list.component.html',
  styleUrls: ['./orders-list.component.sass'],
})
export class OrdersListComponent implements OnInit {
  constructor(
    private productService: ProductService,
    private loginService: LoginService,
    private addressService: AddressService,
    private orderService: OrderService
  ) { }


  public isOrderListEmpty!: string;
  public OrderDetails: IorderDetails[] = [
    {
      orderId: 0,
      orderedOn: new Date(),
      totalPrice: 0,
      productName: '',
      statusName: '',
    },
  ];

  public orderCancel = {
    orderId: 0,
    orderStatusId: 1,
  };

  public updateStockOnCancel = {
    orderId: 0,
    userId: 0,
    orderStatusId: 0
  }

  public userName!: string;
  userId!: number;
  ngOnInit(): void {
    this.loginService.username$.subscribe((data) => {
      this.userName = data;
      this.addressService.getUserId(this.userName).subscribe((data) => {
        this.userId = data.userId;
        this.productService.getOrderDetails(this.userId).subscribe((data) => {
          this.OrderDetails = data;
          if (this.OrderDetails.length == 0) {
            this.isOrderListEmpty = "Oops! Place Your Order And Come Back!"
          }
        });
      });
    });
  }

  cancelOrder(orderId: number) {
    this.orderCancel.orderId = orderId;
    console.log(this.orderCancel);
    this.orderService.cancelOrder(this.orderCancel).subscribe({
      next: (response) => {
        if (response === true) {
          alert('Order Cancelled');
          this.loginService.username$.subscribe((data) => {
            this.userName = data;
            this.addressService.getUserId(this.userName).subscribe((data) => {              
              this.updateStockOnCancel.userId = data.userId
              this.updateStockOnCancel.orderId = this.orderCancel.orderId;
              this.updateStockOnCancel.orderStatusId = this.orderCancel.orderStatusId;
              this.orderService.updateStock(this.updateStockOnCancel).subscribe({
                next: (response) => {
                  if (response === true) {
                    console.log('Stock updated on cancelling order on product table');
                  } else {
                    alert('Error. Stock not updated on cancelling order');
                  }
                }
              });
            });
          });
        } 
        else {
          alert('Error! Cannot Cancel Order');
        }
      }
    });
  }
  
}
