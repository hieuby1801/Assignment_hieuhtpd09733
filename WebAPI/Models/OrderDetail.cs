namespace WebAPI.Models
{
    public class OrderDetail
    {
        public int Id { get; set; } 
        public int FoodOrComboId { get; set; }
        public int FoodOrCombo {  get; set; }
        public int Quantity { get; set; }
        public Order? Order { get; set; }
        public ICollection<Combo>? Combo { get; set; }
        public ICollection<Food>? Food { get; set; }
    }
}
