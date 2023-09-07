import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { AddressService } from './address.service';
import { ICity } from './Icity';
import { IState } from './Istate';
import { ICountry } from './Icountry';
import { IAddress } from './IAddress';
import { LoginService } from '../login/Login.service';

@Component({
  selector: 'app-address',
  templateUrl: './address.component.html',
  styleUrls: ['./address.component.sass']
})
export class AddressComponent implements OnInit{
  

  
  constructor(private addressService: AddressService, private formBuilder: FormBuilder,private loginService:LoginService) {
    
  }

  showErrors = false;

  cities: ICity[] = [];
  states: IState[] = [];
  countries: ICountry[]=[];
  username!:string;

  addressForm!: FormGroup;

  ngOnInit(): void {
    this.addressService.getCities().subscribe((data) => {
      this.cities = data;
    });
    this.addressService.getState().subscribe((data)=>{
      this.states=data;
    })
    this.addressService.getCountry().subscribe((data)=>{
      this.countries=data;
    })

    this.addressForm = this.formBuilder.group({
      address: new FormControl(null,[Validators.required]),
      city: new FormControl(null,[Validators.required]),
      state: new FormControl(null,[Validators.required]),
      country: new FormControl(null,[Validators.required])
    })

    
  }


  public newAddress: IAddress=
  {
    addressId: 0,
    residentialAddress: '',
    cityId: 0,
    stateId: 0,
    countryId: 0,
    userId: 0,
    isDeleted: false
  }

  onClickAddress()
  {
    this.newAddress.residentialAddress= this.addressForm.get('address')?.value;
    this.newAddress.cityId= this.addressForm.get('city')?.value;
    this.newAddress.stateId = this.addressForm.get('state')?.value;  
    this.newAddress.countryId= this.addressForm.get('country')?.value;
    this.newAddress.isDeleted=false;
    this.loginService.username$.subscribe((data)=>{
      this.username=data;
      this.addressService.getUserId(this.username).subscribe((data)=>
      {
        this.newAddress.userId=data.userId
        this.addressService.addAddress(this.newAddress).subscribe( {
          next: () => { console.log("Address added sucessfully") },
          error: () => { alert('ERROR! Address not inserted'); }
        });
      })
    })
  }
}
