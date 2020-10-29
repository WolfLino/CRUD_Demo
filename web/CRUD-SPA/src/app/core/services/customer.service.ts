import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Customer } from 'src/app/shared/models/customer.model';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  baseUrl = `${environment.apiUrl}/customer`;

  constructor(private http: HttpClient) { }

  getUsers(): Observable<Customer> {
    return this.http.get<Customer>(`${this.baseUrl}/`);
  }
}
