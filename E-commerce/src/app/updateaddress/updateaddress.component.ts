import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { IAddress } from '../address/IAddress';
import { ICity } from '../address/Icity';
import { IState } from '../address/Istate';
import { ICountry } from '../address/Icountry';
import { AddressService } from '../address/address.service';
import { LoginService } from '../login/Login.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-updateaddress',
  templateUrl: './updateaddress.component.html',
  styleUrls: ['./updateaddress.component.sass']
})
export class UpdateaddressComponent {

  constructor(private route: ActivatedRoute,
    private router: Router,
     private addressService: AddressService, 
     private formBuilder: FormBuilder, 
     private loginService: LoginService) {

  }

  showErrors = false;

  cities: ICity[] = [];
  states: IState[] = [];
  countries: ICountry[] = [];
  username!: string;

  addressForm!: FormGroup;

  ngOnInit(): void {
    this.addressService.getCities().subscribe((data) => {
      this.cities = data;
    });
    this.addressService.getState().subscribe((data) => {
      this.states = data;
    })
    this.addressService.getCountry().subscribe((data) => {
      this.countries = data;
    })

    this.addressForm = this.formBuilder.group({
      address: new FormControl('', [Validators.required]),
      city: new FormControl(null, [Validators.required]),
      state: new FormControl(null, [Validators.required]),
      country: new FormControl(null, [Validators.required])
    })
  }


  public newAddress: IAddress =
    {
      addressId: 0,
      residentialAddress: '',
      cityId: 0,
      stateId: 0,
      countryId: 0,
      userId: 0,
      isDeleted: false
    }

  onClickUpdateAddress() {

    const id: number = this.route.snapshot.params['id'];
    this.newAddress.residentialAddress = this.addressForm.get('address')?.value;
    this.newAddress.cityId = this.addressForm.get('city')?.value;
    this.newAddress.stateId = this.addressForm.get('state')?.value;
    this.newAddress.countryId = this.addressForm.get('country')?.value;
    this.newAddress.isDeleted = false;
    this.loginService.username$.subscribe((data) => {
      this.username = data;
      this.addressService.getUserId(this.username).subscribe((data) => {
        this.newAddress.userId = data.userId

        if((this.newAddress.cityId==0  || this.newAddress.stateId ==0 || this.newAddress.countryId ==0 ) || this.newAddress.residentialAddress=='')
        {
          alert('Enter Valid Entries');
        }
    else{
      console.log("inside update")
        this.addressService.updateAddress(this.newAddress, id).subscribe({
          next: (response) => {
            if(response === true){
              alert('Address updated successfully');
            }
            if(response==false){
              alert('ERROR! Address not updated');
            }}
        });
      }
    })
    })
  }
}
