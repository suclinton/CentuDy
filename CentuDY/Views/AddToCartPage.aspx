<%@ Page Title="" Language="C#" MasterPageFile="~/Views/HomeMasterPage.Master" AutoEventWireup="true" CodeBehind="AddToCartPage.aspx.cs" Inherits="CentuDY.Views.AddToCartPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div>
        <asp:Label runat="server" Text="Medicine Name: "></asp:Label>
        <asp:Label ID="medicineName" runat="server" Text=""></asp:Label>
    </div>
    <div>
        <asp:Label runat="server" Text="Medicine Description: "></asp:Label>
        <asp:Label ID="medicineDescription" runat="server" Text=""></asp:Label>
    </div>
    <div>
        <asp:Label runat="server" Text="Medicine Stock: "></asp:Label>
        <asp:Label ID="medicineStock" runat="server" Text=""></asp:Label>
    </div>
    <div>
        <asp:Label runat="server" Text="Medicine Price: "></asp:Label>
        <asp:Label ID="medicinePrice" runat="server" Text=""></asp:Label>
    </div>
    <div>
        <asp:Label ID="medicineInputLbl" runat="server" Text="Insert how the quantitiy you want to purchase: "></asp:Label>
        <asp:TextBox ID="medicinePurchaseQuantity" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="errorLbl" runat="server" Text=""></asp:Label>
    </div>
    <div>
        <asp:Button ID="addToCartBtn" OnClick="addToCartBtn_Click" runat="server" Text="Add to Cart" />
    </div>
</asp:Content>
