using WebAPI.Data;
using WebAPI.Interface;
using WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Repository
{
    public class PersonalProfileService : IPersonalProfileService
    {
        private readonly DataContext _dataContext;
        public PersonalProfileService (DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public ICollection<PersonalProfile> GetPersonalProfiles()
        {
            return _dataContext.Profiles.ToList(); 
        }
        
        public ICollection<PersonalProfile> GetPersonalProfiles(string name) // ko chạy, khó quá bỏ qua, update: chạy rồi =))) , chat hơi bịp hoặc hỏi chưa chuẩn
        {
            if (string.IsNullOrEmpty(name))
            {
                return new List<PersonalProfile>();
            }

            // Truy vấn các hồ sơ có tên chứa chuỗi 'name' không phân biệt chữ hoa chữ thường
            return _dataContext.Profiles.AsEnumerable().Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public PersonalProfile GetPersonalProfile(int id)
        {
            return _dataContext.Profiles.Where(p => p.Id == id).FirstOrDefault();
        }
        public bool ExistProfile(int id)
        {
            return _dataContext.Profiles.Where(p => p.Id == id).Any();
        }
        public bool ExistPhone(string phone)
        {
            return _dataContext.Profiles.Where(p => p.Phone.Equals(phone)).Any();         
        }
        public bool ExistEmail(string email)
        {
            return _dataContext.Profiles.Where(p => p.Email.Equals(email)).Any();
        }
        public bool CreateProfile(PersonalProfile personalProfile)
        {
            _dataContext.Profiles.Add(personalProfile);
            return Save();
        }
        public bool UpdateProfile(PersonalProfile personalProfile)
        {
            _dataContext.Update(personalProfile);
            return Save();
            // Phương thức Update() là một phương thức của DbContext trong Entity Framework Core.
            // Update() đánh dấu thực thể personalProfile vào trạng thái "Modified" để sau này khi gọi SaveChanges(),
            // những thay đổi sẽ được ghi nhận trong cơ sở dữ liệu
        }
        public bool Save()
        {
            var saved = _dataContext.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
