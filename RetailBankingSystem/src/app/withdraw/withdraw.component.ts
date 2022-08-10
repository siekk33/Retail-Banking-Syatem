import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { TransactionService } from '../service/transaction.service';

@Component({
  selector: 'app-withdraw',
  templateUrl: './withdraw.component.html',
  styleUrls: ['./withdraw.component.css']
})
export class WithdrawComponent implements OnInit {

  withdrawForm !: FormGroup;
  loading = false;
  submitted = false;
  error = '';
  message = '';
  accountIds: number[] = [];

  constructor(private formBuilder: FormBuilder, private transactionService:TransactionService) { }

  ngOnInit(): void {
    this.accountIds = this.transactionService.accountids;
    this.withdrawForm = this.formBuilder.group({
      accountid: ['', Validators.required],
      amount: ['', Validators.required]
    });
  }

  get f() { return this.withdrawForm.controls; }

  onSubmit() {
    this.submitted = true;
    // stop here if form is invalid
    if (this.withdrawForm.invalid) {
      return;
    }
    this.loading = true;
    this.transactionService.transactionWithdraw(this.f.accountid.value,this.f.amount.value)
      .pipe(first())
      .subscribe(
        data => {
          this.message = data.message;
          console.log(this.message);
          this.loading = false;
        },
        error => {
          this.error = error;
          this.loading = false;
      });
  }

}
