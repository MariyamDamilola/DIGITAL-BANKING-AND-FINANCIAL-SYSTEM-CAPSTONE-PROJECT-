namespace DigitalBankingAndFinancialSystem.Models;

public class Account
{
    public string AccountNumber { get; set; }
    public string AccountName { get; set; }
    public decimal Balance { get; set; }
    public DateTime DateCreated { get; set; }
    public string Pin { get; set; }
    public AccountType AccountType { get; set; }
}

public enum AccountType
{
  Savings = 1,
  Current = 2
}