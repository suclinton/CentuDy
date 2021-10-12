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
    public partial class AddToCartPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            HomeController.accessAddToCartPage(Response, Session);            
            if (!Page.IsPostBack)
            {
                Medicine medicine = CartController.requestQueryString(Request);
                CartController.displayMedicine(Response, medicine, medicineName, medicineDescription, medicineStock, medicinePrice);
            }
        }

        protected void addToCartBtn_Click(object sender, EventArgs e)
        {
            String quantity = medicinePurchaseQuantity.Text;
            errorLbl.Text = CartController.validateQuantity(quantity, Request, Session, Response);
        }
    }
}