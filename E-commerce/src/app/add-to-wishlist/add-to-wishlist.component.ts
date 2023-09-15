import { Component, OnInit } from '@angular/core';
import { ProductListComponent } from '../product-list/product-list.component';
import { ProductService } from '../product.service';
import { Iwishlist } from '../iwishlist';
import { LoginService } from '../login/Login.service';
import { AddressComponent } from '../address/address.component';
import { AddressService } from '../address/address.service';
import { IwishlistProducts } from '../iwishlist-products';
import { IProduct } from '../iproduct';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-add-to-wishlist',
  templateUrl: './add-to-wishlist.component.html',
  styleUrls: ['./add-to-wishlist.component.sass'],
})
export class AddToWishlistComponent implements OnInit {
  public username!: string;
  userId!: number;
  public productDetails: IwishlistProducts[] = [];
  isWishlistEmpty!: string;
  constructor(
    private loginService: LoginService,
    private addressService: AddressService,
    private productService: ProductService,
    private activatedRoute: ActivatedRoute,
    private router: Router
  ) {}
  ngOnInit(): void {
    this.loginService.username$.subscribe((data) => {
      this.username = data;
      this.addressService.getUserId(this.username).subscribe((data) => {
        this.userId = data.userId;
        this.productService.getWishlist(this.userId).subscribe((data) => {
          this.productDetails = data;
          
          if (this.productDetails.length === 0) {
            this.isWishlistEmpty = 'Oops! Nothing In Wishlist!';
          }
        });
      });
    });
  }

  getWishlistProductDetails(id: number) {
    this.router.navigate([`./${id}/wishlist-product-details`], {
      relativeTo: this.activatedRoute,
    });
  }
  deleteWishlist(id: number) {
    this.productService.deleteWishList(id).subscribe({
      next: (response) => {
        if (response === true) {
          alert('Deleted Successfully');
        } else {
          alert('Error! Cannot Delete');
        }
      },
    });
  }
}
