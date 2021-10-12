using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CentuDY.Views
{
    public partial class ChangePasswordPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void updatePasswordBtn_Click(object sender, EventArgs e)
        {
            String oldPassword = oldPasswordText.Text;
            String newPassword = newPasswordText.Text;
            String confirmNewPassword = confirmNewPasswordText.Text;
            errorLabel.Text = Controllers.ProfileController.validatePassword(oldPassword, newPassword, confirmNewPassword, Session);
        }
    }
}