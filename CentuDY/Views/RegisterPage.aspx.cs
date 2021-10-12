using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CentuDY.Views
{
    public partial class RegisterPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void registerBtn_Click(object sender, EventArgs e)
        {
            String username = usernameTxt.Text;
            String password = passwordTxt.Text;
            String confirmPassword = confirmpasswordTxt.Text;
            String name = nameTxt.Text;
            String phoneNumber = phoneNumberTxt.Text;
            String address = addressTxt.Text;
            String gender = genderDDL.SelectedValue;
            String errorMsg = Controllers.UserRegisterController.userRegisterAuthentication
                            (username, password, confirmPassword, name, gender, phoneNumber, address, Response);
                errorLbl.Text = errorMsg;
            
        }
    }
}