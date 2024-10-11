using WebAPI.Models;

namespace WebAPI.Interface
{
    public interface IAccount
    {
        ICollection<IAccount> GetAccounts();
        Account GetAccount(int id);
        Account GetAccount(string name);
        bool AccountsExists(int id);
        bool CreateAccount(Account account);
        bool UpdatePassword(int id, string oldPassword, string newPassword);
        bool DisableAccount(int id);
        bool Save();
    }
}
