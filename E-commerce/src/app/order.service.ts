import { Injectable } from '@angular/core';
import { IAddress } from './address/IAddress';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IUserAddress } from './address/IUserAddress';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  constructor(private http: HttpClient) { }

  private baseUrl= 'https://localhost:7271';

  getAddress(id:number): Observable<IUserAddress[]> {    
    return this.http.get<IUserAddress[]>(`${this.baseUrl}/api/Address?userId=${id}`);
  }
}
