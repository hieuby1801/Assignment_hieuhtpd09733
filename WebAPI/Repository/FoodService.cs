using WebAPI.Data;
using WebAPI.Interface;
using WebAPI.Models;

namespace WebAPI.Repository
{
    public class FoodService : IFoodService
    {
        private readonly DataContext _dataContext;
        public FoodService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public ICollection<Food> GetFoods()
        {
            return _dataContext.Foods.ToList();
        }
        public bool Save()
        {
            var saved = _dataContext.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
