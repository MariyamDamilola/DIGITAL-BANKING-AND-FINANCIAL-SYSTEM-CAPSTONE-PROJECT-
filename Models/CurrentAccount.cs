namespace DigitalBankingAndFinancialSystem.Models;

public class CurrentAccount : Account
{
    public decimal OverdraftLimit { get; set; }
}