<%@ Page Title="" Language="C#" MasterPageFile="~/Views/HomeMasterPage.Master" AutoEventWireup="true" CodeBehind="UpdateMedicinePage.aspx.cs" Inherits="CentuDY.Views.EditMedicinePAge" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Label ID="medicineNameLbl" runat="server" Text="Name: "></asp:Label>
        <asp:TextBox ID="medicineNameText" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="medicineDescriptionLbl" runat="server" Text="Description: "></asp:Label>
        <asp:TextBox ID="medicineDescriptionText" TextMode="MultiLine" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="medicineStockLbl" runat="server" Text="Stock: "></asp:Label>
        <asp:TextBox ID="medicineStockText" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="medicinePriceLbl" runat="server" Text="Price: "></asp:Label>
        <asp:TextBox ID="medicinePriceText" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="errorLbl" runat="server" Text=""></asp:Label>
    </div>
    <div>
        <asp:Button ID="updateBtn" OnClick="updateBtn_Click" runat="server" Text="Update Medicine" />
    </div>
</asp:Content>
