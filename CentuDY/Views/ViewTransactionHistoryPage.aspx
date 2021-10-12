<%@ Page Title="" Language="C#" MasterPageFile="~/Views/HomeMasterPage.Master" AutoEventWireup="true" CodeBehind="ViewTransactionHistoryPage.aspx.cs" Inherits="CentuDY.Views.ViewTransactionHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="transactionHistoryGV" DataKeyNames="MedicineId" AutoGenerateColumns="False" runat="server" OnRowDataBound="transactionHistoryGV_RowDataBound" ShowFooter="true">
        <Columns>
            <asp:BoundField DataField="MedicineId" Visible="false" HeaderText="Medicine ID" SortExpression="MedicineId" />
            <asp:BoundField DataField="Medicine.Name" HeaderText="Medicine Name" SortExpression="Medicine.Name" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
            <asp:BoundField DataField="HeaderTransaction.TransactionDate" HeaderText="Date" SortExpression="HeaderTransaction.TransactionDate" />
            <asp:TemplateField HeaderText="Sub Total" >
                <ItemTemplate>
                    <asp:Label ID="subTotal" runat="server" Text=""></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <b>Grand Total:&nbsp;</b>
                    <asp:Label ID="grandTotal" runat="server" Text=""></asp:Label>  

                </FooterTemplate>
            </asp:TemplateField>
        </Columns>

    </asp:GridView>
</asp:Content>
