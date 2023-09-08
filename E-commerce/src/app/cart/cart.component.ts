import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-to-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.sass']
})
export class CartComponent {
  constructor(private router:Router){

  }
  showAddress(){
    this.router.navigate([`./add-user-address`]);
  }
}
