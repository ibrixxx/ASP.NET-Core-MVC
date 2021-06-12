using System.ComponentModel.DataAnnotations;

namespace miniproject.Models
{
    public class MyModel
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        [Range(1, 10000000,ErrorMessage = "Price must be a positive number.")]
        public int price { get; set; }
    }
}