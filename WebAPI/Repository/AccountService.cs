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
        public Account GetAccount(int id) { return null; }
        public Account GetAccount(string userName) { return null; }
        public bool AccountsExists(int id) { return true; }
        public bool CreateAccount(Account account)
        {
            _dataContext.Accounts.Add(account);
            return Save();
        }
        public bool UpdatePassword(int id, string oldPassword, string newPassword) { return true; }
        public bool DisableAccount(int id) { return true; }
        public bool Save()
        {
            var saved = _dataContext.SaveChanges();
            return saved > 0 ? true : false;
        }    
    }
}
