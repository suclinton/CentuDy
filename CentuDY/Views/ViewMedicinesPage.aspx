<%@ Page Title="" Language="C#" MasterPageFile="~/Views/HomeMasterPage.Master" AutoEventWireup="true" CodeBehind="ViewMedicinesPage.aspx.cs" Inherits="CentuDY.Views.ViewMedicinesPage" EnableEventValidation="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="searchUser">
        <asp:TextBox ID="searchBox" runat="server"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
    </div>

    <div>
        <asp:GridView DataKeyNames="MedicineId" ID="viewMedicineUserGV" AutoGenerateColumns="False" runat="server" OnSelectedIndexChanging="viewMedicineGV_SelectedIndexChanging" Visible="true">
            <Columns>
                <asp:BoundField DataField="MedicineId" Visible="false" HeaderText="ID" SortExpression="MedicineId" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                <asp:BoundField DataField="Stock" HeaderText="Stock" SortExpression="Stock" />
                <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                <asp:ButtonField ButtonType="button" CommandName="select" HeaderText="add to cart" ShowHeader="true" Text="add to cart" />
            </Columns>
        </asp:GridView>

        <asp:GridView DataKeyNames="MedicineId" ID="viewMedicineAdminGV" AutoGenerateColumns="False" runat="server" OnRowUpdating="viewMedicineAdminGV_RowUpdating" OnRowDeleting="viewMedicineAdminGV_RowDeleting" Visible="true">
            <Columns>
                <asp:BoundField DataField="MedicineId" Visible="false" HeaderText="ID" SortExpression="MedicineId" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                <asp:BoundField DataField="Stock" HeaderText="Stock" SortExpression="Stock" />
                <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                <asp:buttonfield buttontype="button" commandname="update" text="update medicine"/>
                <asp:buttonfield buttontype="button" commandname="delete" text="delete medicine" />
            </Columns>
        </asp:GridView>
        <asp:Button ID="insertbtn" runat="server" Text="Insert" Visible="false" OnClick="insertbtn_Click" />
        <asp:Label ID="errorLbl" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
