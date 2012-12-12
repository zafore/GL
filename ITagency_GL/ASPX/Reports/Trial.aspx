<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Trial.aspx.cs" Inherits="ITagency_GL.ASPX.Reports.Trial" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
    .style5
    {
        width: 100%;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <table class="mainTable">
            <tr>
                <td class="title" colspan="2">
                    Trial balanceTrial balance / تقرير ميزان المراجعة
                </td>
            </tr>
            <tr>
                <td width="20%">
                    Financial year / السنة المالية</td>
                <td>
                    <asp:DropDownList ID="ddlFinancialPeriod" runat="server" 
                        DataSourceID="ddlFinancial" DataTextField="PeriodYear" 
                        DataValueField="PeriodId">
                        <asp:ListItem Value="0">Select</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Revenue Center / مركز الإيرادات</td>
                <td>
                    <asp:DropDownList ID="ddlProfitCenters" runat="server" 
                        AppendDataBoundItems="True" DataSourceID="odsCenter" 
                        DataTextField="CenterName" DataValueField="CenterID" Width="160px">
                        <asp:ListItem Selected="True" Value="0">اختيار</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <table class="style5">
                        <tr>
                            <td width="20%">
                                &nbsp;</td>
                            <td>
                                <telerik:RadDatePicker ID="txtFrom" Runat="server">
                                </telerik:RadDatePicker>
                            </td>
                            <td width="20%">
                                &nbsp;</td>
                            <td width="30%">
                                <telerik:RadDatePicker ID="txtTo" Runat="server">
                                </telerik:RadDatePicker>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btnView" runat="server" onclick="btnView_Click" Text="View" 
                        ValidationGroup="View" Width="100px" />
                    &nbsp;<asp:Button ID="btnClear" runat="server" Text="Clear" Width="100px" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Label ID="lblFeedBack" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:ObjectDataSource ID="ddlFinancial" runat="server" SelectMethod="view" 
                        TypeName="BLL.Financial_Period.Financial_Period">
                        <SelectParameters>
                            <asp:SessionParameter Name="CompId" SessionField="CompId" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <br />
                    <asp:ObjectDataSource ID="odsCenter" runat="server" 
                        SelectMethod="GetAll_By_CompId" 
                        TypeName="BLL.Profit_Center.Profit_Center">
                        <SelectParameters>
                            <asp:SessionParameter DefaultValue="" Name="CompId" SessionField="CompId" 
                                Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
