<%@ Page Title="" Language="C#" MasterPageFile="~/Views/HomeMasterPage.Master" AutoEventWireup="true" CodeBehind="ViewCartPage.aspx.cs" Inherits="CentuDY.Views.ViewCartPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:GridView ShowFooter="True" DataKeyNames="MedicineId" ID="viewCartGV" AutoGenerateColumns="False" runat="server" OnRowDataBound="viewCartGV_RowDataBound" OnRowDeleting="viewCartGV_RowDeleting" >
        <Columns>

            <asp:BoundField DataField="Medicine.MedicineId" Visible="false" HeaderText="ID" SortExpression="MedicineId" />
            <asp:BoundField DataField="Medicine.Name" HeaderText="Medicine Name" SortExpression="Name" />
            <asp:BoundField DataField="Quantity" HeaderText="Medicine Quantity" SortExpression="Quantity" />
            <asp:BoundField DataField="Medicine.Price" HeaderText="Medicine Price" SortExpression="Medicine.Price" />
            <asp:TemplateField HeaderText="Sub Total" >
                <ItemTemplate>
                    <asp:Label ID="subTotal" runat="server" Text=""></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <b>Grand Total:&nbsp;</b>
                    <asp:Label ID="grandTotal" runat="server" Text=""></asp:Label>  

                </FooterTemplate>
            </asp:TemplateField>
            <asp:ButtonField ButtonType="Button" CommandName="Delete" Text="Remove Medicine" />
        </Columns>
    </asp:GridView>

    <asp:Label ID="errorLbl" runat="server" Text=""></asp:Label>
    <div>
        <asp:Button ID="CheckoutButton" OnClick="CheckoutButton_Click" runat="server" Text="Checkout" />

    </div>
</asp:Content>
