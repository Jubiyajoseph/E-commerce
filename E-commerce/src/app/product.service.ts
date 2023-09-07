import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IProduct } from './iproduct';
import { Observable } from 'rxjs';
import { IProductDetails } from './iproduct-details';
import { Iwishlist } from './iwishlist';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http: HttpClient) { }

  private baseUrl= 'https://localhost:7271';


  
  getProducts(page:number): Observable<IProduct[]>{
    return this.http.get<IProduct[]>(`${this.baseUrl}/api/Product?page=${page}`)
  }

  getProductById(id:number):Observable<IProductDetails>{
    return this.http.get<IProductDetails>(`${this.baseUrl}/api/Product/${id}`)
  }

  getSearchList(searchTerm:string):Observable<IProduct[]>
  {
    return this.http.get<IProduct[]>(`${this.baseUrl}/api/Product/search?searchTerm=${searchTerm}`)
  }
  
  addWishList(wishlist:Iwishlist):Observable<any>
  {
    return this.http.post<any>(`${this.baseUrl}/api/WishList`,wishlist)
  }

  getWishlist(id:number):Observable<any>{
  return this.http.get<any>(`${this.baseUrl}/api/WishList?userId=${id}`)
}
}
