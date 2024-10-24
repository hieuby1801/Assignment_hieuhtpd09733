using WebAPI.Models;

namespace WebAPI.Interface
{
    public interface IOrderService
    {
        //ICollection<Order> GetOrders();
        //ICollection<Order> GetOrders(int accountId);
        //Order GetOrder(int id);
        Order GetOrderUncomplete(int accId);
        bool ExistOrder(int accId);
        bool CreateOrder(Order order);
        bool UpdateOrder(Order order);
        //bool DeleteOrder(int id);
        bool Save();
    }
}
