using WebAPI.Models;

namespace WebAPI.Interface
{
    public interface IAccountService
    {
        ICollection<Account> GetAccounts();
        Account GetAccount(int id);
        ICollection<Account> GetAccounts(string name);
        bool AccountsExists(int id);
        bool CreateAccount(Account account);
        bool UpdateAccount(Account account);
        bool LoginResult(LoginRequest request);
        bool Save();
        int GetAccID(string userName);
    }
}
