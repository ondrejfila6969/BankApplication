namespace BankApplication
{
    class BankAccount
    {
        private static int LastAccountNumber = 0;
        public int AccountNumber;
        public decimal Balance;
        public string OwnerName;

        public BankAccount(int balance, string ownerName)
        {
            LastAccountNumber++;
            this.AccountNumber = LastAccountNumber;
            if(balance > 0)
            {
                this.Balance = balance;
            } else
            {
                throw new Exception("Zůstatek na účtě nesmí být menší nebo roven nule !!!");
            }
            if (ownerName != null && ownerName != "") // kontroluje, zda jméno majitele je null nebo prázdný řetězec
            {
                this.OwnerName = ownerName;
            } else
            {
                throw new ArgumentOutOfRangeException(nameof(ownerName), ownerName, "Jméno majitele účtu nesmí být prázdný řetězec !!!");
            }
        }

        public void Deposit(decimal amount)
        {
            this.Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if(this.Balance >= amount) // nelze přeci vybrat víc peněz než máme na účtě :)
            {
                this.Balance -= amount;
            } else
            {
                throw new InvalidOperationException("Není možné vybrat peníze, protože účet nemá dostatek finančních prostředků");
            }
        }
    }

}
