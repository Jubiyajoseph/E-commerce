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
    orderStatusId: 4,// default orderid is 4 ie 'your order has been recieved'
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
            
          if(data.length==0){        
              alert("Add your Address First!");
          }
          else{
            this.addressDetails = data;
          }
        });
      });
    });
    this.quantityForm = this.formBuilder.group({
      quantity: [' ', Validators.required],
    });
   
    const id: number = this.route.snapshot.params['id'];
    this.productService.getProductById(id).subscribe((data) => {
      this.productDetails = data;
    });
  }
  showAddress() {
    this.router.navigate([`./add-user-address`]);
  }


  getShippingAdrress(){
    if(!this.selectShippingAdressId||this.selectShippingAdressId==null)
    {
    alert('Add Your Address First!')
    }
    else{
      this.placeOrderDetails.shippingAddressId = this.selectShippingAdressId;
    }
    
  }

  placeOrder() {

    if(this.placeOrderDetails.shippingAddressId ==0){
      alert('Enter Shipping Address!')
    }
    else{
    const id: number = this.route.snapshot.params['id'];
    this.cartList.productId = id;
    this.loginService.username$.subscribe((data) => 
    {
         this.username = data;
         this.addressService.getUserId(this.username).subscribe((data) => 
         {
         this.cartList.userId = data.userId;
         this.placeOrderDetails.userId = data.userId;
         this.orderService
          .getDefaultAddress(this.placeOrderDetails.userId)
          .subscribe((data) => 
          {
            if(!data || data==null)
            {
              alert('Please Set Your Default Address! Then Place Order')
            }
            else{
                this.placeOrderDetails.billingAddressId = data.addressId;
                this.placeOrderDetails.orderStatusId = 4;// default orderid is 4 ie 'your order has been recieved'
                this.cartList.quantity = this.quantityForm.get('quantity')?.value;
            
            if( !this.cartList.quantity || this.cartList.quantity <1 )
            {
              alert('Enter Valid Quantity');
            }
              else{
                    this.productService.addToCart(this.cartList).subscribe(
                    {
                     next: (response) => 
                     {
                      if (response === true) 
                      {
                       this.productService.placeOrder(this.placeOrderDetails).subscribe(
                           {
                          next: (response) => 
                           {
                           if (response === true) 
                          {
                            alert('Order Placed!');
                          }
                            else
                              {
                            alert('Order not Placed!');
                              }
                           }
                            });
                      } 
                      if(response === false)
                       {
                      alert('Aleardy in Cart OR Check Stock First!');
                       }
                 }
            });
          }
          }
          });
      });
    });
  }
}
}
