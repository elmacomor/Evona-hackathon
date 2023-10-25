namespace hackathon_api.Models.DTOs;
public class TicketPOSTDTO
{
    public string TxId { get; set; } = string.Empty;
    public string GameType { get; set; } = string.Empty;
    public int Amount { get; set; } = 0;
    public bool FreeBet { get; set; } = false;
    public PlayerDTO? Player { get; set; }
    public string ReferenceTxId { get; set; } = string.Empty;
}
