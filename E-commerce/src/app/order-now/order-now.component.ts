import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, RouteReuseStrategy, Router } from '@angular/router';
import { LoginService } from '../login/Login.service';
import { AddressService } from '../address/address.service';
import { OrderService } from '../order.service';
import { IAddress } from '../address/IAddress';
import { IUserAddress } from '../address/IUserAddress';
import { IProductDetails } from '../iproduct-details';
import { ProductService } from '../product.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Icartdetails } from '../icartdetails';
import { ICartlist } from '../icartlist';
import { Iplaceorder } from '../iplaceorder';

@Component({
  selector: 'app-order-now',
  templateUrl: './order-now.component.html',
  styleUrls: ['./order-now.component.sass'],
})
export class OrderNowComponent implements OnInit {
  public username!: string;
  userId!: number;

  public OrderQuantity: Icartdetails = {
    productId: 0,
    productName: '',
    unitPrice: 0,
    weight: 0,
    stock: 0,
    quantity: 0,
    cartId: 0,
  };
  public productDetails: IProductDetails = {
    id: 0,
    name: '',
    weight: 0,
    stock: 0,
    brandName: '',
    categoryName: '',
    unitPrice: 0,
  };
  public cartList: ICartlist = {
    userId: 0,
    productId: 0,
    quantity: 0,
  };
  public placeOrderDetails: Iplaceorder = {
    userId: 0,
    billingAddressId: 0,
    shippingAddressId: 0,
    orderStatusId: 4,
    orderedOn: new Date()
  };
  public addressDetails: IUserAddress[] = [];
  public selectShippingAdressId!: number;

  quantityForm!: FormGroup;
  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private loginService: LoginService,
    private addressService: AddressService,
    private productService: ProductService,
    private formBuilder: FormBuilder,
    private orderService: OrderService
  ) {}
  ngOnInit(): void {
    this.loginService.username$.subscribe((data) => {
      this.username = data;
      this.addressService.getUserId(this.username).subscribe((data) => {
        this.userId = data.userId;
        this.orderService.getAddress(this.userId).subscribe((data) => {
          this.addressDetails = data;
        });
      });
    });
    this.quantityForm = this.formBuilder.group({
      quantity: [' ', Validators.required],
    });
    this.OrderQuantity.quantity = this.quantityForm.get('quantity')?.value;
    //console.log(this.OrderQuantity)
    const id: number = this.route.snapshot.params['id'];
    this.productService.getProductById(id).subscribe((data) => {
      this.productDetails = data;
    });
  }
  showAddress() {
    this.router.navigate([`./add-user-address`]);
  }


  getShippingAdrress(){
    this.placeOrderDetails.shippingAddressId = this.selectShippingAdressId;
  }

  placeOrder() {
    const id: number = this.route.snapshot.params['id'];
    this.cartList.productId = id;
    this.loginService.username$.subscribe((data) => {
      this.username = data;
      this.addressService.getUserId(this.username).subscribe((data) => {
        this.cartList.userId = data.userId;
        this.placeOrderDetails.userId = data.userId;
        this.orderService
          .getDefaultAddress(this.placeOrderDetails.userId)
          .subscribe((data) => {
            this.placeOrderDetails.billingAddressId = data.addressId;
          });
        
        this.placeOrderDetails.orderStatusId = 4;
        this.cartList.quantity = this.quantityForm.get('quantity')?.value;
        this.productService.addToCart(this.cartList).subscribe({
          next: (response) => {
            if (response === true) {
              this.productService.placeOrder(this.placeOrderDetails).subscribe({
                next: (response) => {
                  if (response === true) {
                    alert('Order Placed!');
                  }
                  else{
                    alert('Order not Placed!');
                  }
                },
              });
            } 
            else{
              alert('Check Stock First!');
            }
          }
        });
      });
    });
  }
}
