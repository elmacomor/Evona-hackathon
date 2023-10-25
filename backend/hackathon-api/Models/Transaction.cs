using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hackathon_api.Models
{
    public class Transaction
    {
        [Key]
        [Column(TypeName = "bigint")]
        public long Id { get; set; }
        public string UserId { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public TypeOfTransaction Type { get; set; }
    }
    public enum TypeOfTransaction
    {
        Deposit = 0,
        Withdrawal = 1
    }
}
