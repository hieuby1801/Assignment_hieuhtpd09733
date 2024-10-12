using WebAPI.Data;
using WebAPI.Interface;
using WebAPI.Models;
namespace WebAPI.Repository
{
    public class AccountService : IAccountService
    {
        private readonly DataContext _dataContext;
        public AccountService (DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public ICollection<Account> GetAccounts()
        {
            return _dataContext.Accounts.ToList();
        }
        Account GetAccount(int id) { }
        Account GetAccount(string name) { }
        bool AccountsExists(int id) { }
        bool CreateAccount(Account account) { }
        bool UpdatePassword(int id, string oldPassword, string newPassword) { }
        bool DisableAccount(int id) { }
        bool Save() { }
    }
}
