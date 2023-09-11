import { Component, OnInit } from '@angular/core';
import { LoginService } from '../login/Login.service';
import { AddressService } from '../address/address.service';
import { OrderService } from '../order.service';
import { IUserAddress } from '../address/IUserAddress';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-useraddress',
  templateUrl: './useraddress.component.html',
  styleUrls: ['./useraddress.component.sass']
})
export class UseraddressComponent implements OnInit{

  public username!:string;
  userId!:number;
  public addressDetails:IUserAddress[]=[];
  
  constructor(private router:Router,
    private loginService:LoginService,
    private addressService:AddressService,
    private activatedRoute:ActivatedRoute,
    private orderService:OrderService ) {  
    
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
  
  editAddress(id:number){
    this.router.navigate([`./${id}/update-address`], {
      relativeTo: this.activatedRoute
    });   
  }
}
