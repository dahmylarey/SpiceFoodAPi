using SpiceS.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpiceApi.Model
{
    public class SubCategory
    {
        [Key]
        
        public int Id { get; set; }

        [Required]
        [Display(Name= "SubCategory Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Category Name")]

        [ForeignKey("CategoryId")]
        public string CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
