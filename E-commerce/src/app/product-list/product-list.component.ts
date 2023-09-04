import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { EcommerceService } from '../login/lECommerce.service';
import { IProduct } from '../iproduct';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.sass']
})
export class ProductListComponent implements OnInit {

  products:IProduct[]=[];
  currentPage = 1;
  
 

  //search products
  public productFormGroup!: FormGroup;
  searchText = new FormControl('');
  filteredproduct:Array<IProduct>=[];
  constructor(private appService: EcommerceService,private formBuilder: FormBuilder,private router: Router) {
  
    
  }
  ngOnInit()
  {     
    this.loadProducts(this.currentPage);
  }

  loadProducts(page:number)
  {
    this.appService.getProducts(page).subscribe((data)=>
    {
      this.products = data;
    });    
  }

  PreviousPage()
  {
    //console.log("Helloprevious");
    if (this.currentPage > 1)
    {
      this.currentPage--;
      this.loadProducts(this.currentPage);
    }
  }

  NextPage()
  {
    //console.log("Hello");
    this.currentPage++;
    this.loadProducts(this.currentPage);
  }

  search(){
    this.filteredproduct = this.products
  }
}
