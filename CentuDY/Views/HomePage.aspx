<%@ Page Title="" Language="C#" MasterPageFile="~/Views/HomeMasterPage.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="CentuDY.Views.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="welcomeLbl" runat="server" Text=""></asp:Label>
    <div>
        <asp:Label ID="recommendedText" visible="false" runat="server" Text="Recommended Medicine for you"></asp:Label>
        <asp:GridView DataKeyNames="MedicineId" ID="recommendedMedicineGV"  AutoGenerateColumns="False" runat="server" OnSelectedIndexChanging="recommendedMedicineGV_SelectedIndexChanging">
            <Columns>
                <asp:BoundField DataField="MedicineId" Visible="false" HeaderText="ID" SortExpression="MedicineId" />
                <asp:BoundField DataField="Name" HeaderText="Medicine" SortExpression="Name" />
                <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Add To Cart" ShowHeader="True" Text="Add To Cart" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
