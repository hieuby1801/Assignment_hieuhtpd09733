    using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using WebAPI.Data;
using WebAPI.Interface;
using WebAPI.Models;
namespace WebAPI.Repository
{
    public class AccountService : IAccountService
    {
        private readonly DataContext _dataContext;
        private readonly IConfiguration _configuration;
        public AccountService (DataContext dataContext, IConfiguration configuration)
        {
            _dataContext = dataContext;
            _configuration = configuration;
        }
        public ICollection<Account> GetAccounts()
        {
            return _dataContext.Accounts.Where(a => a.StatusCode > 0).ToList();
        }
        public Account GetAccount(int id)
        {
            return _dataContext.Accounts.Where(a => a.Id == id).FirstOrDefault();
        }
        public ICollection<Account> GetAccounts(string userName)
        {
            return _dataContext.Accounts.AsEnumerable().Where(a => a.UserName.Contains(userName)).ToList();
        }
        public bool AccountsExists(int id)
        {
            return _dataContext.Accounts.Any(a => a.Id == id);
        }
        public bool CreateAccount(Account account)
        {
            _dataContext.Accounts.Add(account);
            return Save();
        }        
        public bool UpdateAccount(Account account)
        {            
            _dataContext.Update(account);
            return Save();
        }        
        public bool Save()
        {
            var saved = _dataContext.SaveChanges();
            return saved > 0 ? true : false;
        }
      
        public bool LoginResult(LoginRequest request)
        {
            var acc = _dataContext.Accounts.Where(a => a.UserName.Equals(request.UserName)).FirstOrDefault();
            if (acc==null)
            {
                return false;
            }
            return (request.Password).Equals(acc.Password);
        }
        public int GetAccID(string userName)
        {
            return _dataContext.Accounts.Where(a => a.UserName == userName).First().Id;
        }
    }
}
