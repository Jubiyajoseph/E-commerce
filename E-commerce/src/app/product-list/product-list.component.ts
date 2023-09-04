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
  slicedproductList:Array<IProduct>=[];
  currentPage: number = 1;
  pageSize: number = 10;
  totalPages: number = 5;

  //search products
  public productFormGroup!: FormGroup;
  searchTerm!: string;
  filteredSearchList:Array<IProduct>=[];
  constructor(private productService: ProductService,private formBuilder: FormBuilder,private router: Router) {
  
    
  }
  ngOnInit(): void 
  {   
    //this.filteredproduct=this.products.filter(x=>x.Name.toLowerCase());
    this.loadProducts();

  }

  loadProducts()
  {
    this.productService.getProducts().subscribe((data)=>
    {
      this.products = data;
    });
    
  }

  search(){
    this.productService.getSearchList(this.searchTerm).subscribe((data)=>
    {
      this.products= data;
    });
  }
}
