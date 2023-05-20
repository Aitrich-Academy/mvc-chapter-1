using HireMeNow_MVC_Application.Exceptions;
using HireMeNow_MVC_Application.Interfaces;
using HireMeNow_MVC_Application.Models;
using HireMeNow_MVC_Application.Repositories;

namespace HireMeNow_MVC_Application.Services
{
	public class CompanyServices : ICompanyServices
	{
		public IUserRepository _userRepository;

		public CompanyServices(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}
		public List<User> MemberListing()
		{
			try
			{
				List<User> list = _userRepository.MemberListing();

				return list;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public bool MemberRegister(User newCompanyMember)
		{
			try
			{
				_userRepository.registerMember(newCompanyMember);


				Console.WriteLine("Registration successful");
				return true;
			}
			catch (UserAlreadyExistException ex)
			{
				throw ex;
			}
			catch (Exception ex) { throw ex; }
		}

	}
}
