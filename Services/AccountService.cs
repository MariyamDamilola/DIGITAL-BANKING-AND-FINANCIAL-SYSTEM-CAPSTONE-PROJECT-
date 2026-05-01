using DigitalBankingAndFinancialSystem.Models;
using DigitalBankingAndFinancialSystem.Data;

namespace DigitalBankingAndFinancialSystem.Services;

public  class AccountService
{
    public string GenerateAccountNumber()
    {
        if (!DataStore.Accounts.Any())
            return "1001";

        int maxId = DataStore.Accounts.Max(a => int.Parse(a.AccountNumber));
            return (maxId + 1).ToString();
    }
    
    //Create
    public string AddAccount(Account newAccount)
    {
        if (DataStore.Accounts.Any(a => a.AccountNumber == newAccount.AccountNumber))
        {
             return "Account already exists";
            
        }

        DataStore.Accounts.Add(newAccount);
            return "Account created successfully";
    }
    
    //Read
    public List<Account> GetAccounts()
    {
        return DataStore.Accounts.ToList();
    }

    public string GetSpecificAccount(string accountNumber)
    {
        return DataStore.Accounts.FirstOrDefault(a => a.AccountNumber == accountNumber)?.AccountName;
    }
    
    //Update
    public bool EditAccount(Account editedAccount)
    {
        var existing = DataStore.Accounts.FirstOrDefault(a => a.AccountNumber == editedAccount.AccountNumber);
        if (existing == null) 
            return false;

        existing.AccountName = editedAccount.AccountName;
        existing.Pin = editedAccount.Pin;
        return true;
    }
    
    //Delete
    public string DeleteAccount(string accountNumber)
    {
        var account = DataStore.Accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
        if (account == null)
        {
            return  "Account not found";
        }
        DataStore.Accounts.Remove(account);
        return "Account deleted successfully";
    }
   
}