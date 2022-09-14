using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HadaWorld.classes;
using System.Data.SqlClient;
using System.Data;
namespace HadaWorld
{
    public partial class ShowLedgers : System.Web.UI.Page
    {
        connection con = new connection();
        SqlCommand cmd = new SqlCommand();
        DataSet ds = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                double sum = 0;
                cmd.Connection = con.cn;
                string sql = "select * from vi_LedgerEntries where transledid =" + ddlLedger.SelectedItem.Value + " and transdate >= '" + Convert.ToDateTime(txtFrom.Text).ToString("yyyy-MM-dd") + "' and transdate<='" + Convert.ToDateTime(txtTo.Text).ToString("yyyy-MM-dd") + "'";
                cmd.CommandText = sql;
                adp.SelectCommand = cmd;
                adp.Fill(ds);
                if(ds.Tables[0].Rows.Count>0)
                {                    
                    foreach(DataRow r in ds.Tables[0].Rows)
                    {
                        sum += Convert.ToDouble(r["transAmount"]);
                    }                    
                }
                grdLedger.DataSource = ds.Tables[0].DefaultView;
                grdLedger.DataBind();
                lblTotal.Text = sum.ToString();
            }
            catch (Exception ex)
            {
                message.Text = "Error Occured : " + ex.Message;
            }
            finally { con.cn.Close(); }
        }
    }
}