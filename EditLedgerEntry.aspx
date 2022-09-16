<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditLedgerEntry.aspx.cs" Inherits="HadaWorld.EditLedgerEntry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <table style="width: 100%">
        <tr>
            <td colspan="3">
                <asp:Label ID="message" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 103px">Ledger Entry</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 103px">Date</td>
            <td>
                <asp:TextBox ID="txtDate" runat="server" TextMode="Date"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 103px">Ledger Head</td>
            <td>
                <asp:DropDownList ID="ddlHead" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="ledHead" DataValueField="ledgerId" OnSelectedIndexChanged="ddlHead_SelectedIndexChanged">
                    <asp:ListItem Value="-1">Select</asp:ListItem>
                
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:hadaConnectionString %>" SelectCommand="SELECT [ledgerId], [ledHead] FROM [LedgerHead]"></asp:SqlDataSource>
            </td>
            <td>&nbsp;</td>
        </tr>
        <asp:panel runat="server" ID="pSales" Visible="false">
            <tr>
            <td style="width: 103px; height: 20px">Customer Name</td>
            <td style="height: 20px">
                <asp:TextBox ID="txtCustname" runat="server" Width="270px"></asp:TextBox>
            </td>
            <td style="height: 20px"></td>
        </tr>
            <tr>
            <td style="width: 103px; height: 20px">Customer Company</td>
            <td style="height: 20px">
                <asp:TextBox ID="txtCustcompany" runat="server" Width="266px"></asp:TextBox>
            </td>
            <td style="height: 20px"></td>
        </tr>
             <tr>
            <td style="width: 103px; height: 20px">Customer Mobile</td>
            <td style="height: 20px">
                <asp:TextBox ID="txtCustmobile" runat="server"></asp:TextBox>
            </td>
            <td style="height: 20px"></td>
        </tr>
             <tr>
            <td style="width: 103px; height: 20px">Customer C/O</td>
            <td style="height: 20px">
                <asp:DropDownList ID="ddlCustcof" runat="server" DataSourceID="SqlDataSource3" DataTextField="custName" DataValueField="custid">
                    <asp:ListItem Value="-1">Select</asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:hadaConnectionString %>" SelectCommand="SELECT [custid], [custName] FROM [Customers]"></asp:SqlDataSource>
            </td>
            <td style="height: 20px"></td>
        </tr>
            <tr>
            <td style="width: 103px; height: 20px">Is Compliment</td>
            <td style="height: 20px">
                <asp:RadioButtonList ID="rdCompli" runat="server" RepeatDirection="Horizontal" AutoPostBack="True">
                    <asp:ListItem Selected="True" Value="0">No</asp:ListItem>
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td style="height: 20px"></td>
        </tr>
        <tr>
            <td style="width: 103px; height: 20px">Product</td>
            <td style="height: 20px">
                <asp:DropDownList ID="ddlProduct" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource4" DataTextField="prodName" DataValueField="prodid" OnSelectedIndexChanged="ddlProduct_SelectedIndexChanged">
                    <asp:ListItem Value="-1">Select</asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:hadaConnectionString %>" SelectCommand="SELECT [prodid], [prodName] FROM [Products]"></asp:SqlDataSource>
            </td>
            <td style="height: 20px"></td>
        </tr>
             <tr>
            <td style="width: 103px; height: 20px">Invoice Number</td>
            <td style="height: 20px">
                <asp:TextBox ID="txtInvNo" runat="server"></asp:TextBox>
            </td>
            <td style="height: 20px"></td>
        </tr>
        </asp:panel>
        <tr>
            <td style="width: 103px; height: 20px">Amount</td>
            <td style="height: 20px">
                <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>
            </td>
            <td style="height: 20px"></td>
        </tr>
        <tr>
            <td style="width: 103px">Description</td>
            <td>
                <asp:TextBox ID="txtDesc" runat="server" Height="87px" TextMode="MultiLine" Width="429px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 103px">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 103px">&nbsp;</td>
            <td>
                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 103px">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 103px">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
            <tr>
            <td>From :<asp:TextBox ID="txtFrom" runat="server" TextMode="Date"></asp:TextBox> </td>
            <td>To :<asp:TextBox ID="txtTo" runat="server" TextMode="Date"></asp:TextBox> &nbsp;&nbsp;&nbsp;<asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" /></td>
            <td>
                </td>
        </tr>
            
        <tr>
            <td colspan="2">
                <asp:GridView ID="grdLedger" runat="server" Caption="Ledger Entries" DataKeyNames="transid" AllowCustomPaging="True" AllowPaging="True" AllowSorting="True" PageSize="50" OnRowCommand="grdLedger_RowCommand">
                    <Columns>
                        <asp:ButtonField CommandName="Change" Text="Edit"/>
                        </Columns> 
                    
                </asp:GridView>                
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
