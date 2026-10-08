using System;

namespace BankApp
{
    class Program
    {
        static void Main()
        {
            Console.Write("Customer Name: ");
            string name = Console.ReadLine();

            string sortCode;
            do
            {
                Console.Write("Sort Code (6 digits): ");
                sortCode = Console.ReadLine();
            }
            while (!PremiumAccount.IsValidSortCode(sortCode));

            Console.Write("Account Number: ");
            string number = Console.ReadLine();

            PremiumAccount account = new PremiumAccount(name, sortCode, number);

            Console.Write("Initial Deposit: ");
            account.Balance = decimal.Parse(Console.ReadLine());

            for (int i = 1; i <= 3; i++)
            {
                Console.Write($"Transaction {i}: ");
                decimal amount = decimal.Parse(Console.ReadLine());

                if (account.ProcessTransaction(amount))
                    Console.WriteLine($"Success. Balance: £{account.Balance:F2}");
                else
                    Console.WriteLine("Transaction failed.");
            }

            Console.WriteLine("\n--- Final Account ---");
            Console.WriteLine(account);
            Console.WriteLine($"Final Balance: £{account.Balance:F2}");
        }
    }
}
