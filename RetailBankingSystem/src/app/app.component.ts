import { Component } from '@angular/core';
import { AuthenticationService } from './service/authentication.service';
import { Role } from './models/role';
import { User } from './models/user';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'RetailBankingSystem';
  user: User = new User;

  constructor(private authenticationService: AuthenticationService) {
    this.authenticationService.user.subscribe((x) => (this.user = x));
  }

  // To check if user is admin
  get isAdmin() {
    return this.user && this.user.role === Role.Admin;
  }

  get isloggedin() {
    return sessionStorage.getItem('loginstatus')==='yes';
  }

  logout() {
    this.authenticationService.logout();
  }
}
