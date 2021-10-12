using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CentuDY.Views
{
    public partial class UpdateProfilePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Controllers.ProfileController.getUpdatableUserProfile(Session, nameTxt, genderDDL, phoneNumberTxt, addressTxt, errorLbl);
            }
        }

        protected void updateProfileBtn_Click(object sender, EventArgs e)
        {
            String name = nameTxt.Text;
            String gender = genderDDL.SelectedValue;
            String phoneNumber = phoneNumberTxt.Text;
            String address = addressTxt.Text;
            errorLbl.Text = Controllers.ProfileController.validateUpdateProfile(name, gender, phoneNumber, address, Session);
        }
    }
}