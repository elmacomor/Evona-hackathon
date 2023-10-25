using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hackathon_api.Models
{
    public class Match
    {
        [Key]
        [Column(TypeName = "bigint")]
        public long MatchId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string MatchesName { get; set; } = string.Empty;
    }
}
