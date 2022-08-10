import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Transaction } from '../models/transaction';

@Injectable({
  providedIn: 'root'
})
export class TransactionService {

  accountids = [+sessionStorage.getItem('accounta')!,+sessionStorage.getItem('accountb')!];

  constructor(private http: HttpClient) { }

  getTransactions (customerid: number) {
    return this.http.get<Transaction[]>(`${environment.gatewayUrl}/transactions/${customerid}`);
  }

  transactionDeposit (accountid: number, amount: number) {
    return this.http.post<any>(`${environment.gatewayUrl}/tDeposit/${accountid}/${amount}`,{});
  }

  transactionWithdraw (accountid: number, amount: number) {
    return this.http.post<any>(`${environment.gatewayUrl}/tWithdraw/${accountid}/${amount}`,{});
  }

  transactionTransfer (sourceAccountid: number,targetAccountid: number, amount: number) {
    return this.http.post<any>(`${environment.gatewayUrl}/tTransfer/${sourceAccountid}/${targetAccountid}/${amount}`,{});

  }

}
