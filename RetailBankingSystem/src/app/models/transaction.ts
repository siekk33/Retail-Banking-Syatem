import { Account } from "./account";
import { Counterparty } from "./counterparty";
import { PaymentMethods } from "./payment-methods";
import { Service } from "./service";
import { TransactionStatus } from "./transaction-status";
import { TransactionTypes } from "./transaction-type";

export class Transaction {

    transaction_Id !:number;
    account !: Account;
    account_Id !: number;
    counterparty !: Counterparty;
    counterparty_Id !: number;
    payment_Methods !: PaymentMethods;
    payment_Method_Code !: string;
    services !: Service;
    service_Id !: number;
    transaction_Status !: TransactionStatus;
    transaction_Status_Code !: string;
    transaction_Types !: TransactionTypes;
    transaction_Type_Code !: string;
    date_of_Transaction !: Date;
    amount_of_Transaction !: number;

}

// "transaction_Id": 1000,
//     "account": null,
//     "account_Id": 1001,
//     "counterparty": null,
//     "counterparty_Id": 1,
//     "payment_Methods": null,
//     "payment_Method_Code": "PMCode1",
//     "services": null,
//     "service_Id": 1,
//     "transaction_Status": null,
//     "transaction_Status_Code": "TSC01",
//     "transaction_Types": null,
//     "transaction_Type_Code": "T01",
//     "date_of_Transaction": "2020-11-07T00:00:00",
//     "amount_of_Transaction": 1000