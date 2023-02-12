
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("Product")]
   
    public class Product
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Pid { get; set; }

        [Required]
        [Display(Name ="Product Name")]
        [MaxLength(40)]
        public string? Pname { get; set; }

        [Required]
        public double Price { get; set; }
    
        [Required]
        public string? Company { get; set; }
        
        [ScaffoldColumn(false)]
        public int IsActive { get; set; }

     
        public int Cid { get; set; }

        [NotMapped]
        public String? Cname{ get; set; }
    }
}
