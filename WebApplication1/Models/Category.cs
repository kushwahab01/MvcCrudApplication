using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Cid { get; set; }

        [Required]
        public String? Cname { get; set; }
    }
}
