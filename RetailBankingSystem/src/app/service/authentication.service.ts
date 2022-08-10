import { Injectable } from '@angular/core';
import { User } from '../models/user';
import { environment } from 'src/environments/environment';
import { BehaviorSubject, Observable } from 'rxjs';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class AuthenticationService {
  private userSubject: BehaviorSubject<User>;
    public user: Observable<User>;

  constructor(private router: Router, private http: HttpClient) {
    this.userSubject = new BehaviorSubject<User>(JSON.parse(sessionStorage.getItem('user') || '{}') as User);
    this.user = this.userSubject.asObservable();
  }
  public get userValue(): User {
    return this.userSubject.value;
  }

  login(username: string, password: string) {
    return this.http
      .post<any>(`${environment.apiUrl}/users/authenticate`, {
        username,
        password,
      })
      .pipe(
        map((user) => {
          // store user details and jwt token in session storage to keep user logged in between page refreshes
          sessionStorage.setItem('user', JSON.stringify(user));
          sessionStorage.setItem('loginstatus','yes');
          this.userSubject.next(user);
          return user;
        })
      );
  }

  logout() {
    // remove user from session storage to log user out
    sessionStorage.removeItem('user');
    sessionStorage.removeItem('accounta');
    sessionStorage.removeItem('accountb');
    sessionStorage.setItem('loginstatus','no');
    const usernull = <User>{};
    this.userSubject.next(usernull);
    this.router.navigate(['/']);
  }
}
