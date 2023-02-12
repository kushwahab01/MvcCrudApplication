
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("Student")]
    public class Student
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        [Display(Name ="Student Name")]
        [MaxLength(40)]
        public string? Sname { get; set; }

        [Required]
        public double Marks { get; set; }
        
        [Required]
        public string? City { get; set; }
               
        [Required]
        public string? Cname { get; set; }
        
        [Required]
        public int IsActive { get; set; }
    }
}
