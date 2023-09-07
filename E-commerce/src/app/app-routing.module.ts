import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { ProductListComponent } from './product-list/product-list.component';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { AddToCartComponent } from './add-to-cart/add-to-cart.component';
import { AddToWishlistComponent } from './add-to-wishlist/add-to-wishlist.component';
import { AddressComponent } from './address/address.component';
import { OrderNowComponent } from './order-now/order-now.component';
import { OrdersListComponent } from './orders-list/orders-list.component';
import { WishlistProductDetailsComponent } from './wishlist-product-details/wishlist-product-details.component';

const routes: Routes = [
  { path: '',component: LoginComponent},

  { path: 'home', component: HomeComponent,},

  {
    path: 'product-list',
    children: [
      { path: '', component: ProductListComponent },
      { path: ':id/product-details', component: ProductDetailsComponent },
    ]
  },

  { path: 'product-details', component: ProductDetailsComponent},
  
  { path: 'add-to-cart', component: AddToCartComponent },

  { path: 'wishlist', 
  children:[
    {path:'',component: AddToWishlistComponent },
    { path: ':id/wishlist-product-details', component: WishlistProductDetailsComponent },
  ]},

  { path: 'add-user-address', component: AddressComponent },

  { path: 'order-now', component: OrderNowComponent },

  {path:'orders-list', component:OrdersListComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
