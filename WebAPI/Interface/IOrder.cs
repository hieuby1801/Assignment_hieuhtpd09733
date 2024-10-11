using WebAPI.Models;

namespace WebAPI.Interface
{
    public interface IOrder
    {
        ICollection<Order> GetOrders();
        ICollection<Order> GetOrders(int accountId);
        Order GetOrder(int id);
        bool OrderExist(int id);
        bool CreateOrder(Order order);
        bool UpdateOrder(Order order);
        bool DeleteOrder(int id);

    }
}
