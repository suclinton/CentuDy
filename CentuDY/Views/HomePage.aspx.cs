using CentuDY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CentuDY.Controllers;
namespace CentuDY.Views
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserController.getCookie(Request);
            UserController.getSession(Session, Request);
            if (!Page.IsPostBack)
            {
                HomeController.showRecommended(welcomeLbl, recommendedText, recommendedMedicineGV, Session);
            }
        }

        protected void recommendedMedicineGV_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            CartController.responseSelectQueryString(recommendedMedicineGV, Response, e);
        }
    }
}