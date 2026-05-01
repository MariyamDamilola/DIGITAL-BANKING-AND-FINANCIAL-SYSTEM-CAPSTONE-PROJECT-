using DigitalBankingAndFinancialSystem.Models;
namespace DigitalBankingAndFinancialSystem.Data;

public class DataStore
{
    public static List<Account> Accounts { get; set; } = new();

    public static List<Transaction> Transactions { get; set; } = new();

    static DataStore()
    {
        SeedData();
    }

    private static void SeedData()
    {
        Accounts.Add(new SavingsAccount{AccountNumber = "1001", AccountName = "Bola", Balance = 5000.00m, AccountType = AccountType.Savings, InterestRate = 2.5m});
        Accounts.Add(new CurrentAccount{AccountNumber = "1002", AccountName = "Oyin", Balance = 1500.50m, AccountType = AccountType.Current, OverdraftLimit = 500.00m});
        Accounts.Add(new SavingsAccount{AccountNumber = "1003", AccountName = "Ewa", Balance = 12000.00m, AccountType = AccountType.Savings, InterestRate = 3.0m});
        Accounts.Add(new CurrentAccount{AccountNumber = "1004", AccountName = "Gbadebo", Balance = 6000.00m, AccountType = AccountType.Current, OverdraftLimit = 200.00m});
        Accounts.Add(new SavingsAccount{AccountNumber = "1005", AccountName = "Ayinla", Balance = 750.25m, AccountType = AccountType.Savings, InterestRate = 4.0m});
        Accounts.Add(new SavingsAccount{AccountNumber = "1006", AccountName = "Ali", Balance = 7100.00m, AccountType = AccountType.Savings, InterestRate = 1.5m});
        Accounts.Add(new CurrentAccount{AccountNumber = "1007", AccountName = "Baba", Balance = 1300.50m, AccountType = AccountType.Current, OverdraftLimit = 350.00m});
        Accounts.Add(new SavingsAccount{AccountNumber = "1008", AccountName = "Ola", Balance = 19000.00m, AccountType = AccountType.Savings, InterestRate = 3.9m});
        Accounts.Add(new CurrentAccount{AccountNumber = "1009", AccountName = "Faith", Balance = 8000.00m, AccountType = AccountType.Current, OverdraftLimit = 180.00m});
        Accounts.Add(new SavingsAccount{AccountNumber = "1010", AccountName = "Boss", Balance = 250.25m, AccountType = AccountType.Savings, InterestRate = 2.7m});

        // Transactions
        Transactions.Add(new Transaction{TransactionId = "TRX01", Amount = 1000m, TransactionType = TransactionType.Deposit, DestinationAccountNumber = "1001", Timestamp = DateTime.Now.AddDays(-5), Description = "Initial Deposit"});
        Transactions.Add(new Transaction{TransactionId = "TRX02",Amount = 200m, TransactionType = TransactionType.Withdraw, SourceAccountNumber = "1002", Timestamp = DateTime.Now.AddDays(-4), Description = "ATM Withdrawal"});
        Transactions.Add(new Transaction{TransactionId = "TRX03",Amount = 500m, TransactionType = TransactionType.Transfer, SourceAccountNumber = "1003", Timestamp = DateTime.Now.AddDays(-3), Description = "Rent Payment"});
        Transactions.Add(new Transaction{TransactionId = "TRX04",Amount = 1500m, TransactionType = TransactionType.Deposit, DestinationAccountNumber = "1004", Timestamp = DateTime.Now.AddDays(-2), Description = "Salary"});
        Transactions.Add(new Transaction{TransactionId = "TRX05",Amount = 50m, TransactionType = TransactionType.POS, SourceAccountNumber = "1005", Timestamp = DateTime.Now.AddDays(-1), Description = "Grocery Store"});
        Transactions.Add(new Transaction{TransactionId = "TRX06",Amount = 3000m, TransactionType = TransactionType.Deposit, DestinationAccountNumber = "1006", Timestamp = DateTime.Now.AddHours(-6), Description = "Freelance Pay"});
        Transactions.Add(new Transaction{TransactionId = "TRX07",Amount = 100m, TransactionType = TransactionType.POS, SourceAccountNumber = "1007", Timestamp = DateTime.Now.AddHours(-5), Description = "Steam Purchase"});
        Transactions.Add(new Transaction{TransactionId = "TRX08",Amount = 400m, TransactionType = TransactionType.Transfer, SourceAccountNumber = "1008", Timestamp = DateTime.Now.AddHours(-7), Description = "Gift"});
        Transactions.Add(new Transaction{TransactionId = "TRX09",Amount = 50m, TransactionType = TransactionType.Withdraw, SourceAccountNumber = "1009", Timestamp = DateTime.Now.AddMinutes(-45), Description = "Snack"});
        Transactions.Add(new Transaction{TransactionId = "TRX10",Amount = 1000m, TransactionType = TransactionType.Deposit, DestinationAccountNumber = "1010", Timestamp = DateTime.Now.AddMinutes(-5), Description = "Refund"});

    }
}
