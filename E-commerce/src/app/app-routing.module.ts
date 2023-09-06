import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { ProductListComponent } from './product-list/product-list.component';
import { AddressComponent } from './address/address.component';

const routes: Routes = [
  {
    path: '', 
    component: LoginComponent
  },
  {
    path: 'home',
    component: HomeComponent
  },
  {
    path:'product-list',
    component:ProductListComponent
  }
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
