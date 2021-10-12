using CentuDY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI.WebControls;

namespace CentuDY.Controllers
{
    public static class HomeController
    {
        public static List<Medicine> getRecommendedMedicine(HttpSessionState Session)
        {
            if (!UserController.isAdminRole(Session))
            {
                return Handlers.MedicineHandler.getRecommendedMedicine();
            }
            return null;
        }

        public static void showRecommended(Label welcomeLbl, Label recommendedText, GridView recommendedMedicineGV,HttpSessionState Session)
        {
            welcomeLbl.Text = "Welcome " + Controllers.UserController.getUsernameFromSession(Session);
            if (Controllers.UserController.isAdminRole(Session))
            {
                return;
            }
            recommendedText.Visible = true;
            recommendedMedicineGV.DataSource = HomeController.getRecommendedMedicine(Session);
            recommendedMedicineGV.DataBind();
        }

        public static void accessInsertMedicinePage(HttpResponse Response, HttpSessionState Session)
        {
            if (!UserController.isAdminRole(Session))
            {
                Response.Redirect("~/Views/HomePage.aspx");
                return;
            }
        }

        public static void accessViewUsersPage(HttpResponse Response, HttpSessionState Session)
        {
            if (!UserController.isAdminRole(Session))
            {
                Response.Redirect("~/Views/HomePage.aspx");
                return;
            }
        }

        public static void accessViewTransactionsReportPage(HttpResponse Response, HttpSessionState Session)
        {
            if (!UserController.isAdminRole(Session))
            {
                Response.Redirect("~/Views/HomePage.aspx");
                return;
            }
        }

        public static void accessViewCartPage(HttpResponse Response, HttpSessionState Session)
        {
            if (UserController.isAdminRole(Session))
            {
                Response.Redirect("~/Views/HomePage.aspx");
                return;
            }
        }

        public static void accessViewTransactionHistoryPage(HttpResponse Response, HttpSessionState Session)
        {
            if (UserController.isAdminRole(Session))
            {
                Response.Redirect("~/Views/HomePage.aspx");
                return;
            }
        }
        public static void accessAddToCartPage(HttpResponse Response, HttpSessionState Session)
        {
            if (UserController.isAdminRole(Session))
            {
                Response.Redirect("~/Views/HomePage.aspx");
                return;
            }
        }

        public static void userLogout(HttpSessionState Session, HttpResponse Response)
        {
            Session["UserLoggedin"] = null;
            HttpCookie cookie = new HttpCookie("LoginCookie");
            cookie.Expires = DateTime.Now.AddHours(-1);
            Response.Cookies.Add(cookie);
            Response.Redirect("~/Views/LoginPage.aspx");
        }

    }
}