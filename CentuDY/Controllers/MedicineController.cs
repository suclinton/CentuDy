using CentuDY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI.WebControls;

namespace CentuDY.Controllers
{
    public static class MedicineController
    {
        public static void ShowMeds(GridView viewMedicineUserGV, HttpSessionState Session, GridView viewMedicineAdminGV, Button insertbtn)
        {
            if (Controllers.UserController.isAdminRole(Session))
            {
                viewMedicineAdminGV.DataSource = Handlers.MedicineHandler.GetMedicines();
                viewMedicineAdminGV.DataBind();
                insertbtn.Visible = true;
                viewMedicineAdminGV.Visible = true;
                viewMedicineUserGV.Visible = false;
            }
            else
            {
                viewMedicineUserGV.DataSource = Handlers.MedicineHandler.GetMedicines();
                viewMedicineUserGV.DataBind();
                insertbtn.Visible = false;
                viewMedicineAdminGV.Visible = false;
                viewMedicineUserGV.Visible = true;
            }
        }
        private static Boolean isEmpty(String input)
        {
            if (String.IsNullOrWhiteSpace(input))
            {
                return true;
            }
            return false;
        }

        private static String validateMedicineName(String medicineName)
        {
            if (isEmpty(medicineName))
            {
                return "Medicine name cannot be empty";
            }
            return "Success";
        }

        public static String insertMedicine(string medicineName, string medicineDescription, string medicinePrice, string medicineStock)
        {
            int medicinePriceInt = 0;
            int medicineStockInt = 0;
            String errorMsg = validateMedicineName(medicineName);
            if (errorMsg.Equals("Success"))
            {
                errorMsg = validateMedicineDescription(medicineDescription);
            }
            if (errorMsg.Equals("Success"))
            {
                errorMsg = validateMedicineStock(medicineStock);
            }
            if (errorMsg.Equals("Success"))
            {
                medicineStockInt = int.Parse(medicineStock);
                errorMsg = validateMedicineStockMoreThanZero(medicineStockInt);
                
            }
            if (errorMsg.Equals("Success"))
            {
                errorMsg = validateMedicinePrice(medicinePrice);
            }
            if (errorMsg.Equals("Success"))
            {
                medicinePriceInt = int.Parse(medicinePrice);
                errorMsg = validateMedicinePriceMoreThanZero(medicinePriceInt);
            }
            if (errorMsg.Equals("Success"))
            {
                Handlers.MedicineHandler.insertMedicine(medicineName, medicineDescription, medicinePriceInt, medicineStockInt);
                errorMsg = "Insert Success";
            }

            return errorMsg;
        }
        private static Boolean moreThanZero(int input)
        {
            if(input < 1)
            {
                return false;
            }
            return true;
        }
        private static string validateMedicineStockMoreThanZero(int medicineStockInt)
        {
            if (medicineStockInt <= 0 )
            {
                return "Medicine stock must be more than 0";
            }
            return "Success";
        }

        private static string validateMedicinePriceMoreThanZero(int medicinePriceInt)
        {
            if(medicinePriceInt <= 0)
            {
                return "Medicine Price must be mode than 0";
            }
            return "Success";
        }
        private static string validateMedicineStock(string medicineStock)
        {
            if (isEmpty(medicineStock))
            {
                return "Medicine stock cannot be empty";
            }
            try
            {
                int temp = Convert.ToInt32(medicineStock);
            }
            catch(Exception)
            {
                return "Medicine stock must be numeric";
            }

            return "Success";
        }
        private static string validateMedicinePrice(string medicinePrice)
        {
            if (isEmpty(medicinePrice))
            {
                return "Medicine Price cannot be empty";
            }
            try
            {
                int temp = Convert.ToInt32(medicinePrice);
            }
            catch (Exception)
            {
                return "Medicine price must be numeric";
            }
            return "Success";
        }

        private static Boolean isNumeric(String input)
        {
            foreach(char c in input)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        private static string validateMedicineDescription(string medicineDescription)
        {
            if (isEmpty(medicineDescription))
            {
                return "Medicine Description cannot be empty";
            }
            if(medicineDescription.Length < 10)
            {
                return "Medicine Description must be longer than 10 characters";
            }
            return "Success";
        }

        public static void showSearchMeds(GridView viewMedicineGV, String medicineName, GridView viewMedicineAdminGv)
        {
            viewMedicineGV.DataSource = Handlers.MedicineHandler.getMedicineByName(medicineName);
            viewMedicineGV.DataBind();

            viewMedicineAdminGv.DataSource = Handlers.MedicineHandler.getMedicineByName(medicineName);
            viewMedicineAdminGv.DataBind();
        }

        public static String deleteMedicine(GridView viewMedicineAdminGv, HttpSessionState Session, GridViewDeleteEventArgs e)
        {
            String medicineID = viewMedicineAdminGv.DataKeys[e.RowIndex].Value.ToString();
            return Handlers.MedicineHandler.deleteMedicineById(medicineID);
        }

        public static String getRowId(GridView viewMedicineAdminGv, HttpSessionState Session, GridViewUpdateEventArgs e)
        {
            String medicineID = viewMedicineAdminGv.DataKeys[e.RowIndex].Value.ToString();
            return medicineID;
        }

        public static bool ifNull (String medicineID)
        {
            Medicine medicine = Handlers.MedicineHandler.getMedicineByID(medicineID);
            if(medicine == null)
            {
                return true;
            }
            return false;
        }

        public static void showData(TextBox name, TextBox description, TextBox stock, TextBox price, HttpRequest Request, Label errorLbl)
        {
            String medicineId = Request.QueryString["MedicineId"];
            if (Controllers.MedicineController.ifNull(medicineId))
            {
                errorLbl.Text = "Not Found";
            }
            else
            {
                Medicine medicine = Handlers.MedicineHandler.getMedicineByID(medicineId);
                name.Text = medicine.Name;
                description.Text = medicine.Description;
                stock.Text = medicine.Stock.ToString();
                price.Text = medicine.Price.ToString();

            }
        }

        public static String updateMedicine(string medicineName, string medicineDescription, string medicinePrice, string medicineStock, String medicineId)
        {
            int medicinePriceInt = 0;
            int medicineStockInt = 0;

            String errorMsg = validateMedicineName(medicineName);
            if (errorMsg.Equals("Success"))
            {
                errorMsg = validateMedicineDescription(medicineDescription);
            }
            if (errorMsg.Equals("Success"))
            {
                errorMsg = validateMedicineStock(medicineStock);
            }
            if (errorMsg.Equals("Success"))
            {
                medicineStockInt = int.Parse(medicineStock);
                errorMsg = validateMedicineStockMoreThanZero(medicineStockInt);
            }
            if (errorMsg.Equals("Success"))
            {
                errorMsg = validateMedicinePrice(medicinePrice);
            }
            if (errorMsg.Equals("Success"))
            {
                medicinePriceInt = int.Parse(medicinePrice);
                errorMsg = validateMedicinePriceMoreThanZero(medicinePriceInt);
            }
            if (errorMsg.Equals("Success"))
            {
                Handlers.MedicineHandler.updateMedicine(medicineName, medicineDescription, medicinePriceInt, medicineStockInt, medicineId);
                errorMsg = "Update Success";
            }

            return errorMsg;
        }
    }
}