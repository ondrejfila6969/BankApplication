using System.Globalization;

namespace BankApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount firstAccount = new BankAccount(2000000, "Ondřej Fíla");
            BankAccount secondAccount = new BankAccount(1300000, "Roman Brdlík");


            /*  AccountNumber se navyšuje o 1
            BankAccount thirdAccount = new BankAccount(800, "Petr Kredba");
            BankAccount fourthAccount = new BankAccount(900, "Ondřej Tomšíček");
            */

            /* Vyhodí to výjimku
            BankAccount thirdAccount = new BankAccount(2, -500, "Roman Brdlík");
            Console.WriteLine(thirdAccount);
            BankAccount thirdAccount = new BankAccount(2, 500, "");
            Console.WriteLine(thirdAccount);
            BankAccount thirdAccount = new BankAccount(2, -500,"");
            Console.WriteLine(thirdAccount);
            */


            // Výpisy před provedení transakce
            /*
            Console.WriteLine($"Číslo účtu je {firstAccount.AccountNumber}, momentální finanční obnos je {firstAccount.Balance} a vlastníkem tohoto účtu je {firstAccount.OwnerName}");
            Console.WriteLine($"Číslo účtu je {secondAccount.AccountNumber}, momentální finanční obnos je {secondAccount.Balance} a vlastníkem tohoto účtu je {secondAccount.OwnerName}");
            */

            Transaction firstTransaction = new Transaction(firstAccount, secondAccount, DateTime.Now, 110000);
            firstTransaction.Execute();
            Transaction secondTransaction = new Transaction(secondAccount, firstAccount, DateTime.Now, 200000);
            secondTransaction.Execute();
            Transaction thirdTransaction = new Transaction(firstAccount, secondAccount, DateTime.Now, 300000);
            thirdTransaction.Execute();

            Bank bank = new Bank("Ondrova banka se 100% úroky :)");
            bank.AddAccount(firstAccount);
            bank.AddAccount(secondAccount);
            bank.AddTransaction(firstTransaction);
            bank.AddTransaction(secondTransaction);
            bank.AddTransaction(thirdTransaction);

            bank.PrintAccounts();
            bank.PrintTransactions();


            // Výpisy po provedení transakce
            /*
            Console.WriteLine($"Číslo účtu je {firstAccount.AccountNumber}, momentální finanční obnos je {firstAccount.Balance} a vlastníkem tohoto účtu je {firstAccount.OwnerName}");
            Console.WriteLine($"Číslo účtu je {secondAccount.AccountNumber}, momentální finanční obnos je {secondAccount.Balance} a vlastníkem tohoto účtu je {secondAccount.OwnerName}");
            */

            bank.VerifyLargeTransactions("Pepa Novák");
            // Zamítnuté transakce (někdy vypíše jenom ten nadpis, protože se nevygeneruje číslo příslušné k pozici Denied v enumu)
            bank.PrintDeniedTransactions();


            Console.ReadLine();
        }
    }

}
