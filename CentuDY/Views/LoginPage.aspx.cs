using CentuDY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace CentuDY.Views
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                usernameTxt.Text = Controllers.UserController.getUsernameFromCookie(Request);
                passwordTxt.Attributes.Add("value", Controllers.UserController.getPasswordFromCookie(Request));
            }
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            String username = usernameTxt.Text;
            String password = passwordTxt.Text;
            bool userCheckRememberMe = rememberMeChk.Checked;
            errorLbl.Text = Controllers.UserLoginController.userLoginAuthentication(username, password, userCheckRememberMe, Session, Response, Request);
        }
    }
}