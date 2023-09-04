import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private http: HttpClient) { }

  private baseUrl= 'https://localhost:7271';

   Login(username: string, password:string): Observable<any>
  {
    const body = {
      name: username,
      password: password
    }
    return this.http.post(`${this.baseUrl}/api/User/login`, body)   
  }
}
