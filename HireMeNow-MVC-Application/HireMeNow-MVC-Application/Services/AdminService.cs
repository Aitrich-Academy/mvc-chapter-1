﻿using HireMeNow_MVC_Application.Exceptions;
using HireMeNow_MVC_Application.Interfaces;
using HireMeNow_MVC_Application.Models;

namespace HireMeNow_MVC_Application.Services
{
    public class AdminService:IAdminService
    {
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
    }
}