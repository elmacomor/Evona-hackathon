using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hackathon_api.Models
{
    public class Achivement
    {
        [Key]
        [Column(TypeName = "bigint")]
        public long AchivementId { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; } = string.Empty;
        [Column(TypeName = "smallint")]
        public int Points { get; set; }
        [Column(TypeName = "smallint")]
        public int Treashold {get;set;}
        public string AchivementType { get; set; } = string.Empty;
    }
}
