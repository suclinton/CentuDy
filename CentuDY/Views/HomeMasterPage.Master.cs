using CentuDY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CentuDY.Views
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        private void hideAllButton()
        {
            logoutBtn.Visible = false;
            viewMedicineBtn.Visible = false;
            viewProfileBtn.Visible = false;
            viewCartBtn.Visible = false;
            viewTransactionHistoryBtn.Visible = false;
            inserMedicineBtn.Visible = false;
            viewUsersBtn.Visible = false;
            viewTransactionsReportBtn.Visible = false;
        }

        private void getSession()
        {
            if (Session["UserLoggedin"] != null)
            {
                User loggedInUser = (User)Session["UserLoggedin"];
                logoutBtn.Visible = true;
                viewMedicineBtn.Visible = true;
                viewProfileBtn.Visible = true;
                if (loggedInUser.RoleId.Equals("RO001"))
                {
                    inserMedicineBtn.Visible = true;
                    viewUsersBtn.Visible = true;
                    viewTransactionsReportBtn.Visible = true;
                }
                else
                {
                    viewCartBtn.Visible = true;
                    viewTransactionHistoryBtn.Visible = true;
                }
            }
            else
            {
                Response.Redirect("~/Views/LoginPage.aspx");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Controllers.UserController.getCookie(Request);
            getSession();
        }

        protected void LogoutBtn_Click(object sender, EventArgs e)
        {
            Controllers.HomeController.userLogout(Session, Response);
        }


        protected void ViewMedicineBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ViewMedicinesPage.aspx");

        }

        protected void ViewProfileBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ViewProfilePage.aspx");
        }

        protected void ViewCartBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ViewCartPage.aspx");
        }

        protected void ViewTransactionHistoryBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ViewTransactionHistoryPage.aspx");
        }

        protected void InserMedicineBtn_Click(object sender, EventArgs e)
        {
            Controllers.HomeController.accessInsertMedicinePage(Response, Session);
            Response.Redirect("~/Views/InsertMedicinePage.aspx");
        }

        protected void ViewUsersBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ViewUsersPage.aspx");
        }

        protected void ViewTransactionsReportBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ViewTransactionsReportPage.aspx");
        }
    }
}