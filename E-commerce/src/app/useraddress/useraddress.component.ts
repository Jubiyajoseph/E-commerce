import { Component, OnInit } from '@angular/core';
import { LoginService } from '../login/Login.service';
import { AddressService } from '../address/address.service';
import { OrderService } from '../order.service';
import { IUserAddress } from '../address/IUserAddress';
import { ActivatedRoute, Router } from '@angular/router';
import { IDefaultUserAddress } from '../address/IDefaultUserAddress';

@Component({
  selector: 'app-useraddress',
  templateUrl: './useraddress.component.html',
  styleUrls: ['./useraddress.component.sass']
})

export class UseraddressComponent implements OnInit {

  public username!: string;
  userId!: number;
  selectedAddressId!: number;

  public addressDetails: IUserAddress[] = [];
  public defaultAddressDetails: IDefaultUserAddress={
    addressId: 0,
    residentialAddress: '',
    cityName: '',
    stateName: '',
    countryName: ''
  }
 
  public isNoDefaultAddress!: string;
  public changeDefaultAddress={
    addressId: 0,
    userId: 0
  }

  constructor(private router: Router,
    private loginService: LoginService,
    private addressService: AddressService,
    private activatedRoute: ActivatedRoute,
    private orderService: OrderService) {

  }

  ngOnInit(): void {
    this.loginService.username$.subscribe((data => {
      this.username = data;
      this.addressService.getUserId(this.username).subscribe((data => {
        this.userId = data.userId;
        this.orderService.getAddress(this.userId).subscribe((data) => {
          this.addressDetails = data;
        })
        this.orderService.getDefaultAddress(this.userId).subscribe((data) =>{
          this.defaultAddressDetails = data;
          if(this.defaultAddressDetails == null){
            this.isNoDefaultAddress= "You have no default address to display!!!"
          }
        })
      }))
    }))
  }

  showAddress() {
    this.router.navigate([`./add-user-address`]);
  }

  editAddress(id: number) {
    this.router.navigate([`./${id}/update-address`], {
      relativeTo: this.activatedRoute
    });
  }

  deleteAddress(addressId: number) {
    this.addressService.updateIsDeleted(addressId).subscribe(()=> {});
  }

  updateDefaultAddress() {
    this.loginService.username$.subscribe((data => {
      this.username = data;
      this.addressService.getUserId(this.username).subscribe((data => {
        this.changeDefaultAddress.userId = data.userId;
        this.changeDefaultAddress.addressId= this.selectedAddressId;
        this.orderService.updateDefaultAddress(this.changeDefaultAddress).subscribe({
          next: (response)=> {
            if(response === true){
              alert('Address updated successfully');
            }
            else{
              alert('Error. Address not updated');
            }}
        })        
      }))
    }))

  }
}
