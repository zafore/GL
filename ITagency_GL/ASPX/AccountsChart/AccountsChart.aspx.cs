using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shared;

namespace ITagency_GL.ASPX.AccountsChart
{
    public partial class AccountsChart : System.Web.UI.Page
    {
        BLL.Accounts.Accounts AccountProcess = new BLL.Accounts.Accounts();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void Clear()
        {
            txtDate.SelectedDate = null;
            
            txtAccName.Text = "";
            ddlAccountType.SelectedIndex = -1;
            Tree.DataBind();
            hfAccountId.Value = "";



        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                AccountProcess.Insert_New_Account(txtAccName.Text, txtDate.SelectedDate.Value.ToString(), int.Parse("1"), int.Parse("1"), int.Parse("1"), int.Parse(ddlAccountType.SelectedValue.ToString()), int.Parse(Session["UserId"].ToString()), int.Parse(Session["CompId"].ToString()), System.DateTime.Today.ToString(),hfAccountId.Value.ToString());
                lblFeedBack.Text = Feedback.InsertSuccessfull();
                lblFeedBack.ForeColor = System.Drawing.Color.Green;
                Clear();

            }
            catch (Exception ex)
            {
                lblFeedBack.Text = ex.Message;
                lblFeedBack.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void Tree_NodeClick(object sender, Telerik.Web.UI.RadTreeNodeEventArgs e)
        {
            try
            {
                hfAccountId.Value = Tree.SelectedValue.ToString();
                btnDelete.Enabled = true;

            }
            catch (Exception ex)
            {
                lblFeedBack.Text = ex.Message;
                lblFeedBack.ForeColor = System.Drawing.Color.Red;

            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (hfAccountId.Value != "")
                {
                    if (AccountProcess.Delete(int.Parse(hfAccountId.Value)))
                    {
                        lblFeedBack.Text = Feedback.DeleteSuccessfull();
                        lblFeedBack.ForeColor = System.Drawing.Color.Green;
                        Clear();
                    }
                    else
                    {
                        lblFeedBack.Text = "Plz Delete Sub Account first";
                        lblFeedBack.ForeColor = System.Drawing.Color.Red;

                    }
                }
                else
                {

                    lblFeedBack.Text = "Plz Select Account from Tree";
                    lblFeedBack.ForeColor = System.Drawing.Color.Red;
                }
                

            }
            catch (Exception ex)
            {
                lblFeedBack.Text = ex.Message+"Plz Delete Sub Account first";
                lblFeedBack.ForeColor = System.Drawing.Color.Red;
            }
        }

       
    }
}