using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FrontToBack.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This field is required"), MaxLength(10, ErrorMessage = "Shouldn't exceed 10 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This field is required"), MaxLength(500, ErrorMessage = "Shouldn't exceed 50 characters")]
        public string Desc { get; set; } 
        public virtual IEnumerable<Product> Products { get; set; }
    }
}
