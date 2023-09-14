import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductService } from '../product.service';
import { IProductDetails } from '../iproduct-details';
import { ICartlist } from '../icartlist';
import { LoginService } from '../login/Login.service';
import { AddressService } from '../address/address.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Iwishlist } from '../iwishlist';
import { IupdateWishlist } from '../iupdate-wishlist';

@Component({
  selector: 'app-wishlist-product-details',
  templateUrl: './wishlist-product-details.component.html',
  styleUrls: ['./wishlist-product-details.component.sass']
})
export class WishlistProductDetailsComponent implements OnInit{

  public productDetails: IProductDetails={
    id: 0,
    name: '',
    weight: 0,
    stock: 0,
    brandName: '',
    categoryName: '',
    unitPrice: 0
  }
  public cartList:ICartlist={
    userId:0,
    productId:0,
    quantity:0
  }

  public updateQuery:IupdateWishlist={
    userID: 0,
    productID: 0,
  }
  username!:string;
  quantityForm!:FormGroup;
  showQuantity=false;
  
  constructor(private router:Router,
    private productService:ProductService,
    private route:ActivatedRoute,
    private addressService:AddressService,
    private formBuilder: FormBuilder,
    private loginService:LoginService){

  }

  ngOnInit(): void {
    const id: number = this.route.snapshot.params['id'];
    this.productService.getProductById(id).subscribe((data) => {
      this.productDetails = data;    
    });

    
    this.quantityForm=this.formBuilder.group({
      quantity:[' ',Validators.required]
    })
  }

  toAddToCart() {
  
    const id:number= this.route.snapshot.params['id'];
    this.cartList.productId=id;
    this.updateQuery.productID=id;
    this.loginService.username$.subscribe((data=>
      {
       this.username=data;
       this.addressService.getUserId(this.username).subscribe((data=>
        {
          this.cartList.userId = data.userId;
          this.updateQuery.userID = data.userId;
          this.cartList.quantity=this.quantityForm.get('quantity')?.value;
          console.log(this.cartList);
          this.productService.addToCart(this.cartList).subscribe({

            next:(response)=>
            {
              if(response===true){
                alert('Added To Cart')
                this.productService.updateWishList(this.updateQuery).subscribe()
              }
              else{
                alert('Already added or Check stock')
              }
            }
          });
        }))
      }))
 }
  
 buyNow(){
  const id:number= this.route.snapshot.params['id'];
  this.router.navigate([`./${id}/order-now`],
  {
    relativeTo: this.route
  });
}

}
