import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  constructor(private http: HttpClient) {}

  getAll() {
    return this.http.get<User[]>(`${environment.apiUrl}/users`);
  }

  getById(id: number) {
    return this.http.get<User>(`${environment.apiUrl}/users/${id}`);
  }

  createUser(id: number, firstname: string, lastname: string, username: string, password: string) {
    return this.http.post<any>(`${environment.apiUrl}/users/create`,{
      id,
      firstname,
      lastname,
      username,
      password
    });
  }
}
