using CentuDY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentuDY.Repositories
{
    public class UserRepository
    {
        private static CentuDYDBEntities db = Repositories.CentuDYDBSingleton.getDBInstance();

        public static List<User> getUser()
        {
            return (from user in db.Users
                    where user.RoleId.Equals("RO002")
                    select user).ToList();
        }

        public static User getUserByUsernameAndPassword(String username, String password)
        {
            return (from user in db.Users where (user.Username.Equals(username) &&
                      user.Password.Equals(password)) select user).FirstOrDefault();
        }

        public static User getLastUser()
        {
            return (from user in db.Users select user).ToList().LastOrDefault();
        }

        public static User getUserById(String userId)
        {
            return (from user in db.Users where user.UserId.Equals(userId) select user).FirstOrDefault();
        }

        public static User getUsername(String username)
        {
            User Username = (from user in db.Users where user.Username.Equals(username) select user).FirstOrDefault();
            return Username;
        }

        public static List<User> getAdmin()
        {
            return (from user in db.Users
                    join role in db.Roles on user.RoleId equals role.RoleId
                    where role.RoleId.Equals("RO001")
                    select user).ToList();
        }

        public static void insertUser(User newUser)
        {
            db.Users.Add(newUser);
            db.SaveChanges();
        }

        public static User getPasswordByID(string userId)
        {
            return (from user in db.Users where user.UserId.Equals(userId) select user).FirstOrDefault();
        }

        public static void updateUserPassword(String userId, string newPassword)
        {
            User user = getUserById(userId);
            user.Password = newPassword;
            db.SaveChanges();
        }

        public static void updateUser(string userId, string name, string gender, string phoneNumber, string address)
        {
            User user = getUserById(userId);
            user.Name = name;
            user.Gender = gender;
            user.PhoneNumber = phoneNumber;
            user.Address = address;
            db.SaveChanges();
        }

        public static void deleteUser(String userId)
        {
            User user = getUserById(userId);

            db.Users.Remove(user);
            db.SaveChanges();
        }
    }
}