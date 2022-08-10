import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { AdminComponent } from './admin/admin.component';
import { AuthGuard } from './guard/auth.guard';
import { Role } from './models/role';
import { CustomerDetailsComponent } from './customer-details/customer-details.component';
import { CustomerCreateComponent } from './customer-create/customer-create.component';
import { AccountDetailsComponent } from './account-details/account-details.component';
import { AccountStatementComponent } from './account-statement/account-statement.component';
import { AccountTransactionsComponent } from './account-transactions/account-transactions.component';
import { DepositComponent } from './deposit/deposit.component';
import { WithdrawComponent } from './withdraw/withdraw.component';
import { TransferComponent } from './transfer/transfer.component';
const routes: Routes = [
  {
    path: 'home',  // hhtp:localhost.com/home
    component: HomeComponent,
    canActivate: [AuthGuard],
    data: { roles: [Role.Admin, Role.User] }
},
{
    path: 'admin',
    component: AdminComponent,
    canActivate: [AuthGuard],
    data: { roles: [Role.Admin] }
},
{
    path: '',
    component: LoginComponent
},
{
  path: 'customerdetails',
  component: CustomerDetailsComponent,
  canActivate: [AuthGuard],
  data: { roles: [Role.Admin] }
},
{
  path: 'customercreate',
  component: CustomerCreateComponent,
  canActivate: [AuthGuard],
  data: { roles: [Role.Admin] }
},
{
  path: 'accountdetails',
  component: AccountDetailsComponent,
  canActivate: [AuthGuard],
  data: { roles: [Role.Admin, Role.User] }
},
{
  path: 'accountstatement',
  component: AccountStatementComponent,
  canActivate: [AuthGuard],
  data: { roles: [Role.Admin, Role.User] }
},
{
  path: 'accounttransactions',
  component: AccountTransactionsComponent,
  canActivate: [AuthGuard],
  data: { roles: [Role.Admin, Role.User] }
},
{
  path: 'deposit',
  component: DepositComponent,
  canActivate: [AuthGuard],
  data: { roles: [Role.Admin, Role.User] }
},
{
  path: 'withdraw',
  component: WithdrawComponent,
  canActivate: [AuthGuard],
  data: { roles: [Role.Admin, Role.User] }
},
{
  path: 'transfer',
  component: TransferComponent,
  canActivate: [AuthGuard],
  data: { roles: [Role.Admin, Role.User] }
},

// otherwise redirect to home
{ path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
