<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AssetsDefining.aspx.cs" Inherits="ITagency_GL.ASPX.Assets.AssetsDefining" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="mainTable">
                <tr>
                    <td colspan="2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td width="20%">
                        Asset name / <span ID="result_box" class="short_text" lang="ar">
                        <span class="hps">اسم</span> <span class="hps">الأصول</span></span></td>
                    <td width="80%">
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Code / الرمز</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        Account / الحساب</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        purchasing price/ سعر الشراء</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <span ID="result_box0" class="short_text" lang="en"><span class="">Date of 
                        purchase / تاريخ الشراء</span></span></td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <span ID="result_box1" class="short_text" lang="en"><span class="">Depreciation</span>
                        <span class="hps">rate / نسبة الاهلاك</span></span></td>
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
                        &nbsp;</td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
