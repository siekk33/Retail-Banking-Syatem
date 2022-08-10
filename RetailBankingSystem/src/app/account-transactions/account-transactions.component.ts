import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';
import { Transaction } from '../models/transaction';
import { TransactionService } from '../service/transaction.service';

@Component({
  selector: 'app-account-transactions',
  templateUrl: './account-transactions.component.html',
  styleUrls: ['./account-transactions.component.css']
})
export class AccountTransactionsComponent implements OnInit {

  loading = false;
  transactions: Transaction[] = [];

  constructor(private transactionService:TransactionService) { }

  ngOnInit(): void {
    this.loading = true;
    this.transactionService.getTransactions(JSON.parse(sessionStorage.getItem('user')!).id).pipe(first()).subscribe(transactions => {
        this.loading = false;
        this.transactions = transactions;
        console.log(this.transactions);
    });
  }

}
