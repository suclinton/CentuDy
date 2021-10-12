using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CentuDY.Views
{
    public partial class ViewProfilePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Controllers.ProfileController.getUserInformation(Session, username, name, gender, phoneNumber, address, errorLbl);
        }

        protected void updateProfileBtn_Click(object sender, EventArgs e)
        {
            Controllers.ProfileController.redirectToUpdateProfilePage(Response);
        }

        protected void changePasswordBtn_Click(object sender, EventArgs e)
        {
            Controllers.ProfileController.redirectToChangePasswordPage(Response);
        }
    }
}