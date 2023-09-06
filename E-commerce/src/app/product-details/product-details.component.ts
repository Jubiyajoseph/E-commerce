import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductService } from '../product.service';
import { IProductDetails } from '../iproduct-details';
import { Iwishlist } from '../iwishlist';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.sass'],
})
export class ProductDetailsComponent implements OnInit {
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

  constructor(
    private route: ActivatedRoute,
    private productService: ProductService,
    private router: Router
  ) {}

  ngOnInit(): void {
    const id: number = this.route.snapshot.params['id'];
    this.productService.getProductById(id).subscribe((data) => {
      this.productDetails = data;    
    });
  }

  toAddToCart() {
    this.router.navigate(['./add-to-cart']);
  }

  toAddToWishlist() {

    const id:number= this.route.snapshot.params['id'];
    this.wishlist.productID=id;
    this.wishlist.userID=1;
    this.wishlist.isDeleted=false;
    this.productService.addWishList(this.wishlist).subscribe({   
    //next:()=> {this.router.navigate(['./add-to-wishlist'])} 
    });

    
  }
}
