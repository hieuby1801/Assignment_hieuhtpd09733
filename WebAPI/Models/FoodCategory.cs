using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class FoodCategory
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }
        public ICollection<Food>? Foods { get; set; }
    }
}
