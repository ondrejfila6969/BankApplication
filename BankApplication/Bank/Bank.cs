using System;

namespace BankApplication
{
    class Bank
    {
        public string Name;
        public List<BankAccount> Accounts;
        public List<Transaction> Transactions;

        public Bank(string name)
        {
            Name = name;
            Accounts = new List<BankAccount>();
            Transactions = new List<Transaction>();
        }

        public void AddAccount(BankAccount bankAccount)
        {
            Accounts.Add(bankAccount);
            Console.WriteLine($"Číslo účtu: {bankAccount.AccountNumber}, momentální finanční obnos: {bankAccount.Balance}, vlastník: {bankAccount.OwnerName}");
        }

        public void AddTransaction(Transaction transaction)
        {
            Transactions.Add(transaction);
            transaction.Execute();
        }

        public void PrintAccounts()
        {
            Console.WriteLine(".........Bankovní účty.........");
            foreach(var account in Accounts)
            {
                Console.WriteLine($"Číslo účtu: {account.AccountNumber}, aktuální finanční obnos: {account.Balance}, vlastník účtu: {account.OwnerName}");
            }
        }

        public void PrintTransactions()
        {
            Console.WriteLine(".........Proběhlé transakce.........");
            foreach(var transaction in Transactions)
            {
                Console.WriteLine($"Částka {transaction.Amount} byla převedena z účtu {transaction.FromAccount.AccountNumber} na účet {transaction.ToAccount.AccountNumber} dne {transaction.Date}");


            }
        }

        public void VerifyLargeTransactions(string verifier)
        {
            Random randomNumber = new Random();
            foreach(var transaction in Transactions)
            {
                if (transaction.HumanVerificationNeeded && transaction.Verification == null)
                {
                    VerificationResult verificationResult = (VerificationResult)randomNumber.Next(1, 5); // náhodně vygeneruje výsledek (od 1 do 4, protože celý enum)

                    transaction.Verification = new Verification(verifier, DateTime.Now, verificationResult, "Info :)");
                    Console.WriteLine($"Transakce ve výši {transaction.Amount} byla ověřena {verifier} a její výsledek je {verificationResult}");
                }
            }
        }

        public void PrintDeniedTransactions()
        {
            Console.WriteLine(".........Zamítnuté transakce.........");
            foreach(var transaction in Transactions)
            {
                if(transaction.HumanVerificationNeeded /* Je vyžadované ověření (částka je vyšší než 100000) */&& transaction.Verification != null /* Proběhlo ověření */ && transaction.Verification.VerificationResult == VerificationResult.Denied /* Výsledek - zamítnuto */)
                {
                    Console.WriteLine("Transakce byla zamítnuta !!!");
                    Console.WriteLine($"Z účtu {transaction.FromAccount.AccountNumber}, vlastníkem {transaction.FromAccount.OwnerName}");
                    Console.WriteLine($"Na účet {transaction.ToAccount.AccountNumber}, vlastníkem {transaction.ToAccount.OwnerName}");
                    Console.WriteLine($"Částka {transaction.Amount}");
                    Console.WriteLine($"Dodatečné info {transaction.Verification.FurtherInfo}");
                    Console.WriteLine($"Schválil {transaction.Verification.Verifier}");
                }
            }
        }
    }
}
