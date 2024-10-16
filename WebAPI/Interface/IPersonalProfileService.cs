using WebAPI.Models;

namespace WebAPI.Interface
{
    public interface IPersonalProfileService
    {
        ICollection<PersonalProfile> GetPersonalProfiles();
        ICollection<PersonalProfile> GetPersonalProfiles(string name);
        PersonalProfile GetPersonalProfile(int id);
        bool ExistProfile(int id);
        bool ExistPhone(string phone);
        bool ExistEmail(string email);
        bool CreateProfile(PersonalProfile personalProfile);
        bool UpdateProfile(PersonalProfile personalProfile);
        bool Save();

    }
}
