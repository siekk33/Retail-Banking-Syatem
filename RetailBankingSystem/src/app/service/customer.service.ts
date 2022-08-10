import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Customer } from '../models/customer';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  constructor(private http: HttpClient) {}

  getAll() {
    return this.http.get<Customer[]>(`${environment.gatewayUrl}/customers`);
  }

  getById(id: number) {
    return this.http.get<Customer>(`${environment.gatewayUrl}/customerDetails/${id}`);
  }

  createCustomer(customerid: number, firstname: string, lastname: string, address: string, dateofbirth: string, pannumber: string) {
    return this.http.post<any>(`${environment.gatewayUrl}/createcustomer`,{
      customerid,
      firstname,
      lastname,
      address,
      dateofbirth,
      pannumber,
    });
  }
}
