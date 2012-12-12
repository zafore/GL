using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ITagency_GL.ASPX.Reports
{
    public partial class Trial : System.Web.UI.Page
    {
        BLL.Accounts.AccountingTree tree = new BLL.Accounts.AccountingTree();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnView_Click(object sender, EventArgs e)
        {
             try
             {

                 decimal accountBalance = 0;
                 lblFeedBack.Text = "";



                 DataTable dtTrialBalanceReport = new DataTable();

                 dtTrialBalanceReport.Columns.Add(new DataColumn("AccountFullName", typeof(string)));
                 dtTrialBalanceReport.Columns.Add(new DataColumn("Debit", typeof(decimal)));
                 dtTrialBalanceReport.Columns.Add(new DataColumn("Credit", typeof(decimal)));

                 DataTable dt = tree.Account(int.Parse(ddlProfitCenters.SelectedValue), int.Parse(Session["CompId"].ToString()));
                 if (dt.Rows.Count == 0)
                 {
                     lblFeedBack.Text = "No Data";
                     lblFeedBack.ForeColor = System.Drawing.Color.Red;
                 }
                 else
                 {
                     foreach (DataRow dr in dt.Rows)
                     {
                         if (bool.Parse(dr["IsAsset"].ToString()) || bool.Parse(dr["IsExpenses"].ToString()))
                         {
                             accountBalance = tree.GetAccountBalance(int.Parse(dr["AccountID"].ToString()), txtFrom.SelectedDate.ToString(),
                                 txtTo.SelectedDate.ToString(), false, int.Parse(ddlProfitCenters.SelectedValue), ddlFinancialPeriod.SelectedValue);

                             dtTrialBalanceReport.Rows.Add(dr["AccountName"], accountBalance, 0); //, "إيرادات"); // debit -- منه  = credit -debit
                         }
                         else if (bool.Parse(dr["IsLiablty"].ToString()) || bool.Parse(dr["IsRevenue"].ToString()))
                         {
                             accountBalance = tree.GetAccountBalance(int.Parse(dr["AccountID"].ToString()), txtFrom.SelectedDate.ToString(),
                                 txtTo.SelectedDate.ToString(), true, int.Parse(ddlProfitCenters.SelectedValue), ddlFinancialPeriod.SelectedValue);

                             dtTrialBalanceReport.Rows.Add(dr["AccountName"], 0, accountBalance); //, "منصرفات"); // credit -- له = debit - credit (as ususal)
                         }


                     }

                     Session["dtTrialBalanceReport"] = dtTrialBalanceReport;

                     string url = "../Reports/TrialBalance/ViewTrialBalance.aspx";

                     ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ViewTrialBalance", "window.open('" + url + "', '_new')", true);
                   //  Response.Redirect("~/aspx/Reports/TrialBalance/ViewTrialBalance.aspx");
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