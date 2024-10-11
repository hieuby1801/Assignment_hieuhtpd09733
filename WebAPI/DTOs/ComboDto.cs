using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.DTOs
{
    public class ComboDto
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        public int Available { get; set; }
        public string? Description { get; set; }
    }
}
