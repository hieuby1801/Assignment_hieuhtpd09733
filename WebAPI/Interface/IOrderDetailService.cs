using WebAPI.Models;

namespace WebAPI.Interface
{
    public interface IOrderDetailService
    {
        //ICollection<OrderDetail> GetAllOrderDetails();
        //ICollection<OrderDetail> GetOrderDetails(int OrderId);
        //OrderDetail GetOrderDetail(int id);
        //bool OrderDetailExist(int OrderId);
        bool CreateOrderDetail(OrderDetail orderDetail);
        void UpdateOrderDetail(OrderDetail orderDetail);
        bool DeleteOrderDetail(int id);
        bool Save();
        List<OrderDetail> GetOrderDetails(int orderId);
        public OrderDetail GetDetail(int foodId);
        OrderDetail GetDetailById(int id);
    }
}
