import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { LoginModule } from './login/login.module';
import { HomeComponent } from './home/home.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
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

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent,
    ProductListComponent,
    ProductDetailsComponent,
    CartComponent,
    AddToWishlistComponent,
    AddressComponent,
    OrderNowComponent,
    OrdersListComponent,
    WishlistProductDetailsComponent,
    UseraddressComponent,
    UpdateaddressComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    LoginModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
