import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { CustomerService } from '../service/customer.service';
import { UserService } from '../service/user.service';

@Component({
  selector: 'app-customer-create',
  templateUrl: './customer-create.component.html',
  styleUrls: ['./customer-create.component.css']
})
export class CustomerCreateComponent implements OnInit {

  customerCreateForm!: FormGroup;
  loading = false;
  info = '';
  success = '';
  submitted = false;
  returnUrl!: string;
  error = '';
  tempCustomerId :any;
  

  constructor(private formBuilder: FormBuilder, private customerService: CustomerService, private userService: UserService) { }

  ngOnInit(): void {
    // Setting Default value for the diabled input as it is auto generated
    this.tempCustomerId = 1;
    // Form validation 
    this.customerCreateForm = this.formBuilder.group({
      customerid: ['', Validators.required],
      firstname: ['', Validators.required],
      lastname: ['', Validators.required],
      address: ['', Validators.required],
      dateofbirth: ['', Validators.required],
      pannumber: ['', Validators.required],
      username: ['', Validators.required],
      password: ['', Validators.required]
    });

  }

  get f() { return this.customerCreateForm.controls; }

  onSubmit() {
    this.submitted = true;
    if (this.customerCreateForm.invalid) {
      return;
    }
    this.loading = true;
    this.info = 'Creating Customer';
    this.customerService.createCustomer(
      this.f.customerid.value,
      this.f.firstname.value,
      this.f.lastname.value,
      this.f.address.value,
      this.f.dateofbirth.value,
      this.f.pannumber.value
    ).pipe(first()).subscribe(

      data => {
        console.log(data);
        this.loading = false;
      },
      error => {
        this.error = error;
        this.loading = false;
      });

      this.info = 'Creating User';
      this.loading = true;
      this.userService.createUser(
        this.f.customerid.value,
        this.f.firstname.value,
        this.f.lastname.value,
        this.f.username.value,
        this.f.password.value
      ).pipe(first()).subscribe(
        data => {
          this.loading = false;
        },
        error => {
          this.error = error;
          this.loading = false;
        });
      this.info='';
      this.success = 'User created Successfully';
  }

}
