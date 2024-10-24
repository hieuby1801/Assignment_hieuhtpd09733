namespace WebAPI.Models
{
    public class OrderDetail
    {
        public int Id { get; set; } 
        public int OrderId { get; set; }
        // mặc định id = 1 là food null
        public int FoodId { get; set; }
        // mặc định id = 1 là combo null
        public int? ComboId {  get; set; }
        // mặc định = 1
        public int QuantityFood { get; set; }
        // mặc định = 1
        public int? QuantityCombo { get; set; }
        public Order? Order { get; set; }
        public Combo? Combo { get; set; }
        public Food? Food { get; set; }
    }
}
