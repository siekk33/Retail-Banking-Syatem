import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';
import { AuthenticationService } from '../service/authentication.service';
import { User } from '../models/user';
import { UserService } from '../service/user.service';
import { Role } from '../models/role';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  loading = false;
  user: User;
  userFromApi!: User;

  constructor(private userService: UserService,
    private authenticationService: AuthenticationService) { 
      this.user = this.authenticationService.userValue;
    }

  ngOnInit(): void {
    this.loading = true;
    this.userService.getById(this.user.id).pipe(first()).subscribe(user => {
        this.loading = false;
        this.userFromApi = user;
        console.log(this.userFromApi);
        // Setting account ids in session storage 
        sessionStorage.setItem('accounta',((this.userFromApi.id*10) +1).toString());
        sessionStorage.setItem('accountb',((this.userFromApi.id*10) +2).toString());
    });
  }

  //? removed to allow customer access to admins
  // get isAdmin() {
  //   return this.user && this.user.role != Role.Admin;
  // }

}
