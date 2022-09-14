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
    
    public partial class EditLedgerEntry : System.Web.UI.Page
    {
        connection con = new connection();
        SqlCommand cmd = new SqlCommand();
        DataSet ds = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ddlHead_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grdLedger_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                con = new connection();
                string traLedid = grdLedger.Rows[Convert.ToInt16(e.CommandArgument.ToString())].Cells[1].Text.Trim();
                
                if (e.CommandName == "Delete")
                {
                    
                }
               
                if (e.CommandName == "Edit")
                {

                    cmd = new SqlCommand();
                    cmd.Connection = con.cn;
                    cmd.CommandText = "select * from vi_editledger where transid="+ traLedid;                   
                    adp = new SqlDataAdapter();
                    adp.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        DataRow r = dt.Rows[0];
                        txtDate.Text = Convert.ToDateTime(r["transDate"]).ToString("dd/MM/yyyy");
                        ddlHead.SelectedItem.Value = r["transLedId"].ToString();
                        if(ddlHead.SelectedItem.Text == "sales")
                        {
                            pSales.Visible = true;

                        }
                    }
                   

                }
            }
            catch (Exception ex) { message.Text = ex.Message; }
            finally
            { con.cn.Close(); }
        }
    }
}