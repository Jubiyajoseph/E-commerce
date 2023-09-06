import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
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
  
 

  
  public productFormGroup!: FormGroup;
  
  filteredSearchList:Array<IProduct>=[];
  constructor(private productService: ProductService,private formBuilder: FormBuilder) {
    this.productFormGroup = this.formBuilder.group({
       searchTerm: [''] })
    
  }
  ngOnInit()
  {     
    this.loadProducts(this.currentPage);
  }

  loadProducts(page:number)
  {
    this.productService.getProducts(page).subscribe((data)=>
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

  search()
  {
    const searchTerm = this.productFormGroup.value.searchTerm
     this.productService.getSearchList(searchTerm).subscribe((data)=>
     {
      this.products = data;});
  }

}