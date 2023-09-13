import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from '../login/Login.service';
import { AddressService } from '../address/address.service';
import { OrderService } from '../order.service';
import { IUserAddress } from '../address/IUserAddress';
import { ProductService } from '../product.service';
import { Icartdetails } from '../icartdetails';

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
  public cartDetails:Icartdetails[]=[];
  isCartEmpty!:string;
  public cartDelete={
    cartId:0,
    productId:0
  }

  ngOnInit(): void {
    this.loginService.username$.subscribe((data => {
      this.userName = data;
      this.addressService.getUserId(this.userName).subscribe((data => {
        this.userId = data.userId;
        this.productService.viewCart(this.userId).subscribe((data) => 
        { 
          this.cartDetails = data; 
          if(this.cartDetails.length===0){
            this.isCartEmpty="Oops! Nothing In CartList!";
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
  deleteCart(id:number){
  this.productService.deleteCart(id).subscribe({
    next:(response)=>
    {
      if(response===true){
        alert('Deleted Successfully')
      }
      else{
        alert('Error! Cannot Delete')
      }
    }
  });
  }
}
