import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { Statement } from '../models/statement';
import { AccountService } from '../service/account.service';

@Component({
  selector: 'app-account-statement',
  templateUrl: './account-statement.component.html',
  styleUrls: ['./account-statement.component.css']
})
export class AccountStatementComponent implements OnInit {

  loading = false;
  statementForm!: FormGroup;
  submitted = false;
  error = '';
  statementlist: Statement[]=[];
  tempstatementlist: Statement[]=[];
  dataready = false;

  constructor(private accountService:AccountService,private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.statementForm = this.formBuilder.group({
      fromdate: ['', Validators.required],
      todate: ['', Validators.required]
    });
    
  }

  get f() { return this.statementForm.controls; }

  onSubmit() {

    this.submitted = true;

    //stop here if form is invalid
    if (this.statementForm.invalid) {
      this.statementForm.clearValidators();
      this.accountService.getAccountStatementNoDate(JSON.parse(sessionStorage.getItem('accounta')!)).pipe(first()).subscribe(
        statements => {
          this.tempstatementlist = statements;
          console.log(this.statementlist);
          this.accountService.getAccountStatementNoDate(JSON.parse(sessionStorage.getItem('accountb')!)).pipe(first()).subscribe(
          statements2 => {
          this.loading = false;
          this.dataready = true;
          this.statementlist = this.tempstatementlist.concat(statements2);
          console.log(this.statementlist);
          });
        },
      error => {
        this.error =error;
        this.loading =false;
      });
      return;
    }
    this.loading = true;
    this.accountService.getAccountStatement(JSON.parse(sessionStorage.getItem('accounta')!),this.f.fromdate.value,this.f.todate.value).pipe(first()).subscribe(
      statements => {
        //this.loading = false;
        this.tempstatementlist = statements;
        console.log(this.statementlist);
        this.accountService.getAccountStatement(JSON.parse(sessionStorage.getItem('accountb')!),this.f.fromdate.value,this.f.todate.value).pipe(first()).subscribe(
          statements2 => {
          this.loading = false;
          this.dataready = true;
          this.statementlist = this.tempstatementlist.concat(statements2);
          console.log(this.statementlist);
        });
    },
    error => {
      this.error =error;
      this.loading =false;
    });

  }

}
