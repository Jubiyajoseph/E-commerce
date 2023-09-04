import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { IProduct } from '../iproduct';
import { ProductService } from '../product.service';

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
  searchTerm!: string;
  filteredSearchList:Array<IProduct>=[];
  constructor(private productService: ProductService,private formBuilder: FormBuilder,private router: Router) {
  
    
  }
  ngOnInit()
  {     
    this.loadProducts(this.currentPage);
  }

  loadProducts(page:number)
  {
    this.productService.getProducts().subscribe((data)=>
    {
      this.products = data;
    });
    
  }

  PreviousPage()
  {
    if (this.currentPage > 1)
    {
      this.currentPage--;
      this.loadProducts(this.currentPage);
    }
  }

  NextPage()
  {
    this.currentPage++;
    this.loadProducts(this.currentPage);
  }

  search(){
    this.productService.getSearchList(this.searchTerm).subscribe((data)=>
    {
      this.products= data;
    });
  }
}
