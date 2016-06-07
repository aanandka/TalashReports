using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data;
using MySql.Data.MySqlClient;
using CrystalDecisions.CrystalReports.Engine;
using System.Configuration;
using System.Data;

namespace TalashReports
{
    public partial class MissingDetails : System.Web.UI.Page
    {
        
        protected void CrystalReportViewer1_Init(object sender, EventArgs e)
        {
            MySqlConnection con = null;
            MySqlDataAdapter da = null;
            DataSet ds = null;
            ReportDocument rpt = null;

            con = new MySqlConnection(ConfigurationManager.ConnectionStrings["TalashConnection"].ConnectionString);
            da = new MySqlDataAdapter("Select * from MissingPersonDetail ", con);
            ds = new DataSet();
            da.Fill(ds);
            rpt = new ReportDocument();

            rpt.Load(Server.MapPath("MissingDetailsReport.rpt"));
            rpt.SetDataSource(ds.Tables[0]);
            rpt.SetDatabaseLogon("root", "Nerd@9257", "10.23.72.174", "talash");

            CrystalReportViewer1.ReportSource = rpt;
            CrystalReportViewer1.DataBind();

        }
    }
}