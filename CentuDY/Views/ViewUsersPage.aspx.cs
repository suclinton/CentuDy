using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CentuDY.Controllers;

namespace CentuDY.Views
{
    public partial class ViewUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserController.getCookie(Request);
            UserController.getSession(Session, Request);
            HomeController.accessViewUsersPage(Response, Session);
            UserController.showUser(viewUserGV, Session);
        }

        protected void viewUserGV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            errorLbl.Text = UserController.deleteUser(viewUserGV, Session, e);
            UserController.showUser(viewUserGV, Session);
        }
    }
}