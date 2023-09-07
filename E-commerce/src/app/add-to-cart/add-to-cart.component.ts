import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-to-cart',
  templateUrl: './add-to-cart.component.html',
  styleUrls: ['./add-to-cart.component.sass']
})
export class AddToCartComponent {
  constructor(private router:Router){

  }
  showAddress(){
    this.router.navigate([`./add-user-address`]);
  }
}
