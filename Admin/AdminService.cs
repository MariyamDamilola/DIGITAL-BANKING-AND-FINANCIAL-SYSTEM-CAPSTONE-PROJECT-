using DigitalBankingAndFinancialSystem.Data;
using DigitalBankingAndFinancialSystem.Models;

namespace DigitalBankingAndFinancialSystem.Admin;

public class AdminService
{
 //Total System balance
 public decimal GetTotalSystemBalance() =>
        DataStore.Accounts.Sum(a => a.Balance);
 
 //Top 5 accounts by balance
 public List<Account> GetTopFiveAccounts() =>
        DataStore.Accounts.OrderByDescending(a => a.Balance).Take(5).ToList();

 //Transaction volume breakdown
 public Dictionary<TransactionType, int> GetTransactionVolume() =>
        DataStore.Transactions.GroupBy(t => t.TransactionType)
 .ToDictionary(g => g.Key, g => g.Count());


 //Inactive accounts
 public List<Account> GetInactiveAccounts() =>
        DataStore.Accounts.Where(a => a.Balance == 0).ToList();
 
 //Largest single Transaction
 public Transaction GetHighestTransaction() =>
        DataStore.Transactions.OrderByDescending(t => t.Amount).FirstOrDefault();
 
 //Average Transaction value
 public decimal GetAverageTransactionValue() =>
        DataStore.Transactions.Any()? DataStore.Transactions.Average(t => t.Amount) : 0;

 //System reset
 public void ResetSystem()
 {
        DataStore.Accounts.Clear();
        DataStore.Transactions.Clear();
 }

}

