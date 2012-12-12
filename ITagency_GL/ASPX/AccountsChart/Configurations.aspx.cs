using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace ITagency_GL.ASPX.AccountsChart
{
    public partial class Configurations : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void LoadSystemSettings(int centerID)
        {
            ddlCashAccounts.SelectedValue = "0";
            ddlSettlementsAccount.SelectedValue = "0";
            ddlBanksAccount.SelectedValue = "0";
            ddlTaxAccount.SelectedValue = "0";
            ddlDebitorsPAccount.SelectedValue = "0";
            ddlCreditorsPAccount.SelectedValue = "0";
            ddlLoansPAccount.SelectedValue = "0";

            ddlCurrency.SelectedValue = "0";
           
            lblFeedBack.Text = "";
            BLL.Profit_Center.Profit_Center ProfitProcess=new BLL.Profit_Center.Profit_Center ();

            DataTable dt = ProfitProcess.view(int.Parse(ddlProfitCenters.SelectedValue), int.Parse(Session["CompId"].ToString()));
            if (dt.Rows.Count == 1)
            {
                DataRow dr = dt.Rows[0];
                ddlCashAccounts.SelectedValue = dr["CashAccountID"].ToString();
                ddlBanksAccount.SelectedValue = dr["BankAccountID"].ToString();
                ddlSettlementsAccount.SelectedValue = dr["SettlementAccountID"].ToString();
                ddlTaxAccount.SelectedValue = dr["TaxVatAccount"].ToString();
                ddlDebitorsPAccount.SelectedValue = dr["DebitorsUpperAccountID"].ToString();
                ddlCreditorsPAccount.SelectedValue = dr["CreditorsUpperAccountID"].ToString();
                ddlLoansPAccount.SelectedValue = dr["LoansUpperAccountID"].ToString();

                ddlCurrency.SelectedValue = dr["DefaultCurrency"].ToString();

                txtVatValue.Text = decimal.Parse(dr["VatRatio"].ToString()).ToString("N1");

                //ddlPInvJType.SelectedValue = dr["PurchaseInvoiceJType"].ToString();
                //ddlSInvJType.SelectedValue = dr["SaleInvoiceJType"].ToString();
            }
            else
            {
                lblFeedBack.Text = "No Data";
                lblFeedBack.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void ddlProfitCenters_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadSystemSettings(int.Parse(ddlProfitCenters.SelectedValue));
            }
            catch (Exception ex)
            {
                lblFeedBack.Text= ex.Message;
                lblFeedBack.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                BLL.Accounts.Accounts tree = new BLL.Accounts.Accounts();
                bool accountsAreValid = tree.CheckAccountIsOpenNode(int.Parse(ddlCashAccounts.SelectedValue)) &
                                    tree.CheckAccountIsOpenNode(int.Parse(ddlSettlementsAccount.SelectedValue)) &
                                    tree.CheckAccountIsOpenNode(int.Parse(ddlBanksAccount.SelectedValue)) &
                                    tree.CheckAccountIsOpenNode(int.Parse(ddlTaxAccount.SelectedValue));

                bool upperAccountsAreValid = (tree.CheckAccountIsOpenUpper(int.Parse(ddlLoansPAccount.SelectedValue))) &
                                        (tree.CheckAccountIsOpenUpper(int.Parse(ddlCreditorsPAccount.SelectedValue))) &
                                        (tree.CheckAccountIsOpenUpper(int.Parse(ddlDebitorsPAccount.SelectedValue)));
                if (accountsAreValid && upperAccountsAreValid)
                {
                    BLL.Profit_Center.Profit_Center Profit_Process = new BLL.Profit_Center.Profit_Center();
                    Profit_Process.Insert(int.Parse(ddlCashAccounts.SelectedValue), int.Parse(ddlSettlementsAccount.SelectedValue), int.Parse(ddlCurrency.SelectedValue), int.Parse(ddlBanksAccount.SelectedValue),
                   int.Parse( ddlTaxAccount.SelectedValue), txtVatValue.Text, int.Parse(ddlDebitorsPAccount.SelectedValue),int.Parse( ddlCreditorsPAccount.SelectedValue),
                   int.Parse( ddlLoansPAccount.SelectedValue),int.Parse( ddlProfitCenters.SelectedValue), int.Parse(Session["CompId"].ToString()));
                    lblFeedBack.Text = Shared.Feedback.InsertSuccessfull();
                    lblFeedBack.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblFeedBack.Text = "أحد أو كل الحسابات المختارة قد يكون مغلقاً أو حساب غير فرعي، الرجاء اختيار حساب آخر!";
                    lblFeedBack.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblFeedBack.Text = ex.Message;
                lblFeedBack.ForeColor = System.Drawing.Color.Red;

            }

        }
    }
}