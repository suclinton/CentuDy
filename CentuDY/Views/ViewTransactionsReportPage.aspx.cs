using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CentuDY.Controllers;
using CentuDY.Report;

namespace CentuDY.Views
{
    public partial class ViewTransactionsReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HomeController.accessViewTransactionsReportPage(Response, Session);
            CentuDYReport report = new CentuDYReport();
            crvReport.ReportSource = report;
            report.SetDataSource(Controllers.DatasetController.getDataset());
        }
    }
}