using DigitalBankingAndFinancialSystem.Admin;
using DigitalBankingAndFinancialSystem.Models;
using DigitalBankingAndFinancialSystem.Services;

namespace DigitalBankingAndFinancialSystem.UI;

public class ConsoleApp
{
    private readonly AccountService _accountService = new();
    private readonly TransactionService _transactionService = new();
    private readonly AdminService _adminService = new();

    public void Run()
 {
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("==== DIGITAL BANKING SYSYTEM ====");
            Console.WriteLine("1. User Portal");
            Console.WriteLine("2. Admin Dashboard");
            Console.WriteLine("3. Exit");
            Console.WriteLine("\n Select an option: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1": UserMenu(); break;
                case "2": AdminMenu(); break;
                case "3": running = false; break;
                default:
                    Console.WriteLine("Invalid choice. Press any key to try again.");
                    Console.ReadKey();
                    break;
            }
        }
 }
        

    private void UserMenu()
    {
        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("=== USER PORTAL ===");
            Console.WriteLine("1. Create new account");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Transfer");
            Console.WriteLine("5. Update account");
            Console.WriteLine("6. Back to main menu");
            Console.WriteLine("\n Select an option: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1": HandleCreateAccount(); break;
                case "2": HandleDeposit(); break;
                case "3": HandleWithdraw(); break;
                case "4": HandleTransfer(); break;
                case "5": HandleUpdateAccount(); break;
                case "6": running = false; break;
                default:
                    Console.WriteLine("Invalid choice. Press any key to try again.");
                    Console.ReadKey();
                    break;
            }
        }

    }

    private void HandleCreateAccount()
    {
        Console.WriteLine("\nChoose Type: \n1. Savings  \n2. Current");
        var type = Console.ReadLine();
        Console.Write("Enter your Name: ");
        string name = Console.ReadLine();
        Console.Write("Set PIN: ");
        string pin = Console.ReadLine();

        string newNo = _accountService.GenerateAccountNumber();
        Account newAcc;

        if (type == "1")
        {
            Console.Write("Enter Interest Rate (%): ");
            decimal.TryParse(Console.ReadLine(), out decimal rate);
            newAcc = new SavingsAccount
            {
                AccountNumber = newNo, AccountName = name, Pin = pin, InterestRate = rate,
                AccountType = AccountType.Savings
            };
        }
        else
        {
            Console.Write("Enter Overdraft Limit: ");
            decimal.TryParse(Console.ReadLine(), out decimal limit);
            newAcc = new CurrentAccount
            {
                AccountNumber = newNo, AccountName = name, Pin = pin, OverdraftLimit = limit,
                AccountType = AccountType.Current
            };
        }

        Console.WriteLine(_accountService.AddAccount(newAcc) + $". Your Account Number is {newNo}");
        Console.WriteLine("\nPress any key to return...");
        Console.ReadKey();
    }

    private void HandleDeposit()
    {
        Console.Write("Enter Account Number: ");
        string acc = Console.ReadLine();
        Console.Write("Amount: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal amt))
            Console.WriteLine(_transactionService.Deposit(acc, amt));
        else Console.WriteLine("Invalid amount.");
        Console.WriteLine("\nPress any key to return...");
        Console.ReadKey();
        
    }

    private void HandleWithdraw()
    {
        Console.Write("Account Number: ");
        string acc = Console.ReadLine();
        Console.Write("Amount: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal amt))
            Console.WriteLine(_transactionService.Withdraw(acc, amt));
        else Console.WriteLine("Invalid amount.");
        Console.WriteLine("\nPress any key to return...");
        Console.ReadKey();
    }

    private void HandleTransfer()
    {
        Console.Write("Source Account: ");
        string source = Console.ReadLine();
        Console.Write("Destination Account: ");
        string destination = Console.ReadLine();
        Console.Write("Amount: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal amt))
            Console.WriteLine(_transactionService.Transfer(source, amt, destination));
        else Console.WriteLine("Invalid amount.");
        Console.WriteLine("\nPress any key to return...");
        Console.ReadKey();
    }

    private void HandleUpdateAccount()
    {
        Console.Write("Account Number to Edit: ");
        string accNo = Console.ReadLine();
        Console.Write("New Name: ");
        string name = Console.ReadLine();
        Console.Write("New PIN: ");
        string pin = Console.ReadLine();

        var edited = new Account { AccountNumber = accNo, AccountName = name, Pin = pin };
        if (_accountService.EditAccount(edited))
            Console.WriteLine("Account updated successfully!");
        else Console.WriteLine("Account not found.");
        Console.WriteLine("\nPress any key to return...");
        Console.ReadKey();
    }

    private void AdminMenu()
    {
        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("=== ADMIN PORTAL ===");
            Console.WriteLine("1. View all accounts");
            Console.WriteLine("2. View all transactions");
            Console.WriteLine("3. Top 5 account report");
            Console.WriteLine("4. Transaction type volume breakdown");
            Console.WriteLine("5. System reset");
            Console.WriteLine("6. Back");
            Console.Write("\nSelect an option: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1": DisplayAllAccounts(); break;
                case "2": DisplayAllTransactions(); break;
                case "3": DisplayTopAccounts(); break;
                case "4": DisplayVolumeReport(); break;
                case "5":
                    _adminService.ResetSystem();
                    Console.WriteLine("Data Restored to Default.");
                    break;
                case "6": running = false; break;
                default:
                    Console.WriteLine("Invalid choice. Press any key to try again.");
                    Console.ReadKey();
                    break;
            }

        }
    }

    private void DisplayAllAccounts()
    {
        var accounts = _accountService.GetAccounts();
        //  Transforming list to string
        string data = string.Join(Environment.NewLine, accounts
            .Select(a => $"{a.AccountNumber,-10} | {a.AccountName,-15} | {a.Balance,12:C}"));

        Console.WriteLine($"\n{"ACC NO",-10} | {"NAME",-15} | {"BALANCE",-12}");
        Console.WriteLine(new string('-', 45));
        Console.WriteLine(string.IsNullOrEmpty(data) ? "No accounts found." : data);

        Console.WriteLine("\nPress any key to return...");
        Console.ReadKey();
    }

    private void DisplayAllTransactions()
    {
        var txs = _transactionService.GetAllTransactions(); // Use TransactionService here

        string data = string.Join(Environment.NewLine, txs
            .Select(t =>
            {
                // Safely get up to 8 chars
                string displayId = t.TransactionId.Length > 8 
                    ? t.TransactionId.Substring(0, 8) 
                    : t.TransactionId;
            
                return $"{displayId,-10} | {t.TransactionType,-10} | {t.Amount,12:C} | {t.Timestamp:d}";
            }));
        Console.WriteLine(string.IsNullOrEmpty(data) ? "No transactions found." : data);

        Console.WriteLine("\nPress any key to return...");
        Console.ReadKey();
    }

    private void DisplayTopAccounts()
    {
        var topFive = _adminService.GetTopFiveAccounts()
            .Select((a, i) => $"{i + 1}. {a.AccountName,-15} | {a.Balance,12:C}");

        Console.WriteLine("\n--- TOP 5 ACCOUNTS ---");
        Console.WriteLine(string.Join(Environment.NewLine, topFive));

        Console.WriteLine("\nPress any key to return...");
        Console.ReadKey();
    }

    private void DisplayVolumeReport()
    {
        var report = string.Join(Environment.NewLine, _adminService.GetTransactionVolume()
            .Select(v => $"{v.Key,-12}: {v.Value} transactions"));

        Console.WriteLine("\n--- TRANSACTION VOLUME ---");
        Console.WriteLine(string.IsNullOrEmpty(report) ? "No data available." : report);

        Console.WriteLine("\nPress any key to return...");
        Console.ReadKey();
    }

}
        