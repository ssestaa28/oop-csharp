namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.DTO;

public class TransactionDto
{
    public int Id { get; set; }

    public DateTime? TransactionDate { get; set; }

    public decimal Amount { get; set; }

    public string Type { get; set; } = string.Empty;

    public int AccountId { get; set; }
}
