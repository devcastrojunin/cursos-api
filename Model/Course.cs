using System.ComponentModel.DataAnnotations;

namespace cursos_api.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage="This field is required")]
        [MaxLength(30, ErrorMessage="This field must contain between 3 and 60 characters")]
        [MinLength(3, ErrorMessage="This field must contain between 3 and 60 characters")]
        public string Name { get; set; }

        [MaxLength(1024, ErrorMessage="This field must contain 1024 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage="This field is required")]
        [Range(1, int.MaxValue, ErrorMessage="The price must be greater than zero!")]
        public decimal Price { get; set; }

        [Required(ErrorMessage="This field is required")]
        [Range(1, int.MaxValue, ErrorMessage="Invalid category!")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}