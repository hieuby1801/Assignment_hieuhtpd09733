namespace WebAPI.Models
{
    public class ComboDetail
    {
        public int Id { get; set; } 
        public int FoodId { get; set; }
        public int Quantity { get; set; }
        public int ComboId { get; set; }
        public Combo Combo { get; set; }
        public Food Food { get; set; }
    }
}
