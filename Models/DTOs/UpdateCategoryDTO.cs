using System.ComponentModel.DataAnnotations;

namespace Web_Api_JWT.Models.DTOs
{
    public class UpdateCategoryDTO
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Bu alan boş olamaz.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bu alan boş olamaz.")]
        public string Description { get; set; }
    }
}
