using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using CentuDY.Controllers;
using CentuDY.Models;
namespace CentuDY.Controllers
{
    public static class CartController
    {
        public static Medicine requestQueryString(HttpRequest Request)
        {
            String medicineID = Request.QueryString["medicineID"];
            Medicine medicineData = Repositories.MedicineRepository.getMedicineByID(medicineID);
            return medicineData;
        }
        public static void responseSelectQueryString(GridView recommendedMedicineGV, HttpResponse Response, GridViewSelectEventArgs e)
        {
            String medicineID = recommendedMedicineGV.DataKeys[e.NewSelectedIndex].Value.ToString();
            Response.Redirect("~/Views/AddToCartPage.aspx?medicineID=" + medicineID);
        }
        public static String deleteItemCart(GridView viewCartGV, HttpSessionState Session , GridViewDeleteEventArgs e)
        {
            User user = UserController.getUserFromSession(Session);
            String medicineID = viewCartGV.DataKeys[e.RowIndex].Value.ToString();
            return Handlers.CartHandler.deleteItemFromCart(user.UserId, medicineID);
        }

        public static String checkoutCart(HttpSessionState session)
        {
            User user = UserController.getUserFromSession(session);
            return Handlers.CartHandler.checkoutCart(user.UserId);
        }


        public static void displayMedicine(HttpResponse Response, Medicine medicine, Label medicineName, Label medicineDescription, Label medicineStock, Label medicinePrice)
        {
            if(medicine == null)
            {
                Response.Redirect("~/Views/HomePage.aspx");
                return;
            }
            medicineName.Text = medicine.Name;
            medicineDescription.Text = medicine.Description;
            medicineStock.Text = medicine.Stock.ToString();
            medicinePrice.Text = medicine.Price.ToString();
        }

        public static void displaySubtotalAndGrandTotal(GridView viewCartGV, GridViewRowEventArgs e, HttpSessionState Session)
        {

            User user = UserController.getUserFromSession(Session);
            for (int i = 0; i < viewCartGV.Rows.Count; i++)
            {
                String medicineID = viewCartGV.DataKeys[i].Value.ToString();
                int total = Handlers.CartHandler.getSubTotal(user.UserId, medicineID);
                viewCartGV.Rows[i].Cells[4].Text = total.ToString();
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                ((Label)(e.Row.FindControl("grandTotal"))).Text = Handlers.CartHandler.getGrandTotal(user.UserId).ToString();
            }

        }

        public static void displayCart(HttpSessionState Session, GridView viewCartGV)
        {
            User user = UserController.getUserFromSession(Session);
            viewCartGV.DataSource = Handlers.CartHandler.getCarts(user.UserId);
            viewCartGV.DataBind();
        }

        private static String isNumeric(string quantity)
        {
            try
            {
                int temp = Convert.ToInt32(quantity);
            }
            catch (Exception)
            {
                return "Quantity must be numeric";
            }
            return "Success";
        }

        private static String isEmpty(string quantity)
        {
            if (String.IsNullOrWhiteSpace(quantity))
            {
                return "Quantity cannot be empty";
            }
            return "Success";
        }

        private static String cannotBeZero(int quantity)
        {
            if(quantity <= 0)
            {
                return "Must be more than zero";
            }
            return "Success";
        }

        public static string validateQuantity(string inputQuantity, HttpRequest Request, HttpSessionState Session, HttpResponse Response)
        {
            String medicineID = Request.QueryString["medicineID"];
            User user = (User)Session["UserLoggedin"];
            //Medicine medicine = Handlers.MedicineHandler.getMedicineByID(medicineID);
            int quantity = 0;
            String errorMsg = isEmpty(inputQuantity);
            if (errorMsg.Equals("Success"))
            {
                errorMsg = isNumeric(inputQuantity);
            }
            if (errorMsg.Equals("Success"))
            {
                quantity = int.Parse(inputQuantity);
                errorMsg = cannotBeZero(quantity);
            }
            if (errorMsg.Equals("Success"))
            {
                errorMsg = Handlers.CartHandler.validateInputQuantityWithStock(medicineID, quantity);
            }
            if (errorMsg.Equals("Success"))
            {
                Handlers.CartHandler.insertToCart(user.UserId, medicineID, quantity);
                Response.Redirect("~/Views/ViewCartPage.aspx");
            }
            return errorMsg;

        }
    }
}