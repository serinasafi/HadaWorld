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
    public partial class LedgerEntry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                connection con = new connection();
                SqlCommand cmd = new SqlCommand();
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                cmd.Connection = con.cn;
                string sql = "select * from LedgerHead where ledgerid =" + ddlHead.SelectedItem.Value;
                cmd.CommandText = sql;
                adp.SelectCommand = cmd;
                adp.Fill(ds);
                DataRow dr = ds.Tables[0].Rows[0];

                cmd = new SqlCommand("CreateLedgerEntry", con.cn);
                cmd.CommandType = CommandType.StoredProcedure;
                TimeZoneInfo UAETimeZone = TimeZoneInfo.FindSystemTimeZoneById("Arabian Standard Time"); DateTime utc = Convert.ToDateTime(txtDate.Text).ToUniversalTime();
                DateTime UAE = TimeZoneInfo.ConvertTimeFromUtc(utc, UAETimeZone);
                cmd.Parameters.AddWithValue("@transDate", UAE.ToString("dd/MM/yyyy hh:mm:ss tt"));
                cmd.Parameters.AddWithValue("@transAmount", txtAmount.Text);
                cmd.Parameters.AddWithValue("@transLedid", ddlHead.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@transDescription", txtDesc.Text);
                cmd.Parameters.AddWithValue("@transType", dr["ledType"].ToString());
                int stat = int.Parse(cmd.ExecuteScalar().ToString());
                if (stat > 0)
                {
                    message.Text = "Ledger Entries Added";
                }
                if(pSales.Visible == true)
                {

                }
            }
            catch (Exception ex)
            {
                message.Text = "Error Occured : " + ex.Message;
            }
            finally { }
        }

        protected void ddlProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            try 
            { 
                connection con = new connection();
                SqlCommand cmd = new SqlCommand();
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                cmd.Connection = con.cn;
                string sql = "select * from products where prodid =" + ddlProducts.SelectedItem.Value;
                cmd.CommandText = sql;
                adp.SelectCommand = cmd;
                adp.Fill(ds);
                DataRow dr = ds.Tables[0].Rows[0];
                txtAmount.Text = dr["prodPrice"].ToString();
                Session["amount"] = dr["prodPrice"].ToString();
            }
            catch (Exception ex)
            {
                message.Text = "Error Occured : " + ex.Message;
            }
            finally { }
        }

        protected void rdCompliment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdCompliment.SelectedItem.Value == "Yes")
            {
                txtAmount.Text = ""; txtInvNo.Enabled = false;
            }
            else
                txtInvNo.Enabled = true; txtAmount.Text = Session["amount"].ToString();
        }

        protected void ddlHead_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlHead.SelectedItem.Value == "Sales")
            {
                pSales.Visible = true;
            }
            else
                pSales.Visible = false;
        }
    }
}