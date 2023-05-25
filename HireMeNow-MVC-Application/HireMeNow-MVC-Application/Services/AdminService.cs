using HireMeNow_MVC_Application.Exceptions;
using HireMeNow_MVC_Application.Interfaces;
using HireMeNow_MVC_Application.Models;

namespace HireMeNow_MVC_Application.Services
{
    public class AdminService:IAdminService
    {
        public bool _isLogged = false;
        public IUserRepository userRepository;
        public User LoggedUser = new User();
        public AdminService(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }
        public User getLoggedUser()
        {
            return userRepository.getLoggedUser();
        }

        public User GetUserById(Guid uid)
        {
            try
            {

                LoggedUser = userRepository.getById(uid);
                return LoggedUser;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new ServiceException("technical error occured");
            }
        }

        public bool UpdateProfile(User updatedAdmin)
        {
            try
            {

                userRepository.UpdateProfile(updatedAdmin);
              

                return true;
            }
            catch (UserAlreadyExistException ex)
            {
                throw ex;
            }
            catch (Exception ex) { throw ex; }
        }
		public User LoginAdmin(string email, string password)
		{
			try
			{

				LoggedUser = userRepository.login(email, password);
				if (LoggedUser.Email != null)
				{
					Console.WriteLine("Login successful!");
					_isLogged = true;
					Console.WriteLine("Welcome " + LoggedUser.FirstName);
					return LoggedUser;
				}
				else
				{
					Console.WriteLine("Login failed. Please try again.");
					return null;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				throw new ServiceException("technical error occured");
			}
		}
        public List<User> JobSeekerListing()
        {
            try
            {
                List<User> list = userRepository.JobSeekerListing();

                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
