using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ExpenseTrackerWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Category Name must not exceed 50 characters")]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
