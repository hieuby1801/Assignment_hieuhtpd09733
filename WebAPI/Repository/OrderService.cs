using WebAPI.Data;
using WebAPI.Interface;
using WebAPI.Models;

namespace WebAPI.Repository
{
    public class OrderService : IOrderService
    {
        private readonly DataContext _dataContext;
        public OrderService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public bool CreateOrder(Order order)
        {
            _dataContext.Orders.Add(order);
            return Save();
        }
        public bool UpdateOrder(Order order)
        {
            _dataContext.Orders.Update(order);
            return Save();
        }
        public bool Save()
        {
            var saved = _dataContext.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool ExistOrder(int id)
        {
            return _dataContext.Orders.Any(o => o.Id == id);
        }
        public Order GetOrderUncomplete(int accId)
        {
            return _dataContext.Orders.Where(o => o.AccountId == accId && o.OrderStatus == 0).FirstOrDefault();
        }

    }
}
