class Account {
    public AccNo: String;
    public Balance: Number;

    constructor(accNo, balance) {
        this.AccNo = accNo;
        this.Balance = balance;
    }

    DebitAmount(): Number { return 0 }
    CreditAmount(): Number { return 0 }
    GetBalance(): Number { return this.Balance }
}


interface IAccount {
    DateOfOpening;

    AddCustomer(): void;
    RemoveCustomer(): void;
}

class SavingAccount extends Account implements IAccount {
    MinBalance: any;
    DateOfOpening: any;
    AddCustomer() {
        //throw new Error("Method not implemented.");
    }
    RemoveCustomer() {
        //throw new Error("Method not implemented.");
    }
}

class CurrentAccount extends Account implements IAccount {
    IntrestRate: any;
    DateOfOpening: any;
    AddCustomer() {
        //throw new Error("Method not implemented.");
    }
    RemoveCustomer() {
        //throw new Error("Method not implemented.");
    }
}
