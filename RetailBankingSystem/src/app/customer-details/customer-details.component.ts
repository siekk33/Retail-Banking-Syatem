import { Component, OnInit } from '@angular/core';
import { Customer } from '../models/customer';
import { CustomerService } from '../service/customer.service';
import { first } from 'rxjs/operators';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-customer-details',
  templateUrl: './customer-details.component.html',
  styleUrls: ['./customer-details.component.css']
})
export class CustomerDetailsComponent implements OnInit {

  loading = false;
  oneloading = false;
  customers: Customer[] = [];
  customerDetailsForm!: FormGroup;
  onecus: Customer = new Customer;
  submitted = false;
  dataready = false;
  error = '';

  constructor(private customerService: CustomerService,private formBuilder: FormBuilder) { }

  ngOnInit(): void {

    this.customerDetailsForm = this.formBuilder.group({
      customerId: ['', Validators.required]
    });

    this.loading = true;
    this.customerService.getAll().pipe(first()).subscribe(customers => {
        this.loading = false;
        this.customers = customers;
    });
  }

  get f() { return this.customerDetailsForm.controls; }

  onSubmit(){
    this.submitted = true;
    if (this.customerDetailsForm.invalid) {
      return;
    }
    this.oneloading = true;
    this.dataready = true;
    this.customerService.getById(this.f.customerId.value).pipe(first()).subscribe(onecus => {
        this.oneloading = false;
        this.onecus = onecus;
        },error => {
          this.error = error;
          this.loading = false;
          this.dataready = false;
        });
  }

}
