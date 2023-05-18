using HireMeNow_MVC_Application.Enums;
using HireMeNow_MVC_Application.Exceptions;
using HireMeNow_MVC_Application.Interfaces;
using HireMeNow_MVC_Application.Models;
using HireMeNow_MVC_Application.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HireMeNow_MVC_Application.Managers
{
    public class PublicService : IPublicService
    {
        public IUserRepository userRepository;
        public PublicService(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }
        public User LoggedUser = new User();
       // UserRepository userRepository =new UserRepository();
        bool _isLogged = false;
        public User LoginJobSeeker( string email,string password)
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
        public bool Register(User newJobSeeker)
        {
            try
            {
               
                userRepository.register(newJobSeeker);
                // Register(newJobSeeker);

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
