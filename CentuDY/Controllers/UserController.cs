using CentuDY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI.WebControls;

namespace CentuDY.Controllers
{
    public static class UserController
    {

        public static User getCookie(HttpRequest Request)
        {
            if (Request.Cookies.Get("LoginCookie") != null)
            {
                String userId = Request.Cookies.Get("LoginCookie").Value;
                User user = Repositories.UserRepository.getUserById(userId);
                return user;
            }
            return null;
        }

        public static User getUserFromSession(HttpSessionState Session)
        {
            User user = (User)Session["UserLoggedin"];
            return user;
        }

        public static String getUsernameFromCookie(HttpRequest Request)
        {
            User user = getCookie(Request);
            if(user != null)
            {
                return user.Username;

            }
            return "";
        }
        public static String getPasswordFromCookie(HttpRequest Request)
        {
            User user = getCookie(Request);
            if(user != null)
            {
                return user.Password;
            }
            return "";
        }

        public static void getSession(HttpSessionState Session, HttpRequest Request)
        {
            User user = getCookie(Request);
            if(user != null)
            {
                Session["UserLoggedin"] = user;
            }
        }

        public static String getUsernameFromSession(HttpSessionState Session)
        {
            if (Session["UserLoggedin"] != null)
            {
                User loggedInUser = (User)Session["UserLoggedin"];
                return loggedInUser.Username;
            }
            return "";
        }

        public static Boolean isAdminRole(HttpSessionState Session)
        {
            if (Session["UserLoggedin"] != null)
            {
                User loggedInUser = (User)Session["UserLoggedin"];
                if (loggedInUser.RoleId.Equals("RO001"))
                {
                    return true;
                }
            }
            return false;
        }

        public static void showUser(GridView viewUserGV, HttpSessionState Session) 
        {
            viewUserGV.DataSource = Handlers.UserHandler.getAllUser();
            viewUserGV.DataBind();
        }

        public static String deleteUser(GridView viewUserGV, HttpSessionState Session, GridViewDeleteEventArgs e)
        {
            String userId = viewUserGV.DataKeys[e.RowIndex].Value.ToString();
            return Handlers.UserHandler.deleteUserById(userId);
        }
    }
}