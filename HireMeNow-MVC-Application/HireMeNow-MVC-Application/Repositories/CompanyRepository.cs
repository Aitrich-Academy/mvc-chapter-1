using HireMeNow_MVC_Application.Interfaces;
using HireMeNow_MVC_Application.Models;

namespace HireMeNow_MVC_Application.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        List<Company> _companies = new List<Company> { new Company("Aitrich", "aitrich@gmail.com", "www.aitrich.com", "9090898767", "", "", "", "", "Thrissur",new Guid("ae32ba86-8e8d-4615-aa47-7387159e705d")) };
        public Company GetCompanyById(Guid companyId)
        {
            return _companies.Where(e => e.Id==companyId).FirstOrDefault();
        }

        public Company Update(Company updatedCompany)
        {
            int indexToUpdate = _companies.FindIndex(item => item.Id == updatedCompany.Id);
            if (indexToUpdate != -1)
            {
                // Modify the properties of the item at the found index
           
               _companies[indexToUpdate].About = updatedCompany.About??_companies[indexToUpdate].About;
               _companies[indexToUpdate].Name = updatedCompany.Name??_companies[indexToUpdate].Name;
               _companies[indexToUpdate].Vision = updatedCompany.Vision??_companies[indexToUpdate].Vision;
               _companies[indexToUpdate].Mission = updatedCompany.Mission??_companies[indexToUpdate].Mission;
               _companies[indexToUpdate].Address = updatedCompany.Address??_companies[indexToUpdate].Address;
               _companies[indexToUpdate].Email = updatedCompany.Email??_companies[indexToUpdate].Email;
               _companies[indexToUpdate].Website = updatedCompany.Website??_companies[indexToUpdate].Website;
               _companies[indexToUpdate].Location = updatedCompany.Location??_companies[indexToUpdate].Location;
               _companies[indexToUpdate].Phone = updatedCompany.Phone??_companies[indexToUpdate].Phone;
               _companies[indexToUpdate].Image = updatedCompany.Image??_companies[indexToUpdate].Image;
            }
            return _companies.Where(e => e.Id==updatedCompany.Id).FirstOrDefault();
        }
    }
}
