import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { ProductListComponent } from './product-list/product-list.component';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { CartComponent } from './cart/cart.component';
import { AddToWishlistComponent } from './add-to-wishlist/add-to-wishlist.component';
import { AddressComponent } from './address/address.component';
import { OrderNowComponent } from './order-now/order-now.component';
import { OrdersListComponent } from './orders-list/orders-list.component';
import { WishlistProductDetailsComponent } from './wishlist-product-details/wishlist-product-details.component';
import { UseraddressComponent } from './useraddress/useraddress.component';
import { UpdateaddressComponent } from './updateaddress/updateaddress.component';

const routes: Routes = [
  { path: '', component: LoginComponent },

  { path: 'home', component: HomeComponent },

  {
    path: 'product-list',
    children: [
      { path: '', component: ProductListComponent },
      {
        path: ':id/product-details',
        children: [
          { path: '', component: ProductDetailsComponent },
          { path: ':id/order-now', component: OrderNowComponent },
        ],
      },
    ],
  },

  // { path: 'product-details',
  //   children:[
  //             { path:'', component: ProductDetailsComponent },
  //             { path:':id/order-now',component:OrderNowComponent}
  //         ]
  // },

  { path: 'cart', component: CartComponent },

  {
    path: 'wishlist',
    children: [
      { path: '', component: AddToWishlistComponent },
      {
        path: ':id/wishlist-product-details',
        children: [
          { path: '', component: WishlistProductDetailsComponent },
          { path: ':id/order-now', component: OrderNowComponent },
        ]
      },
    ],
  },

  { path: 'add-user-address', component: AddressComponent },

  { path: 'order-now', component: OrderNowComponent },

  { path: 'orders-list', component: OrdersListComponent },

  {
    path: 'user-address',
    children: [
      { path: '', component: UseraddressComponent },
      { path: ':id/update-address', component: UpdateaddressComponent },
    ],
  },

  { path: 'update-address', component: UpdateaddressComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
