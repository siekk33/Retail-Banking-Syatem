import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AccountTransactionsComponent } from './account-transactions.component';

describe('AcctransactionsComponent', () => {
  let component: AccountTransactionsComponent;
  let fixture: ComponentFixture<AccountTransactionsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AccountTransactionsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AccountTransactionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
