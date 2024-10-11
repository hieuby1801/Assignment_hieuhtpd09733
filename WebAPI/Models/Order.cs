using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        // 0: complete, 1: get require, 2: cooking, 3: shipping, 
        public int OrderStatus { get; set; }
        public Account Account { get; set; }
        public ICollection<OrderDetail>? OrderDetails { get; set; }    
    }
}
