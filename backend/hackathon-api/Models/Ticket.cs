using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hackathon_api.Models
{
    public class Ticket
    {
        [Key]
        [Column(TypeName = "bigint")]
        public long TicketID { get; set; }
        public GameType GameType { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string UserId { get; set; } = string.Empty;
        [Column(TypeName = "bit")]
        public bool FreeBet { get; set; } = false;
        public DateTime TicketDate { get; set; } = DateTime.Now;
        public int Amount { get; set; } = 0;
        public string TxId { get; set; } = string.Empty;
        public string ReferenceTxId { get; set; } = string.Empty;

    }
    public enum GameType
    {
        PrematchPlay = 0,
        LivePlay = 1,
        BingoPlay = 2,
        VGPlay = 3,
        CasinoPlay = 4,
        PrematchBet = 5,
        LiveBet = 6,
        BingoBet = 7,
        VGBet = 8,
        CasinoBet = 9,
        PrematchWin = 10,
        LiveWin = 11,
        BingoWin = 12,
        VGWin = 13,
        CasinoWin = 14,
        PrematchFree = 15,
        LiveFree = 16,
        BingoFree = 17,
        VGFree = 18,
        CasinoFree = 19
    }
}
