using CentuDY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI.WebControls;

namespace CentuDY.Controllers
{
    public static class ProfileController
    {
        private static Boolean isEmpty(String input)
        {
            return String.IsNullOrEmpty(input);
        }

        private static Boolean isNumber(String phoneNumber)
        {
            foreach (char c in phoneNumber)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }
        public static void getUserInformation(HttpSessionState Session, Label username, Label name, Label gender, Label phoneNumber, Label address, Label errorLbl)
        {
            User user = Controllers.UserController.getUserFromSession(Session);
            if(user == null)
            {
                errorLbl.Text = "Profile not found";
                return;
            }
            username.Text = user.Username;
            name.Text = user.Name;
            gender.Text = user.Gender.Equals("M") ? "Male" : "Female";
            phoneNumber.Text = user.PhoneNumber;
            address.Text = user.Address;
        }

        public static void getUpdatableUserProfile(HttpSessionState Session, TextBox name, DropDownList gender, TextBox phoneNumber, TextBox address, Label errorLbl)
        {
            User user = Controllers.UserController.getUserFromSession(Session);
            if (user == null)
            {
                errorLbl.Text = "Profile not found";
                return;
            }
            name.Text = user.Name;
            gender.SelectedValue = user.Gender;
            phoneNumber.Text = user.PhoneNumber;
            address.Text = user.Address;
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
            if (gender.Equals("Default"))
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

        public static String validateUpdateProfile(string name, string gender, string phoneNumber, String address, HttpSessionState Session)
        {
            User user = Controllers.UserController.getUserFromSession(Session);
            String errorMsg = validateName(name);
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
                errorMsg = validateAddress(address);
            }
            if (errorMsg.Equals("Success"))
            {
                errorMsg = Handlers.UserHandler.updateUser(user.UserId, name, gender, phoneNumber, address);
            }
            return errorMsg;
        }

        private static String validatePassword(String password, String confirmPassword)
        {
            if (isEmpty(password))
            {
                return "Password cannot be empty";
            }
            if (password.Length < 8)
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

        public static void redirectToUpdateProfilePage(HttpResponse Response)
        {
            Response.Redirect("~/Views/UpdateProfilePage.aspx");
        }

        public static void redirectToChangePasswordPage(HttpResponse Response)
        {
            Response.Redirect("~/Views/ChangePasswordPage.aspx");
        }

        private static String validateOldPassword(String oldPassword)
        {
            if (isEmpty(oldPassword))
            {
                return "Old password cannot be empty";
            }
            return "Success";
        }
        private static String validateNewPassword(String newPassword)
        {
            if (isEmpty(newPassword))
            {
                return "New password cannot be empty";
            }
            if(newPassword.Length < 5)
            {
                return "Password must be longer than 5 characters";
            }
            return "Success";
        }
        private static String validateNewPasswordMatchWithConfirmPassword(String newPassword, String confirmNewPassword)
        {
            if (isEmpty(confirmNewPassword))
            {
                return "Confirm new password cannot be empty";
            }
            if (!newPassword.Equals(confirmNewPassword))
            {
                return "Confirm new password must match with new password";
            }
            return "Success";
        }
        public static String validatePassword(string oldPassword, string newPassword, string confirmNewPassword, HttpSessionState Session)
        {
            User user = Controllers.UserController.getUserFromSession(Session);
            String errorMsg = validateOldPassword(oldPassword);
            if (errorMsg.Equals("Success"))
            {
                errorMsg = Handlers.UserHandler.getPasswordByUser(user.UserId, oldPassword);
            }
            if (errorMsg.Equals("Success"))
            {
                errorMsg = validateNewPassword(newPassword);
            }
            if (errorMsg.Equals("Success"))
            {
                errorMsg = validateNewPasswordMatchWithConfirmPassword(newPassword, confirmNewPassword);
            }
            if (errorMsg.Equals("Success"))
            {
                Handlers.UserHandler.updateUserPassword(user.UserId, newPassword);
                errorMsg = "Password has been changed";
            }
            return errorMsg;
        }
    }
}