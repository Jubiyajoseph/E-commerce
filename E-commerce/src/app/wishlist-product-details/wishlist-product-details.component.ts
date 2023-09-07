import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductService } from '../product.service';
import { IProductDetails } from '../iproduct-details';

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
  constructor(private router:Router,private productService:ProductService,private route:ActivatedRoute){

  }

  ngOnInit(): void {
    const id: number = this.route.snapshot.params['id'];
    this.productService.getProductById(id).subscribe((data) => {
      this.productDetails = data;    
    });
  }

  toAddToCart() {
    //api call for add to cart
 }
  
 buyNow(){
  this.router.navigate([`./order-now`]);
}

}
