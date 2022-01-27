using System.ComponentModel.DataAnnotations;

namespace CHETUPROJECT.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Product_type { get; set; }
    }
}
