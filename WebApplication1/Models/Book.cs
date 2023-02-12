using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("Book")]
    public class Book
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        [MaxLength(60)]
        public string? Bname { get; set; }

        [Required]
        [MaxLength(40)]
        public String? Auther { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public DateTime Publish { get; set; }

        [Required]
        [ScaffoldColumn(false)]
        public int IsActive { get; set; }
    }
}
