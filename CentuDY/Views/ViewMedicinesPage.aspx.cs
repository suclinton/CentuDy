using CentuDY.Controllers;
using CentuDY.Handlers;
using CentuDY.Models;
using CentuDY.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CentuDY.Views
{
    public partial class ViewMedicinesPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserController.getCookie(Request);
            UserController.getSession(Session, Request);
            Controllers.MedicineController.ShowMeds(viewMedicineUserGV, Session, viewMedicineAdminGV, insertbtn);
        }

        protected void viewMedicineGV_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Controllers.CartController.responseSelectQueryString(viewMedicineUserGV, Response, e);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Controllers.MedicineController.showSearchMeds(viewMedicineUserGV, searchBox.Text, viewMedicineAdminGV);
        }

        protected void insertbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/InsertMedicinePage.aspx");
        }

        protected void viewMedicineAdminGV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            errorLbl.Text = Controllers.MedicineController.deleteMedicine(viewMedicineAdminGV, Session, e);
            Controllers.MedicineController.ShowMeds(viewMedicineUserGV, Session, viewMedicineAdminGV, insertbtn);
        }

        protected void viewMedicineAdminGV_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            String id = Controllers.MedicineController.getRowId(viewMedicineAdminGV, Session, e);
            Response.Redirect("~/Views/UpdateMedicinePage.aspx?MedicineId=" + id);
        }
    }
}