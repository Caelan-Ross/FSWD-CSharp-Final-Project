using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MACK.Models
{
    public class ErrorViewModel
    {
        //Primary Key
        [Key]
        // Auto incrementing
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        // Name and type
        [Column("request_id", TypeName = "int(10)")]
        public string? RequestId { get; set; }


        [Required]
        [Column("show_request_id")]
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}