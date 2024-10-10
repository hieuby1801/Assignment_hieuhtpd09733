using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int OrderDetailId { get; set; }
        public int OrderStatus { get; set; }
        public Account Account { get; set; }
        public ICollection<OrderDetail>? OrderDetail { get; set; }    
    }
}
