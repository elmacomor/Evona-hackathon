namespace hackathon_api.Models.DTOs;
public class TransactionDTO
{
    public string TxId { get; set; } = string.Empty;
    public string ProviderId { get; set; } = string.Empty;  
    public int Amount { get; set; } 
    public PlayerDTO Player { get; set; }
    public TypeOfTransaction TransactionType { get; set; }
}
