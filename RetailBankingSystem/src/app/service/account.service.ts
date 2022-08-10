import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Account } from '../models/account';
import { Statement } from '../models/statement';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  constructor(private http: HttpClient) { }

  getById(id: number) {
    return this.http.get<Account[]>(`${environment.gatewayUrl}/customerAccountDetails/${id}`);
  }

  getAccountStatement(id:number,from:string,to:string) {
    return this.http.get<Statement[]>(`${environment.gatewayUrl}/accountStatement/${id}/${from}/${to}`);
    ////gateway/accountStatement/{id}/{fdate}/{tdate}
    ////Accounts/GetAccountStatement?accountId=${id}&fromDate=${from}&toDate=${to}
  }

  getAccountStatementNoDate(id:number) {
    return this.http.get<Statement[]>(`${environment.gatewayUrl}/accountStatement/${id}`);
    ////gateway/accountStatement/{id}/{fdate}/{tdate}
    ////Accounts/GetAccountStatement?accountId=${id}&fromDate=${from}&toDate=${to}
  }


}
