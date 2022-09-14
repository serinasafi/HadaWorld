<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LedgerEntry.aspx.cs" Inherits="HadaWorld.LedgerEntry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

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
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:hadaConnectionString %>" SelectCommand="SELECT [ledgerId], [ledHead] FROM [LedgerHead]"></asp:SqlDataSource>
            </td>
            <td>&nbsp;</td>
        </tr>
        <asp:Panel runat="server" ID="pSales">
            <tr>
            <td style="width: 103px; height: 20px">Customer Name</td>
            <td style="height: 20px">
                <asp:TextBox ID="txtCustomer" runat="server" Width="324px"></asp:TextBox>
            </td>
            <td style="height: 20px"></td>
            </tr>
            <tr>
            <td style="width: 103px; height: 20px">Customer Company</td>
            <td style="height: 20px">
                <asp:TextBox ID="txtCustcompany" runat="server" Width="321px"></asp:TextBox>
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
            <td style="width: 103px; height: 20px">Product</td>
            <td style="height: 20px">
                
                <asp:DropDownList ID="ddlProducts" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource3" DataTextField="prodName" DataValueField="prodid" OnSelectedIndexChanged="ddlProducts_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:hadaConnectionString %>" SelectCommand="SELECT [prodid], [prodName] FROM [Products]"></asp:SqlDataSource>
                
            </td>
            <td style="height: 20px"></td>
            </tr>
            <tr>
            <td style="width: 103px; height: 20px">Is Complimentary</td>
            <td style="height: 20px">
                
                <asp:RadioButtonList ID="rdCompliment" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rdCompliment_SelectedIndexChanged" RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True">No</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                </asp:RadioButtonList>
                
            </td>
            <td style="height: 20px"></td>
            </tr>
            <tr>
                <td style="width: 103px; height: 20px">Invoice No(ZOHO)</td>
                <td style="height: 20px">
                    <asp:TextBox ID="txtInvNo" runat="server" Enabled="false"></asp:TextBox>
                </td>
                <td style="height: 20px"></td>
            </tr>
        </asp:Panel>
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
            <td style="width: 103px; height: 20px;"></td>
            <td style="height: 20px"></td>
            <td style="height: 20px"></td>
        </tr>
        <tr>
            <td style="width: 103px">&nbsp;</td>
            <td>
                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 103px; height: 20px;"></td>
            <td style="height: 20px"></td>
            <td style="height: 20px"></td>
        </tr>
        <tr>
            <td style="width: 103px">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Caption="Ledger Entries" DataKeyNames="transid" DataSourceID="SqlDataSource2">
                    <Columns>
                        <asp:BoundField DataField="transid" HeaderText="transid" InsertVisible="False" ReadOnly="True" SortExpression="transid" />
                        <asp:BoundField DataField="transDate" HeaderText="transDate" SortExpression="transDate" />
                        <asp:BoundField DataField="transLedid" HeaderText="transLedid" SortExpression="transLedid" />
                        <asp:BoundField DataField="transAmount" HeaderText="transAmount" SortExpression="transAmount" />
                        <asp:BoundField DataField="transType" HeaderText="transType" SortExpression="transType" />
                        <asp:BoundField DataField="transDescription" HeaderText="transDescription" SortExpression="transDescription" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:hadaConnectionString %>" SelectCommand="SELECT [transid], [transDate], [transLedid], [transAmount], [transType], [transDescription] FROM [LedgerEntries]"></asp:SqlDataSource>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>

</asp:Content>
