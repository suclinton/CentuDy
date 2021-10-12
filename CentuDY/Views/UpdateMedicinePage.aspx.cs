using CentuDY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CentuDY.Views
{
    public partial class EditMedicinePAge : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Controllers.MedicineController.showData(medicineNameText, medicineDescriptionText, medicineStockText, medicinePriceText, Request, errorLbl);
            }
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            String medicineId = Request.QueryString["MedicineId"];
            String medicineName = medicineNameText.Text;
            String medicineDescription = medicineDescriptionText.Text;
            String medicinePrice = medicinePriceText.Text;
            String medicineStock = medicineStockText.Text;
            errorLbl.Text = Controllers.MedicineController.updateMedicine(medicineName, medicineDescription, medicinePrice, medicineStock, medicineId);
        }
    }
}