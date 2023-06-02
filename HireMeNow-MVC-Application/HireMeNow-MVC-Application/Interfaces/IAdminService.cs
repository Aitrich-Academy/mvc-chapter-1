using HireMeNow_MVC_Application.Models;

namespace HireMeNow_MVC_Application.Interfaces
{
    public interface IAdminService
    {
        public User getLoggedUser();
        User GetUserById(Guid uid);
        bool UpdateProfile(User updatedAdmin);
		public User LoginAdmin(string email, string password);
        List<User> JobSeekerListing();
    }
}
