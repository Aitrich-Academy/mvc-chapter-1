﻿using HireMeNow_MVC_Application.Enums;
using HireMeNow_MVC_Application.Exceptions;
using HireMeNow_MVC_Application.Interfaces;
using HireMeNow_MVC_Application.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HireMeNow_MVC_Application.Repositories
{
    public sealed class UserRepository : IUserRepository
    {
        public UserRepository()
        {

        }

        private static User loggedUser = new User();

        private List<User> users = new List<User> { new User( "jobprovider", "", "jobprovider@gmail.com", 123, "123", Roles.JobProvider),
         new User( "manu", "", "manu@gmail.com", 123, "123", Roles.CompanyMember),
         new User( "rs", "", "sad@gmail.com", 123, "123", Roles.CompanyMember), new User( "arun", "", "arun@gmail.com", 123, "123", Roles.Admin)};
        private int nextId = 2;


        public List<User> getAll()
        {
            return users.Where(e => e.Role == Roles.JobSeeker).ToList();
        }


        public bool register(User user)
        {
            user.Id = Guid.NewGuid();
            user.Role = Roles.JobSeeker;

            if (users.Find(e => e.Email == user.Email) == null)
            {
                users.Add(user);
                return true;
            }
            throw new UserAlreadyExistException(user.Email);
        }

        public User login(string email, string password)
        {
            loggedUser = users.FirstOrDefault(e => e.Email == email && e.Password == password, new User());
            return loggedUser;
        }
        public User getLoggedUser()
        {
            return loggedUser;
        }

        internal void logout()
        {
            loggedUser = new User();
        }

        public User getById(Guid uid)
        {
            return users.FirstOrDefault(e => e.Id == uid, new User());

        }

        internal User updateUserProfile(User updatedUser)
        {
            int indexToUpdate = users.FindIndex(item => item.Id == updatedUser.Id);
            if (indexToUpdate != -1)
            {
                // Modify the properties of the item at the found index
                users[indexToUpdate].About = updatedUser.About ?? users[indexToUpdate].About;
                users[indexToUpdate].Experiences = updatedUser.Experiences ?? users[indexToUpdate].Experiences;
                users[indexToUpdate].Education = updatedUser.Education ?? users[indexToUpdate].Education;
                users[indexToUpdate].Skills = updatedUser.Skills ?? users[indexToUpdate].Skills;
                users[indexToUpdate].AppliedJobs = updatedUser.AppliedJobs ?? users[indexToUpdate].AppliedJobs;
                //users[indexToUpdate].About = updatedUser.About??users[indexToUpdate].About;
                //users[indexToUpdate].About = updatedUser.About??users[indexToUpdate].About;
            }
            loggedUser = getById(updatedUser.Id);
            return loggedUser;

        }

        internal void ApplyJob(int jobId)
        {
            loggedUser.AppliedJobs.Add(jobId);
            updateUserProfile(loggedUser);
        }

        internal List<User> getCompanyMembers()
        {
            return users.Where(e => e.Role == Enums.Roles.CompanyMember).ToList();
        }

        public bool UpdateProfile(User updatedAdmin)
        {
            int indexToUpdate = users.FindIndex(e => e.Email == updatedAdmin.Email);
            if (indexToUpdate != null)
            {
                users[indexToUpdate].FirstName = updatedAdmin.FirstName ?? users[indexToUpdate].FirstName;
                users[indexToUpdate].LastName = updatedAdmin.LastName ??users[indexToUpdate].LastName;
               users[indexToUpdate].Email = updatedAdmin.Email?? users[indexToUpdate].Email;
                users[indexToUpdate].Phone = updatedAdmin.Phone !=0 ? updatedAdmin.Phone : users[indexToUpdate].Phone;
                users.Add(users[indexToUpdate]);
                return true;
            }
            return true;
        }
    }
}
