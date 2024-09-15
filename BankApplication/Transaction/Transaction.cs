namespace BankApplication
{
    class Transaction
    {
        public BankAccount FromAccount;
        public BankAccount ToAccount;
        public DateTime Date;
        public decimal Amount;
        public Verification Verification = null; // v defaultním stavu ještě transakce nebyla ověřena

        public Transaction(BankAccount fromAccount, BankAccount toAccount, DateTime date, decimal amount)
        {
            FromAccount = fromAccount;
            ToAccount = toAccount;
            Date = date;
            if(amount > 0)
            {
                Amount = amount;
            } else
            {
                throw new ArgumentOutOfRangeException(nameof(amount), amount, "Není možné zadat výběr nebo vklad menší nebo roven nule !!!");
            }
        }

        public bool HumanVerificationNeeded
        {
            get
            {
                return Amount > 100000;
            }
        }

        public void Execute()
        {
            if(FromAccount.Balance >= Amount)
            {
                FromAccount.Withdraw(Amount);
                ToAccount.Deposit(Amount);
                Console.WriteLine($"Transakce byla úspěšná, částka {Amount} byla převedena z účtu {FromAccount.AccountNumber} na účet {ToAccount.AccountNumber} dne {Date}.");
            } else
            {
                Console.WriteLine($"Transakce nebyla úspěšná, účet s číslem {FromAccount.AccountNumber} nemá dostatek finančních prostředků k provedení transakce");
            }
        }
    }

}
