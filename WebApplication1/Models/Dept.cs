using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("Dept")]
    public class Dept
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Deptid { get; set; }
        [Required]
        public string? DeptName { get;set; } 
    }
}
