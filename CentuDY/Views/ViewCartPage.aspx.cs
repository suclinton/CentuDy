using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CentuDY.Controllers;
using CentuDY.Models;

namespace CentuDY.Views
{
    public partial class ViewCartPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HomeController.accessViewCartPage(Response, Session);
            if (!Page.IsPostBack)
            {
                CartController.displayCart(Session, viewCartGV);
            }

        }

        protected void viewCartGV_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            CartController.displaySubtotalAndGrandTotal(viewCartGV, e, Session);
        }

        protected void viewCartGV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            errorLbl.Text = Controllers.CartController.deleteItemCart(viewCartGV, Session, e);
            CartController.displayCart(Session, viewCartGV);

        }

        protected void CheckoutButton_Click(object sender, EventArgs e)
        {
            errorLbl.Text = CartController.checkoutCart(Session);
            CartController.displayCart(Session, viewCartGV);
        }
    }
}