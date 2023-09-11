import { Component, OnInit } from '@angular/core';
import { RouteReuseStrategy, Router } from '@angular/router';
import { LoginService } from '../login/Login.service';
import { AddressService } from '../address/address.service';
import { OrderService } from '../order.service';
import { IAddress } from '../address/IAddress';
import { IUserAddress } from '../address/IUserAddress';

@Component({
  selector: 'app-order-now',
  templateUrl: './order-now.component.html',
  styleUrls: ['./order-now.component.sass']
})
export class OrderNowComponent implements OnInit{

  public username!:string;
  userId!:number;


  public addressDetails:IUserAddress[]=[];

  constructor(private router:Router,private loginService:LoginService,private addressService:AddressService,private orderService:OrderService ){
    
  }
  ngOnInit(): void {
    this.loginService.username$.subscribe((data=>
      {
       this.username=data;
       this.addressService.getUserId(this.username).subscribe((data=>
        {
          this.userId = data.userId;
          this.orderService.getAddress(this.userId).subscribe((data)=>{
            this.addressDetails=data;
          })         
        }))
      }))
  }
  showAddress(){
    this.router.navigate([`./add-user-address`]);
  }
}
