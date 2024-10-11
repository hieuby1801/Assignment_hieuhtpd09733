using WebAPI.Models;

namespace WebAPI.Interface
{
    public interface IOrderDetail
    {
        ICollection<OrderDetail> GetAllOrderDetails();
        ICollection<OrderDetail> GetOrderDetails(int OrderId);
        OrderDetail GetOrderDetail(int id);
        bool OrderDetailExist(int OrderId);
        bool CreateOrderDetail(OrderDetail orderDetail);
        bool UpdateOrderDetail(OrderDetail orderDetail);
        bool DeleteOrderDetail(int id);
        bool Save();
    }
}
