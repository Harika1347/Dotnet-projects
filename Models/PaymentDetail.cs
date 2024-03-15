using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PaymentAPI.Models
{
    public class PaymentDetail
    {
        [Key]
        public int PaymentId { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string CardOwnerName { get; set; } = "";
        [Column(TypeName = "nvarchar(12)")]
        public string CardNumber { get; set; } = "";
        [Column(TypeName = "nvarchar(3)")]
        public string SecurityCode { get; set; } = "";
        [Column(TypeName = "nvarchar(4)")]
        public string ExpirationDate { get; set; } = "";
    }
}
