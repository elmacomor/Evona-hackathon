using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hackathon_api.Models
{
    public class UserAchivement
    {
        [Key]
        [Column(TypeName ="bigint")]
        public long UserAchivementsId { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string UserId { get; set; } = string.Empty;
        [ForeignKey("AchivementId")]
        public Achivement? Achivement { get; set; }
    }
}
