using CentuDY.Models;
using CentuDY.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentuDY.Handlers
{
    public static class UserHandler
    {
        public static List<User> GetAdmin()
        {
            List<User> admins = Repositories.UserRepository.getAdmin();
            return admins;
        }
        public static String validateUsernameAndPasswordCombination(String username, String password)
        {
            User user = Repositories.UserRepository.getUserByUsernameAndPassword(username, password);
            if (user == null)
            {
                return "Username and password did not match";
            }
            return "Success";
        }

        public static User getUserByUsernameAndPassword(String username, String password)
        {
            User user = Repositories.UserRepository.getUserByUsernameAndPassword(username, password);
            return user;
        }

        public static User getUserID(String userId)
        {
            User user = Repositories.UserRepository.getUserById(userId);
            return user;
        }

        public static String usernameIsUnique(String username)
        {
            String errorMsg = "Success";
            User user = Repositories.UserRepository.getUsername(username);
            if(user != null)
            {
                errorMsg = "Sorry the username has been taken, try other username";
            }
            return errorMsg;
        }

        public static void insertUser(String username, String password, String name, String gender, String phoneNumber, String address)
        {
            String lastUserId = Repositories.UserRepository.getLastUser().UserId;
            User newUser = null;
            if (lastUserId == null)
            {
                newUser = Factories.UserFactory.createUser("US001", username, password, name, gender, phoneNumber, address);
            }
            else
            {
                String newId = generateUserId(lastUserId);
                newUser = Factories.UserFactory.createUser(newId, username, password, name, gender, phoneNumber, address);
            }
            Repositories.UserRepository.insertUser(newUser);
        }

        public static string getPasswordByUser(string userId, String oldPassword)
        {
            User user = Repositories.UserRepository.getPasswordByID(userId);
            if(user == null)
            {
                return "Your old password does not match, please try again";
            }
            else
            {
                if (user.Password.Equals(oldPassword))
                {
                    return "Success";
                }
                return "Your old password does not match, please try again";
            }
        }

        private static String generateUserId(String lastUserId)
        {
            int Id = int.Parse(lastUserId.Substring(2));
            Id++;
            return String.Format("{0}{1:000}", "US", Id);
        }

        public static String updateUser(String userId, string name, string gender, string phoneNumber, string address)
        {
            User user = Repositories.UserRepository.getUserById(userId);
            if(user == null)
            {
                return "User is not available, update fail";
            }

            Repositories.UserRepository.updateUser(userId, name, gender, phoneNumber, address);
            return "Your profile has been updated";
        }

        public static void updateUserPassword(String userId, string newPassword)
        {
            Repositories.UserRepository.updateUserPassword(userId, newPassword);
        }

        public static List<dynamic> getAllUser()
        {
            List<User> users = Repositories.UserRepository.getUser();

            List<dynamic> newList = new List<dynamic>();

            for(int i=0; i<users.Count; i++)
            {
                var newObj = new
                {
                    UserId = users[i].UserId,
                    Username = users[i].Username,
                    Name = users[i].Name,
                    RoleName = users[i].Role.RoleName,
                    Gender = users[i].Gender,
                    PhoneNumber = users[i].PhoneNumber,
                    Address = users[i].Address
                };
                newList.Add(newObj);
            }
            return newList;
        }

        public static String deleteUserById(String userId)
        {
            User user = UserRepository.getUserById(userId);

            if(user == null)
            {
                return "User not exist!";
            }
            if (isReferencedCart(userId))
            {
                return "This user can not be deleted";
            }
            if (isReferencedHeaderTrans(userId))
            {
                return "This user can not be deleted!";
            }
            else
            {
                Repositories.UserRepository.deleteUser(userId);
                return "Success";
            }
        }

        public static bool isReferencedCart(String userId)
        {
            List<Cart> cart = CartRepository.getUserById(userId);
            for (int i = 0; i < cart.Count(); i++)
            {
                if (cart[i].UserId.Equals(userId)) return true;
            }
            return false;
        }

        public static bool isReferencedHeaderTrans(String userId)
        {
            List<HeaderTransaction> ht = HeaderTransactionRepository.getUserById(userId);
            for (int i = 0; i < ht.Count(); i++)
            {
                if (ht[i].UserId.Equals(userId)) return true;
            }
            return false;
        }
    }
}