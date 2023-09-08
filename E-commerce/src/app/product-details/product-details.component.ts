import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductService } from '../product.service';
import { IProductDetails } from '../iproduct-details';
import { Iwishlist } from '../iwishlist';
import { AddressService } from '../address/address.service';
import { LoginService } from '../login/Login.service';
import { ICartlist } from '../icartlist';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.sass'],
})
export class ProductDetailsComponent implements OnInit {

  showQuantity=false;
  public productDetails: IProductDetails={
    id: 0,
    name: '',
    weight: 0,
    stock: 0,
    brandName: '',
    categoryName: '',
    unitPrice: 0
  }
  public wishlist: Iwishlist={
    wishListID: 0,
    userID: 0,
    productID: 0,
    isDeleted: false
  }
  public cartList:ICartlist={
    userId:0,
    productId:0,
    quantity:0
  }
 
 username!:string;
 quantityForm!:FormGroup;

  constructor(
    private route: ActivatedRoute,
    private productService: ProductService,
    private router: Router,
    private addressService:AddressService,
    private loginService:LoginService,
    private formBuilder: FormBuilder
  ) {}

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
    this.loginService.username$.subscribe((data=>
      {
       this.username=data;
       this.addressService.getUserId(this.username).subscribe((data=>
        {
          this.cartList.userId= data.userId;
          this.cartList.quantity=this.quantityForm.get('quantity')?.value;
          console.log(this.cartList);
          this.productService.addToCart(this.cartList).subscribe({

            next:(response)=>
            {
              if(response===true){
                alert('Added To Cart')
              }
              else{
                alert('Already added or Check stock')
              }
            }
          });
        }))
      }))

  }

  toAddToWishlist() {

    const id:number= this.route.snapshot.params['id'];
    this.wishlist.productID=id;
    this.wishlist.isDeleted=false;
    this.loginService.username$.subscribe((data=>
      {
       this.username=data;
       this.addressService.getUserId(this.username).subscribe((data=>
        {
          this.wishlist.userID= data.userId;
          this.productService.addWishList(this.wishlist).subscribe({
            next:(response)=>
            {
              if(response===true){
                alert('Added To WishList')
              }
              else{
                alert('Already added to Wishlist')
              }
            }
          });
        }))
      }))
  }
    
  buyNow(){
    this.router.navigate([`./order-now`]);
  }
}

