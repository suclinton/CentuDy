using CentuDY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentuDY.Factories
{
    public static class UserFactory
    {
        public static User createUser(String userId, String username, String password, String name, String gender, String phoneNumber, String Address)
        {
            User user = new User();
            user.UserId = userId;
            user.RoleId = "RO002"; 
            user.Username = username;
            user.Password = password;
            user.Name = name;
            user.Gender = gender;
            user.PhoneNumber = phoneNumber;
            user.Address = Address;
            return user;
        }
    }
}