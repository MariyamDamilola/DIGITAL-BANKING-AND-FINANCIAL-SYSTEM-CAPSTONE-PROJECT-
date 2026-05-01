using DigitalBankingAndFinancialSystem.Models;
using DigitalBankingAndFinancialSystem.Data;
namespace DigitalBankingAndFinancialSystem.Services;

public class TransactionService
{
    public string Deposit(string accountNumber, decimal amount)
    {
        var account = DataStore.Accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
        if (account == null) return "Account not found";

        if (amount <= 0) return "Amount must be greater than zero";

        account.Balance += amount;
        
        //Log the transaction
        DataStore.Transactions.Add(new Transaction
        {
            TransactionId = Guid.NewGuid().ToString(),
            SourceAccountNumber = accountNumber,
            Amount = amount,
            TransactionType = TransactionType.Deposit,
            Timestamp =  DateTime.Now
        });
        return "Deposit successful";
    }

    public string Withdraw(string accountNumber, decimal amount)
    {
        var account = DataStore.Accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);

        if (account == null) return "Account not found";
        if (amount <= 0) return "Amount must be greater thann Zero";

        if (amount > account.Balance)
        {
            return $"Insufficient funds. Your current balance is {account.Balance:C}";
        }

        account.Balance -= amount;
        
        DataStore.Transactions.Add(new Transaction
        {
            TransactionId = Guid.NewGuid().ToString(),
            SourceAccountNumber = accountNumber,
            Amount = amount,
            TransactionType = TransactionType.Withdraw,
            Timestamp =  DateTime.Now 
        });
        return "Withdrawal successful";
    }
    
    //Transfer
    public string Transfer(string sourceAccNo, decimal amount, string destinationAccNo)
    {
        if (sourceAccNo == destinationAccNo)
        {
            return "Source and Destination accounts cannot be the same";
        }

        if (amount <= 0)
        {
            return "Transfer amount must be greater than zero";
        }

        var sourceAcct = DataStore.Accounts.FirstOrDefault(a => a.AccountNumber == sourceAccNo);
        var destinationAcct = DataStore.Accounts.FirstOrDefault(a => a.AccountNumber == destinationAccNo);

        //Locate both account
        if (sourceAcct == null) return "Source account not found";
        if (destinationAcct == null) return "Destination account not found";
        
        //Check if Source account have enough funds
        if (amount > sourceAcct.Balance)
        {
            return "Transfer failed: Insufficient funds";
        }

        sourceAcct.Balance -= amount;
        destinationAcct.Balance += amount;
        //Log the Transaction
        string transactionGroupId = Guid.NewGuid().ToString();
        
        //Debit Entry
        DataStore.Transactions.Add(new Transaction
        {
            TransactionId = Guid.NewGuid().ToString(),
            SourceAccountNumber = sourceAccNo,
            DestinationAccountNumber = destinationAccNo, 
            Amount = amount,
            TransactionType = TransactionType.Transfer,
            Timestamp = DateTime.Now
        });
        return $"Successfully transferred {amount:C} to {destinationAcct.AccountName}.";
    }
    
    //Get All transaction (Admin)
    public List<Transaction> GetAllTransactions()
    {
        return DataStore.Transactions.OrderByDescending(t => t.Timestamp).ToList();
    }
    
    
    //Delete Transaction
    public string DeleteTransaction(string transactionId)
    {
        var transaction = DataStore.Transactions.FirstOrDefault(t => t.TransactionId == transactionId);
        if (transaction == null)
        {
            return "Error: Transaction record not found";
        }
        DataStore.Transactions.Remove(transaction);
        return "Successfully deleted transaction";
    }
}