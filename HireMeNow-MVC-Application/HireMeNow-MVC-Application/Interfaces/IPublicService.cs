using HireMeNow_MVC_Application.Models;

namespace HireMeNow_MVC_Application.Interfaces
{
    public interface IPublicService
    {
        public User LoginJobSeeker(string email, string password);
        public bool Register(User newJobSeeker);


        //public void Logout();

    }
}
