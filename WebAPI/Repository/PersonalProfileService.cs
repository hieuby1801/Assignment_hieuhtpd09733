using WebAPI.Data;
using WebAPI.Interface;
using WebAPI.Models;

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
        public ICollection<PersonalProfile> GetPersonalProfiles(string name)
        {
            return _dataContext.Profiles
                .Where(p => p.Name.Contains(name)).ToList();
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
            var oldProfile = _dataContext.Profiles.Where(p => p.Id == personalProfile.Id).First();
            oldProfile = personalProfile;
            return Save();
        }
        public bool Save()
        {
            var saved = _dataContext.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
