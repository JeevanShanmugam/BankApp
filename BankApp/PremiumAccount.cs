using System;

namespace BankApp
{
    public class PremiumAccount
    {
        public string CustomerName { get; set; }
        public string SortCode { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public decimal OverdraftLimit { get; set; } = 1000;
        public decimal DailyTransactionLimit { get; set; } = 500;

        public PremiumAccount(string name, string sortCode, string accountNumber)
        {
            CustomerName = name;
            SortCode = sortCode;
            AccountNumber = accountNumber;
        }

        public override string ToString()
        {
            return $"{CustomerName} (Sort Code: {SortCode}, Account No: {AccountNumber})";
        }

        public bool ProcessTransaction(decimal amount)
        {
            if (amount > DailyTransactionLimit ||
                Balance - amount < -OverdraftLimit)
                return false;

            Balance -= amount;
            return true;
        }

        public static bool IsValidSortCode(string code)
        {
            return code.Length == 6 && long.TryParse(code, out _);
        }
    }
}