using HireMeNow_MVC_Application.Models;

namespace HireMeNow_MVC_Application.Interfaces
{
    public interface IAdminService
    {
        public User getLoggedUser();
        User GetUserById(Guid uid);
        bool UpdateProfile(User updatedAdmin);

        List<User> JobSeekerListing();
    }
}
