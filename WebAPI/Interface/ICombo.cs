using WebAPI.Models;

namespace WebAPI.Interface
{
    public interface ICombo
    {
        ICollection<Combo> GetCombos();
        Combo GetCombo(int id);
        Combo GetCombo(string name);
        bool ComboExist(int id);
        bool CreatCombo(Combo combo);
        bool UpdateCombo(Combo combo);
        bool DisableCombo(Combo combo);
        bool Save();
    }
}
