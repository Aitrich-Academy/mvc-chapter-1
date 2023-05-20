using HireMeNow_MVC_Application.Exceptions;
using HireMeNow_MVC_Application.Interfaces;
using HireMeNow_MVC_Application.Models;
using HireMeNow_MVC_Application.Repositories;

namespace HireMeNow_MVC_Application.Services
{
	public class JobProviderServices:IJobProvider

	{
        public IJobProviderRepository jobProviderRepository;

        public JobProviderServices(IJobProviderRepository _jobProviderRepository)
		{
            jobProviderRepository = _jobProviderRepository;
		}

	
	

        public bool SheduleInterview(Interview interview)
        {
            try
            {
               var rslt= jobProviderRepository.SheduleInterview(interview);
                if(rslt==true)
                {
                    Console.WriteLine("Interview is sheduled");
                    return true;
                }
                else
                {
                    Console.WriteLine("Interview not sheduled");
                    return false;

                }
               
            }
           
            catch (Exception ex) { throw ex; }
        }
    }
}
