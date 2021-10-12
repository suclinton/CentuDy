using CentuDY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI.WebControls;

namespace CentuDY.Controllers
{
    public static class TransactionHistoryController
    {
        public static void getTransactionDetailData(GridView transactionHistoryGV, HttpSessionState Session)
        {
            User user = Controllers.UserController.getUserFromSession(Session);
            transactionHistoryGV.DataSource = Repositories.TransactionDetailRepository.GetTransactionDetailsWithMedicine(user.UserId);
            transactionHistoryGV.DataBind();
        }

        public static void displaySubtotalAndGrandTotal(GridView transactionHistoryGV, GridViewRowEventArgs e, HttpSessionState Session)
        {
            User user = UserController.getUserFromSession(Session);
            List<DetailTransaction> detailTransaction = Handlers.TranscationDetailHandler.getTransactionDetails(user.UserId);
            for (int i = 0; i < transactionHistoryGV.Rows.Count; i++)
            {
                
                String medicineID = transactionHistoryGV.DataKeys[i].Value.ToString();
                Medicine medicine = Handlers.MedicineHandler.getMedicineByID(medicineID);
                transactionHistoryGV.Rows[i].Cells[3].Text = detailTransaction[i].HeaderTransaction.TransactionDate.ToString("dd/MM/yyyy");
                transactionHistoryGV.Rows[i].Cells[4].Text = (detailTransaction[i].Quantity * medicine.Price).ToString();
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                ((Label)(e.Row.FindControl("grandTotal"))).Text = Handlers.TranscationDetailHandler.getGrandTotal(user.UserId).ToString();
            }
        }
    }
}