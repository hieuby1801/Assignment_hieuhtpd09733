using WebAPI.Models;

namespace WebAPI.Interface
{
    public interface IPersonalProfile
    {
        ICollection<PersonalProfile> GetPersonalProfiles();
        PersonalProfile GetPersonalProfile(int id);
        PersonalProfile GetPersonalProfile(string name);
        bool CreateProfile(PersonalProfile personalProfile);
        bool UpdateProfile(PersonalProfile personalProfile);
        bool Save();

    }
}
