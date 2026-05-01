namespace DigitalBankingAndFinancialSystem.Models;

public class Transaction
{
    public decimal Amount { get; set; }
    public TransactionType TransactionType { get; set; }
    public string TransactionId { get; set; }
    public string SourceAccountNumber { get; set; }
    public string DestinationAccountNumber { get; set; }
    public DateTime Timestamp { get; set; }
    public string Description { get; set; }
}

public enum TransactionType
{
    Deposit = 1,
    Withdraw = 2,
    Transfer = 3,
    POS = 4
}