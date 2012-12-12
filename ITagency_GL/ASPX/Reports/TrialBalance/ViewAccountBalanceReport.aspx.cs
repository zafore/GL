using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

public partial class ASPX_Reports_ViewAccountBalanceReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["dtAccountBalance"] != null) //&& reportType > 0)
            {
                DataTable dt = (DataTable)Session["dtAccountBalance"];
                string rptFullPath = Server.MapPath("rptAccountsBalances.rpt");
                ReportDocument rpt = new ReportDocument();

                rpt.Load(rptFullPath);
                rpt.SetDataSource(dt);
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
                Response.Redirect("AccountBalance.aspx", false);

        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
        finally
        {
            Session.Remove("dtAccountBalance");
        }
    }

}
