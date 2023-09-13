import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, RouteReuseStrategy, Router } from '@angular/router';
import { LoginService } from '../login/Login.service';
import { AddressService } from '../address/address.service';
import { OrderService } from '../order.service';
import { IAddress } from '../address/IAddress';
import { IUserAddress } from '../address/IUserAddress';
import { IProductDetails } from '../iproduct-details';
import { ProductService } from '../product.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Icartdetails } from '../icartdetails';

@Component({
  selector: 'app-order-now',
  templateUrl: './order-now.component.html',
  styleUrls: ['./order-now.component.sass']
})
export class OrderNowComponent implements OnInit{

  public username!:string;
  userId!:number;
  
  public OrderQuantity:Icartdetails={
    productId: 0,
    productName: '',
    unitPrice: 0,
    weight: 0,
    stock: 0,
    quantity: 0,
    cartId: 0
  }
  public productDetails: IProductDetails={
    id: 0,
    name: '',
    weight: 0,
    stock: 0,
    brandName: '',
    categoryName: '',
    unitPrice: 0
  }
  public addressDetails:IUserAddress[]=[];
  quantityForm!:FormGroup;
  constructor(private router:Router,
    private route:ActivatedRoute,
    private loginService:LoginService,
    private addressService:AddressService,
    private productService:ProductService,
    private formBuilder: FormBuilder,
    private orderService:OrderService ){
    
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
      this.quantityForm=this.formBuilder.group({
        quantity:[' ',Validators.required]
      })
      this.OrderQuantity.quantity=this.quantityForm.get('quantity')?.value;
      console.log(this.OrderQuantity)
      const id:number= this.route.snapshot.params['id'];
      this.productService.getProductById(id).subscribe((data) => {
        this.productDetails = data;    
      });

     
  }
  showAddress(){
    this.router.navigate([`./add-user-address`]);
  }
}
