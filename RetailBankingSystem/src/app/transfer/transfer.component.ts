import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { TransactionService } from '../service/transaction.service';

@Component({
  selector: 'app-transfer',
  templateUrl: './transfer.component.html',
  styleUrls: ['./transfer.component.css']
})
export class TransferComponent implements OnInit {


  transferForm !: FormGroup;
  loading = false;
  submitted = false;
  error = '';
  message = '';
  accountIds: number[] = [];

  constructor(private formBuilder: FormBuilder, private transactionService:TransactionService) { }

  ngOnInit(): void {
    this.accountIds = this.transactionService.accountids;
    this.transferForm = this.formBuilder.group({
      saccountid: ['',Validators.required],
      taccountid: ['', Validators.required],
      amount: ['', Validators.required]
    });
  }

  get f() { return this.transferForm.controls; }

  onSubmit() {
    this.submitted = true;
    ////console.log(this.f.amount.value);
    // stop here if form is invalid
    if (this.transferForm.invalid) {
      return;
    }
    this.loading = true;
    this.transactionService.transactionTransfer(this.f.saccountid.value,this.f.taccountid.value,this.f.amount.value)
      .pipe(first())
      .subscribe(
        data => {
          console.log(data[0].message);
          this.message = data[0].message;
          this.loading = false;
        },
        error => {
          this.error = error;
          this.loading = false;
      });
  }

}
