using HireMeNow_MVC_Application.Models;

namespace HireMeNow_MVC_Application.Interfaces
{
    public interface ICompanyRepository
    {
        Company GetCompanyById(Guid companyId);
        Company Update(Company updatedCompany);
    }
}
