import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { TransactionService } from '../service/transaction.service';

@Component({
  selector: 'app-deposit',
  templateUrl: './deposit.component.html',
  styleUrls: ['./deposit.component.css']
})
export class DepositComponent implements OnInit {

  depositForm !: FormGroup;
  loading = false;
  submitted = false;
  error = '';
  message = '';
  accountIds: number[] = [];

  constructor(private formBuilder: FormBuilder, private transactionService:TransactionService) { }

  ngOnInit(): void {
    // Retreving account ids from the service
    this.accountIds = this.transactionService.accountids;
    this.depositForm = this.formBuilder.group({
      accountid: ['', Validators.required],
      amount: ['', Validators.required]
    });
  }

  get f() { return this.depositForm.controls; }

  onSubmit() {
    this.submitted = true;
    // stop here if form is invalid
    if (this.depositForm.invalid) {
      return;
    }
    this.loading = true;
    this.transactionService.transactionDeposit(this.f.accountid.value,this.f.amount.value)
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
