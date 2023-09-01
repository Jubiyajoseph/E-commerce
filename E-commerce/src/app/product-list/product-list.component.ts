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
  slicedproductList:IProduct[]=[];
  currentPage: number = 1;
  pageSize: number = 10;
  totalPages: number = 5;

  //search products
  public productFormGroup!: FormGroup;
  searchText = new FormControl('');
  filteredproduct:Array<IProduct>=[];
  constructor(private appService: EcommerceService,private formBuilder: FormBuilder,private router: Router) {
  
    
  }
  ngOnInit(): void 
  {   
    this.filteredproduct=this.products.filter(x=>x.Name.toLowerCase());
    this.loadProducts(this.currentPage);

  }

  loadProducts(page:number)
  {
    this.appService.getProducts().subscribe((data)=>
    {
      this.products = data;
    });
    const startIndex = (page-1) * this.pageSize;
    this.slicedproductList = this.products.slice(startIndex, startIndex+this.pageSize)
    this.currentPage = page;
  }
  search(){
    this.filteredproduct = this.products
  }
}
