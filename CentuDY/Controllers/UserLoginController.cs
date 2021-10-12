using CentuDY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace CentuDY.Controllers
{
    public class UserLoginController
    {
        private static String validateUsername(String username)
        {
            if (String.IsNullOrWhiteSpace(username))
            {
                return "Username cannot be empty!";
            }
            return "Success";
        }
        private static String validatePassword(String password)
        {
            if (String.IsNullOrWhiteSpace(password))
            {
               return "Password cannot be empty!";
            }
            return "Success";
        }

        public static String userLoginAuthentication(String username, String password, Boolean userCheckRememberMe, HttpSessionState Session, HttpResponse Response, HttpRequest Request)
        {
            User user = null;
            String errorMsg = validateUsername(username);

            if (errorMsg.Equals("Success"))
            {
                errorMsg = validatePassword(password);
            }
            if (errorMsg.Equals("Success"))
            {
                errorMsg = Handlers.UserHandler.validateUsernameAndPasswordCombination(username, password);
            }
            if(errorMsg.Equals("Success"))
            {
                deleteSessionAndCookie(Session, Response, Request);
                user = Handlers.UserHandler.getUserByUsernameAndPassword(username, password);
                if (userCheckRememberMe)
                {
                    HttpCookie cookie = new HttpCookie("LoginCookie");
                    cookie.Value = user.UserId;
                    cookie.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(cookie);
                }

                Session["UserLoggedin"] = user;
                Response.Redirect("~/Views/HomePage.aspx");
            }
            return errorMsg;
        }
        private static void deleteSessionAndCookie(HttpSessionState Session, HttpResponse Response , HttpRequest Request)
        {
            if (Session["UserLoggedin"] != null)
            {
                Session["UserLoggedin"] = null;
                HttpCookie cookie = new HttpCookie("LoginCookie");
                cookie.Expires = DateTime.Now.AddHours(-1);
                Response.Cookies.Add(cookie);
            }
            if (Request.Cookies.Get("LoginCookie") != null)
            {
                HttpCookie cookie = new HttpCookie("LoginCookie");
                cookie.Expires = DateTime.Now.AddHours(-1);
                Response.Cookies.Add(cookie);
            }
        }
        
    }
}