using WebAPI.Data;
using WebAPI.Interface;
using WebAPI.Models;

namespace WebAPI.Repository
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly DataContext _dataContext;
        public OrderDetailService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public bool CreateOrderDetail(OrderDetail orderDetail)
        {
            _dataContext.OrderDetails.Add(orderDetail);
            return Save();
        }
        public void UpdateOrderDetail(OrderDetail orderDetail)
        {
            _dataContext.OrderDetails.Update(orderDetail);
            _dataContext.SaveChangesAsync();
        }
        public bool DeleteOrderDetail(int id)
        {
            var objDelete = _dataContext.OrderDetails.Where(od => od.Id == id);
            _dataContext.Remove(objDelete);
            return Save();
        }
        public bool Save()
        {
            var saved = _dataContext.SaveChanges();
            return saved > 0 ? true : false;
        }
        public List<OrderDetail> GetOrderDetails(int orderId)
        {
            return _dataContext.OrderDetails.Where(od => od.OrderId == orderId).ToList();
        }
        public OrderDetail GetDetail(int foodId)
        {
            return _dataContext.OrderDetails.Where(od => od.FoodId == foodId).FirstOrDefault();
        }
        public OrderDetail GetDetailById(int id)
        {
            return _dataContext.OrderDetails.Where(od => od.Id == id).FirstOrDefault();
        }
    }
}
