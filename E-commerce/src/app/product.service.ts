import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IProduct } from './iproduct';
import { Observable } from 'rxjs';
import { IProductDetails } from './iproduct-details';
import { Iwishlist } from './iwishlist';
import { ICartlist } from './icartlist';
import { IupdateWishlist } from './iupdate-wishlist';
import { IorderDetails } from './iorder-details';

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
 
  addToCart(cartList:ICartlist):Observable<any>
  {
    return this.http.post<any>(`${this.baseUrl}/api/Cart`,cartList)
  }

  viewCart(id:number):Observable<any>
  {
    return this.http.get<any>(`${this.baseUrl}/api/Cart/${id}`)
  }

  updateWishList(updateQuery:IupdateWishlist):Observable<void>
  {
    return this.http.put<void>(`${this.baseUrl}/api/WishList`,updateQuery)
  }

  deleteCart(id:number):Observable<any>
  {
    return this.http.delete<any>(`${this.baseUrl}/api/Cart?cartId=${id}`)
  }
  
  deleteWishList(id:number):Observable<any>
  {
    return this.http.delete<any>(`${this.baseUrl}/api/WishList?wishListId=${id}`)
  }
  
 getOrderDetails(id:number):Observable<any>
 {
  return this.http.get<any>(`${this.baseUrl}/api/OrderDetail?userId=${id}`)
 }

 placeOrder(order:any):Observable<any>{
  return this.http.post<any>(`${this.baseUrl}/api/Order/place-order`,order)
 }

 getProductStock(stock:number):Observable<any>{
  return this.http.get<any>(`${this.baseUrl}/api/Product/stock?ProductId=${stock}`)
}

 getOrderDetailsByDate(userId:number,startDate:Date,endDate:Date):Observable<any>{
  return this.http.get<IorderDetails>(`${this.baseUrl}/api/OrderDetail/search-by-date?userId=${userId}&startDate=${startDate}&endDate=${endDate}`)
 }

 getOrderDetailsByName(searchTerm:string,userId:number):Observable<any>{
  return this.http.get<IorderDetails>(`${this.baseUrl}/api/OrderDetail/search-by-name?searchTerm=${searchTerm}&userId=${userId}`)
 }
}
