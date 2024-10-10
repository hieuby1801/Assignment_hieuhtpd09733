using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace WebAPI.Models
{
    public class Combo
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }
        public int ComboDetailId { get; set; }
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        public int Available {  get; set; }
        public string? Description { get; set; }
        public ICollection<ComboDetail> ComboDetails { get; set; }
        public OrderDetail OrderDetail { get; set; }
    }
}
