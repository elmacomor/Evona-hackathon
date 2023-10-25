using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hackathon_api.Models
{
    public class User
    {
        [Column(TypeName = "nvarchar(max)")]
        public string Id { get; set; } = string.Empty;
        [Column(TypeName = "nvarchar(30)")]
        public string Name { get; set; } = string.Empty;
        [Column(TypeName = "nvarchar(30)")]
        public string Surname { get; set; } = string.Empty;
        [Column(TypeName = "nvarchar(30)")]
        public string Email { get; set; } = string.Empty;
        [Column(TypeName = "nvarchar(30)")]
        public string Username { get;set; } = string.Empty;
        [Column(TypeName = "nvarchar(16)")]
        [MinLength(8)]
        public string Password { get; set; } = string.Empty;
        [Column(TypeName = "nvarchar(30)")]
        public string Adress { get;set; } = string.Empty;
        public DateTime FirstLogin { get; set; } = DateTime.Today;
        public DateTime LastLogin { get; set; } = DateTime.Today;
        [Column(TypeName = "bit")]
        public bool IsVerified { get; set; } = false;
        public int Points { get; set; } = 0;

        public int DepositAmount { get; set; } = 0;
        public int DepositCumulativeAmount { get; set; } = 0;
        public int WithdrwalAmount { get; set; } = 0;
        public int WithdrawalCumulativeAmount { get; set; } = 0;

        public int PrematchPlayCount { get; set; } = 0;
        public int LivePlayCount { get; set; } = 0;
        public int BingoPlayCount { get; set; } = 0;
        public int VGPlayCount { get; set; } = 0;
        public int CasinoPlayCount { get; set; } = 0;

        public int PrematchBetCount { get; set; } = 0;
        public int LiveBetCount { get; set; } = 0;
        public int BingoBetCount { get; set; } = 0;
        public int VGBetCount { get; set; } = 0;
        public int CasinoBetCount { get; set; } = 0;

        public int PrematchWinCount { get; set; } = 0;
        public int LiveWinCount { get; set; } = 0;
        public int BingoWinCount { get; set; } = 0;
        public int VGWinCount { get; set; } = 0;
        public int CasinoWinCount { get; set; } = 0;

        public int PrematchFreeCount { get; set; } = 0;
        public int LiveFreeCount { get; set;} = 0;
        public int BingoFreeCount { get; set; } = 0;
        public int VGFreeCount { get; set;} = 0;
        public int CasinoFreeCount { get; set; } = 0;
        
        public int CurrentUserPoints { get; set; } = 0;
    }
}

