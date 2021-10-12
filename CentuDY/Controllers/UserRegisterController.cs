using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentuDY.Controllers
{
    public static class UserRegisterController
    {
        private static Boolean isEmpty(String input)
        {
            return String.IsNullOrEmpty(input);
        }        
        private static Boolean isNumber(String phoneNumber)
        {
            foreach(char c in phoneNumber)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        private static String validateUsername(String username)
        {
            if (isEmpty(username))
            {
                return "Username cannot be empty";
            }
            if (username.Length < 3)
            {
                return "Minimum username length is 3 characters";
            }

            return "Success";
        }
        private static String validatePassword(String password, String confirmPassword)
        {
            if (isEmpty(password))
            {
                return "Password cannot be empty";
            }
            if(password.Length < 8)
            {
                return "Minimum password length is 8 characters";
            }
            if (string.IsNullOrWhiteSpace(confirmPassword))
            {
                return "Confirm Password cannot be empty";
            }
            if (!password.Equals(confirmPassword))
            {
                return "Password and confirm password must match";
            }
            return "Success";
        }
        private static String validateName(String name)
        {
            if (isEmpty(name))
            {
                return "Name cannot be empty";
            }
            return "Success";
        }
        private static string validateGender(String gender)
        {
            if(gender.Equals("Default"))
            {
                return "Must choose a gender";
            }
            return "Success";
        }
        private static String validatePhoneNumber(String phoneNumber)
        {
            if (isEmpty(phoneNumber))
            {
                return "Phone Number cannot be empty";
            }
            if (!isNumber(phoneNumber))
            {
                return "Phone Number must be numeric";
            }
            return "Success";
        }

        private static String validateAddress(String address)
        {
            if (isEmpty(address))
            {
                return "Address cannot be empty";
            }
            if (!address.StartsWith("Street"))
            {
                return "Address must start with Street";
            }
            return "Success";
        }

        public static String userRegisterAuthentication(String username, String password, String confirmPassword, String name, String gender, String phoneNumber, String Address, HttpResponse Response)
        {
            String errorMsg = validateUsername(username);
            if (errorMsg.Equals("Success"))
            {
                errorMsg = Handlers.UserHandler.usernameIsUnique(username);
            }
            if (errorMsg.Equals("Success"))
            {
                errorMsg = validatePassword(password, confirmPassword);
            }
            if (errorMsg.Equals("Success"))
            {
                errorMsg = validateName(name);
            }
            if (errorMsg.Equals("Success"))
            {
                errorMsg = validateGender(gender);
            }
            if (errorMsg.Equals("Success"))
            {
                errorMsg = validatePhoneNumber(phoneNumber);
            }
            if (errorMsg.Equals("Success"))
            {
                errorMsg = validateAddress(Address);
            }
            if (errorMsg.Equals("Success"))
            {
                errorMsg = "Registration Success";
            }
            if (errorMsg.Equals("Registration Success"))
            {
                Handlers.UserHandler.insertUser(username, password, name, gender, phoneNumber, Address);
                Response.Redirect("~/Views/LoginPage.aspx");
            }
            return errorMsg;
        }
    }
}