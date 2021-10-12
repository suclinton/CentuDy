using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CentuDY.Views
{
    public partial class InsertMedicinePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Controllers.HomeController.accessInsertMedicinePage(Response, Session);

        }

        protected void insertBtn_Click(object sender, EventArgs e)
        {
            String medicineName = medicineNameText.Text;
            String medicineDescription = medicineDescriptionText.Text;
            String medicinePrice = medicinePriceText.Text;
            String medicineStock = medicineStockText.Text;
            errorLbl.Text = Controllers.MedicineController.insertMedicine(medicineName, medicineDescription, medicinePrice, medicineStock);
        }
    }
}