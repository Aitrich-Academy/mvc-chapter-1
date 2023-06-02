using HireMeNow_MVC_Application.Models;

namespace HireMeNow_MVC_Application.Interfaces
{
	public interface ICompanyServices
	{
		public bool MemberRegister(User newCompanyMember);
		public List<User> MemberListing();
        Company GetCompanyById(Guid companyId);
        Company Update(Company updatedCompany);
    }
}
