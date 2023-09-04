import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IProduct } from './iproduct';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http: HttpClient) { }

  private baseUrl= 'https://localhost:7271';


  
  getProducts(): Observable<IProduct[]>{
    return this.http.get<IProduct[]>(`${this.baseUrl}/api/Product`)
  }

  getSearchList(searchTerm:string):Observable<IProduct[]>
  {
    return this.http.get<IProduct[]>(`${this.baseUrl}/search?searchTerm=${searchTerm}`)
  }
}
