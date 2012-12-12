using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
namespace ITagency_GL.ASPX.Reports.TrialBalance
{
    public partial class ViewTrialBalance1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["dtTrialBalanceReport"] != null) //&& reportType > 0)
                {
                   // string financialPeriodName = Shared.GetFinancialPeriodName();

                    DataTable dt = (DataTable)Session["dtTrialBalanceReport"];
                    string rptFullPath = Server.MapPath("rptTrialBalance.rpt");
                    ReportDocument rpt = new ReportDocument();
                    
                    rpt.Load(rptFullPath);
                    rpt.SetDataSource(dt);
                   
                    TextObject txtTitle2 = (TextObject)rpt.ReportDefinition.ReportObjects["txtFinancialPeriodName"];
                    txtTitle2.Text = "2011";

                    rpt.Refresh();

                    MemoryStream memStream = (MemoryStream)rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);

                    Response.Clear();
                    Response.Buffer = true;
                    Response.ContentType = "application/pdf";
                    Response.BinaryWrite(memStream.ToArray());
                    Response.End();

                    memStream.Dispose();
                }
                else
                    Response.Redirect("TrialBalance.aspx", false);

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                Session.Remove("dtTrialBalanceReport");
            }
        }
    }
}