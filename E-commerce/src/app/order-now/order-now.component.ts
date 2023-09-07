import { Component } from '@angular/core';
import { RouteReuseStrategy, Router } from '@angular/router';

@Component({
  selector: 'app-order-now',
  templateUrl: './order-now.component.html',
  styleUrls: ['./order-now.component.sass']
})
export class OrderNowComponent {

  constructor(private router:Router){
    
  }
  showAddress(){
    this.router.navigate([`./add-user-address`]);
  }
}
