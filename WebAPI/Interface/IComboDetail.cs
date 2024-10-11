using WebAPI.Models;

namespace WebAPI.Interface
{
    public interface IComboDetail
    {
        ICollection<ComboDetail> GetComboDetails();
        ComboDetail GetComboDetail(int id);
        ComboDetail GetComboDetail(string name);
        bool ComboDetailExist(int id);
        bool CreatComboDetail(ComboDetail comboDetail);
        bool UpdateComboDetail(ComboDetail comboDetail);
        bool DisableComboDetail(ComboDetail comboDetail);
        bool Save();

    }
}
