import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from '../login/Login.service';
import { AddressService } from '../address/address.service';
import { OrderService } from '../order.service';
import { IUserAddress } from '../address/IUserAddress';
import { ProductService } from '../product.service';
import { Icartdetails } from '../icartdetails';
import { Iplaceorder } from '../iplaceorder';

@Component({
  selector: 'app-add-to-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.sass']
})
export class CartComponent implements OnInit {

  constructor(private router: Router,
    private productService: ProductService,
    private loginService: LoginService,
    private addressService: AddressService,
    private orderService: OrderService) {

  }
  public userName!: string;
  userId!: number;
  public addressDetails: IUserAddress[] = [];
  public cartDetails: Icartdetails[] = [];
  isCartEmpty!: string;
  public cartDelete = {
    cartId: 0,
    productId: 0
  }
  public selectShippingAdressId!: number;
  public placeOrderDetails: Iplaceorder = {
    userId: 0,
    billingAddressId: 0,
    shippingAddressId: 0,
    orderStatusId: 4,
    orderedOn: new Date()
  };

  ngOnInit(): void {
    this.loginService.username$.subscribe((data => {
      this.userName = data;
      this.addressService.getUserId(this.userName).subscribe((data => {
        this.userId = data.userId;
        this.productService.viewCart(this.userId).subscribe((data) => {
          this.cartDetails = data;
          if (this.cartDetails.length === 0) {
            this.isCartEmpty = "Oops! Nothing In CartList!";
          }
        })
        this.orderService.getAddress(this.userId).subscribe((data) => {
          this.addressDetails = data;
        })
      }))
    }))
  }

  showAddress() {
    this.router.navigate([`./add-user-address`]);
  }

  deleteCart(id: number) {
    this.productService.deleteCart(id).subscribe({
      next: (response) => {
        if (response === true) {
          alert('Deleted Successfully')
        }
        else {
          alert('Error! Cannot Delete')
        }
      }
    });
  }

  getShippingAdrress() {
    this.placeOrderDetails.shippingAddressId = this.selectShippingAdressId;
  }
  
  placeOrder() {
    this.loginService.username$.subscribe((data) => {
      this.userName = data;
      this.addressService.getUserId(this.userName).subscribe((data) => {
        this.placeOrderDetails.userId = data.userId;
        this.orderService.getDefaultAddress(this.placeOrderDetails.userId).subscribe((data) => {
          this.placeOrderDetails.billingAddressId = data.addressId;
          this.placeOrderDetails.orderStatusId = 4;
          console.log(this.placeOrderDetails);
          this.productService.placeOrder(this.placeOrderDetails).subscribe({
            next: (response) => {
              if (response === true) {
                alert('Order Placed!');
              }
              else {
                alert('Order not Placed!');
              }
            },
          });

        });
      })
    })
  }
}
