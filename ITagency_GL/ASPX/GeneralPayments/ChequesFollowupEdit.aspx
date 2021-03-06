﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChequesFollowupEdit.aspx.cs" Inherits="ITagency_GL.ASPX.GeneralPayments.ChequesFollowupEdit" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="mainTable">
                <tr>
                    <td class="title" colspan="2">
                        Cheques Followup&nbsp; / متابعة الشيكات</td>
                </tr>
                <tr>
                    <td width="20%">
                        Check Type / نوع الشيك</td>
                    <td width="80%">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        Check No. / الرقم</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <span ID="result_box" class="short_text" lang="en"><span class="">Entitled</span>
                        <span class="hps">to / معنون إلى</span></span></td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        Bank Name / اسم البنك
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlBanks" runat="server" AppendDataBoundItems="True" 
                            DataSourceID="odsBanks" DataTextField="BankName" DataValueField="BankID" 
                            Width="120px">
                            <asp:ListItem Selected="True" Value="0">اختيار</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <span ID="result_box0" class="short_text" lang="en"><span class="">Date</span>
                        <span class="hps">of collection / تاريخ التحصيل</span></span></td>
                    <td>
                        <telerik:RadDatePicker ID="txtDueDate" Runat="server" Width="20%">
                        </telerik:RadDatePicker>
                    </td>
                </tr>
                <tr>
                    <td>
                        <span ID="result_box1" class="short_text" lang="en"><span class="">Amount / 
                        المبلغ</span></span></td>
                    <td>
                        <asp:TextBox ID="txtAmount" runat="server">0</asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <span ID="result_box2" class="short_text" lang="en"><span class="">Currency / 
                        العملة</span></span></td>
                    <td>
                        <asp:DropDownList ID="ddlCurrencies" runat="server" AppendDataBoundItems="True" 
                            AutoPostBack="True" DataSourceID="sdsCurrencies" DataTextField="CurrencyNameAr" 
                            DataValueField="CurrencyId" OnDataBound="ddlCurrencies_DataBound" 
                            OnSelectedIndexChanged="ddlCurrencies_SelectedIndexChanged" Width="160px">
                            <asp:ListItem Selected="True" Text="اختيار" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <span ID="result_box3" class="short_text" lang="en"><span class="">Conversion 
                        rate / سعر التحويل</span></span></td>
                    <td>
                        <asp:Label ID="lblExchangeRate" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <span ID="result_box4" class="short_text" lang="en"><span class="">Details / 
                        تفاصيل</span></span></td>
                    <td>
                        <asp:TextBox ID="txtDescription" runat="server" BorderStyle="None" 
                            Height="39px" TextMode="MultiLine" Width="530px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <asp:ObjectDataSource ID="odsBanks" runat="server" SelectMethod="View" 
                            TypeName="BLL.Banks.Banks">
                            <SelectParameters>
                                <asp:SessionParameter Name="CompId" SessionField="CompId" Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
