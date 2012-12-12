<%@ Page Title="Accounts Chart" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AccountsChart.aspx.cs" Inherits="ITagency_GL.ASPX.AccountsChart.AccountsChart" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

   
    <style type="text/css">
        .style5
        {
            color: #FF0000;
            width: 60%;
        }
        .style6
        {
            width: 60%;
        }
        .Title
        {
            background-color: #6C8BB4;
        }
    </style>

   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <table width="100%" class="mainTable">
        <tr class="title">
        
        <td colspan="2" class="title" style="background-color: #465767" >A<span class="hps">ccounting</span>&nbsp; Tree - اعداد 
            الشجرة المحاسبية</span></td></tr>
            <tr>
                <td width="50%">
                    <asp:Panel ID="pnlData" runat="server" Height="100%" Width="100%">
                        <table ID="tbDate" width="100%">
                            <tr>
                                <td width="40%">
                                    Account Name / اسم الحساب</td>
                                <td class="style5">
                                    <asp:TextBox ID="txtAccName" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ControlToValidate="txtAccName" ErrorMessage="*" 
                                        ValidationGroup="Save"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Account Type / نوع الحساب</td>
                                <td class="style5">
                                    <asp:DropDownList ID="ddlAccountType" runat="server" 
                                        AppendDataBoundItems="True" DataSourceID="odsAccountType" 
                                        DataTextField="AccountTypeName" DataValueField="AccountTypeID">
                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                        ControlToValidate="ddlAccountType" ErrorMessage="*" 
                                        InitialValue="0" ValidationGroup="Save"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Account Date / تاريخ الحساب</td>
                                <td class="validation">
                                    <telerik:RadDatePicker ID="txtDate" Runat="server" Width="90%">
                                    </telerik:RadDatePicker>
                                </td>
                                <td class="validation">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                        ControlToValidate="txtDate" ErrorMessage="*" ValidationGroup="Save"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="text-align: center">
                                    <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="Save" 
                                        Width="100px" onclick="btnSave_Click" />
                                    &nbsp;<asp:Button ID="btnClear" runat="server" Text="Clear" Width="100px" />
                                    &nbsp;<asp:Button ID="btnDelete" runat="server" style="color: #CC0000" Text="Delete" 
                                        Width="100px" Enabled="False" onclick="btnDelete_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="lblFeedBack" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style6">
                                    <asp:HiddenField ID="hfAccountId" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style6">
                                    <asp:ObjectDataSource ID="odsAccountType" runat="server" SelectMethod="View" 
                                        TypeName="BLL.Accounts.Account_Type">
                                        <SelectParameters>
                                            <asp:SessionParameter Name="CompId" SessionField="CompId" Type="Int32" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>

                        </table>
                    </asp:Panel>
                </td>
                <td width="50%">
                    <asp:Panel ID="Panel2" runat="server" Height="179px" style="color: #333333">
                        <div ID="divTree" style="height: 100%">
                            <telerik:RadTreeView ID="Tree" Runat="server" BackColor="#6C8BB4" 
                                BorderStyle="Groove" CssClass="Title" DataFieldID="AccountId" 
                                DataFieldParentID="UpperAccountId" DataSourceID="odsLevels" 
                                DataTextField="AccountName" DataValueField="AccountId" Font-Bold="True" 
                                Font-Italic="True" Font-Size="Medium" Font_Color="Black" ForeColor="White" 
                                Height="100%" onnodeclick="Tree_NodeClick" Skin="WebBlue" Width="90%">
                                <ExpandAnimation Duration="300" />
                                <CollapseAnimation Type="Linear" />
                            </telerik:RadTreeView>
                            <br />
                            <asp:ObjectDataSource ID="odsLevels" runat="server" SelectMethod="View" 
                                TypeName="BLL.Accounts.Accounts">
                                <SelectParameters>
                                    <asp:SessionParameter Name="CompId" SessionField="CompId" Type="Int32" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </div>
                    </asp:Panel>
                </td>
            </tr>
            <tr><td></td><td></td></tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
