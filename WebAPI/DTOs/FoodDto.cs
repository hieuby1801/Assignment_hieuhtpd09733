using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.DTOs
{
    public class FoodDto
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        public int FoodCategoryId { get; set; }
        public int Available { get; set; }
        public string? Description { get; set; }
    }
}
