import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';
import { Account } from '../models/account';
import { AccountService } from '../service/account.service';

@Component({
  selector: 'app-account-details',
  templateUrl: './account-details.component.html',
  styleUrls: ['./account-details.component.css']
})
export class AccountDetailsComponent implements OnInit {

  loading = false;
  accounts : Account[] = [];
  // Retreving customer id from session storage
  customerId : number = JSON.parse(sessionStorage.getItem('user')!).id;
  totalBalance : number = 0;

  constructor(private accountService:AccountService) { }

  ngOnInit(): void {

    this.loading = true;
    this.accountService.getById(this.customerId).pipe(first()).subscribe(accounts => {
        this.loading = false;
        this.accounts = accounts;
        console.log(accounts);
        accounts.forEach(item => {
          this.totalBalance += item.balance_Amount;
        });
    });
  }

}
