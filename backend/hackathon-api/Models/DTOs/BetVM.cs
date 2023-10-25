using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace hackathon_api.Models.DTOs
{
    public class BetVM
    {
        public string TicketID { get; set; }
        public GameType GameType { get; set; }
        public PlayerDTO Player { get; set; }
        public bool FreeTicket { get; set; }//da li je ticket free ili ne
        public int Amount { get; set; }
    }
}
