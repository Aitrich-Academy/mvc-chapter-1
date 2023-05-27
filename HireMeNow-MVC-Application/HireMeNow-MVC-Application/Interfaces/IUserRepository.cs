using HireMeNow_MVC_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeNow_MVC_Application.Interfaces
{
    public interface IUserRepository
    {
        //List<User> getAll();
        bool register(User user);
        public User getLoggedUser();
        public User login(string email, string password);
        User getById(Guid uid);
        bool UpdateProfile(User updatedAdmin);
		public bool registerMember(User user);

		public List<User> MemberListing();
		//public User GetBymailId(string email,int id);
		User getuser();
		public bool ApplyJob(Guid jobId, Guid userId);
		List<Guid> getAppliedJobs(Guid userId);
		public User updateUserProfile(User updatedUser);
        public List<User> JobSeekerListing();
    }
}
