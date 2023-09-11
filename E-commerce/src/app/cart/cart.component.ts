import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ProductService } from '../product.service';
import { LoginService } from '../login/Login.service';
import { AddressService } from '../address/address.service';
import { Icartdetails } from '../icartdetails';

@Component({
  selector: 'app-add-to-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.sass']
})
export class CartComponent implements OnInit{

  public userName!:string;
  userId!:number;
  public cartDetails:Icartdetails[]=[];
  constructor(private router:Router,
    private productService:ProductService,
    private addressService:AddressService,
    private loginService:LoginService){

  }
  ngOnInit(): void {
    this.loginService.username$.subscribe((data=>
      {
       this.userName=data;
       this.addressService.getUserId(this.userName).subscribe((data=>
        {
          this.userId = data.userId;
          this.productService.viewCart(this.userId).subscribe((data)=>{
           this.cartDetails=data;
           console.log(this.cartDetails)
          })          
        }))
      }))
  }
  showAddress(){
    this.router.navigate([`./add-user-address`]);
  }

  viewCart(){
    this.loginService.username$.subscribe((data=>
      {
       this.userName=data;
       this.addressService.getUserId(this.userName).subscribe((data=>
        {
          this.userId = data.userId;
          this.productService.viewCart(this.userId).subscribe((data)=>{
           this.cartDetails=data;
          })          
        }))
      }))
  }
}
