using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

 namespace WebApplication1.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        [Display(Name ="Employee Name")]
        [MaxLength(20)]
        public string? EName { get; set; }

        [Required]
        [MaxLength(10)]
        public string? Mobile { get; set; }

        [Required]
        [MaxLength(40)]
        [DataType(DataType.EmailAddress)]
        
        public string? Email { get; set; }

        [Required]
        [MaxLength(40)]
        public string? City { get; set; }

        [Required]

        public string? Gender { get; set; }

        [Required]
        public double Salary { get; set; }

        [ScaffoldColumn(false)]
        public int IsActive { get; set; }
        
        public int Deptid { get; set; }
       
        [NotMapped]
        public String? DeptName { get; set; }
    }
}
