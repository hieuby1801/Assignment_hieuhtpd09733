using WebAPI.Models;

namespace WebAPI.Interface
{
    public interface IFoodCategory
    {
        ICollection<IFoodCategory> GetCategories();
        FoodCategory GetCategory(int id);
        FoodCategory GetCategory(string name);
        bool CategoryExists(int id);
        bool CreateCategory(FoodCategory category);
        bool UpdateCategory(FoodCategory category);
        bool DisableCategory(FoodCategory category);
        bool Save();
    }
}
