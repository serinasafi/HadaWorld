<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShowLedgers.aspx.cs" Inherits="HadaWorld.ShowLedgers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <table style="width: 100%">
        <tr>
            <td colspan="3">
                <asp:Label ID="message" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td colspan="3">Show ledgers</td>
        </tr>
         <tr>
            <td style="width: 103px">
                <asp:DropDownList ID="ddlLedger" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="ledHead" DataValueField="ledgerId">
                    <asp:ListItem Value="-1">Select</asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:hadaConnectionString %>" SelectCommand="SELECT [ledgerId], [ledHead] FROM [LedgerHead]"></asp:SqlDataSource>
             </td>
            <td>From : <asp:TextBox ID="txtFrom" runat="server" TextMode="Date"></asp:TextBox></td>
            <td>To : <asp:TextBox ID="txtTo" runat="server" TextMode="Date"></asp:TextBox></td>
        </tr>
         <tr>
            <td style="width: 103px"></td>
            <td>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" /></td>
            <td>&nbsp;</td>
        </tr>
         <tr>
            <td colspan="3">Showing Ledger Entries</td>            
        </tr>
         <tr>
            <td colspan="3">
                <asp:GridView ID="grdLedger" runat="server"></asp:GridView>
            </td>            
        </tr>
         <tr>
            <td colspan="3">Total : <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label></td>            
        </tr>
         </table>
</asp:Content>
