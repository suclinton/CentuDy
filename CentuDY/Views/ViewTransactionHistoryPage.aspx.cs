using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CentuDY.Controllers;
namespace CentuDY.Views
{
    public partial class ViewTransactionHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HomeController.accessViewTransactionHistoryPage(Response, Session);
            TransactionHistoryController.getTransactionDetailData(transactionHistoryGV, Session);

        }


        protected void transactionHistoryGV_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            TransactionHistoryController.displaySubtotalAndGrandTotal(transactionHistoryGV, e, Session);

        }
    }
}