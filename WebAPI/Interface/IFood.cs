using WebAPI.Models;

namespace WebAPI.Interface
{
    public interface IFood
    {
        ICollection<IFood> GetFoods();
        Food GetFood(int id);
        Food GetFood(string name);
        bool FoodExists(int id);
        bool CreateFood(Food food);
        bool UpdateFood(Food food);
        bool DisableFood(Food food);
        bool Save();
    }
}
