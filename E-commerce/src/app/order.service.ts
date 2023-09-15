import { Injectable } from '@angular/core';
import { IAddress } from './address/IAddress';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IUserAddress } from './address/IUserAddress';
import { IDefaultUserAddress } from './address/IDefaultUserAddress';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  constructor(private http: HttpClient) { }

  private baseUrl= 'https://localhost:7271';

  getAddress(id:number): Observable<IUserAddress[]> {    
    return this.http.get<IUserAddress[]>(`${this.baseUrl}/api/Address?userId=${id}`);
  }

  getDefaultAddress(id:number): Observable<any> {    
    return this.http.get<any>(`${this.baseUrl}/api/Address/default/${id}`);
  }

  updateDefaultAddress(changeDefaultAddress: any): Observable<any>{
    return this.http.put<any>(`${this.baseUrl}/api/Address/update-default-address`,changeDefaultAddress); 
  }

  cancelOrder(cancelOrder:any):Observable<any>{
    return this.http.put<any>(`${this.baseUrl}/api/Order`,cancelOrder)
   }

   updateStock(productStockUpdate: any): Observable<any>{
    return this.http.put<any>(`${this.baseUrl}/api/Order/stock-update-on-cancel-order`,productStockUpdate)
   }
}
