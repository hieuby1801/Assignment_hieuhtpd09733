using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.DTOs
{
    public class FoodCategoryDto
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }
    }
}
