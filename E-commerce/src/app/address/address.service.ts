import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ICity } from './Icity';
import { IState } from './Istate';
import { ICountry } from './Icountry';
import { IAddress } from './IAddress';

@Injectable({
  providedIn: 'root'
})
export class AddressService {

  constructor(private http: HttpClient) { }

  private baseUrl= 'https://localhost:7271';

  getCities(): Observable<ICity[]> {    
    return this.http.get<ICity[]>(`${this.baseUrl}/api/City`);
  }

  getState(): Observable<IState[]>{
    return this.http.get<IState[]>(`${this.baseUrl}/api/State`);
  }

  getCountry(): Observable<ICountry[]>{
    return this.http.get<ICountry[]>(`${this.baseUrl}/api/Country`);
  }

  addAddress(address: IAddress): Observable<any> {
    return this.http.post(`${this.baseUrl}/api/Address`, address);
  }

  getUserId(userName: string): Observable<any> {
    return this.http.get(`${this.baseUrl}/api/User?name=${userName}`)
  }
}
