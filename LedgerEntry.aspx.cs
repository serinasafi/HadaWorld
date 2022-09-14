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
                cmd.Parameters.AddWithValue("@transDate", txtDate.Text);//UAE.ToString("dd/MM/yyyy hh:mm:ss tt")
                cmd.Parameters.AddWithValue("@transAmount", txtAmount.Text);
                cmd.Parameters.AddWithValue("@transLedid", ddlHead.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@transDescription", txtDesc.Text);
                cmd.Parameters.AddWithValue("@transType", dr["ledType"].ToString());
                int stat = 0;
                stat = int.Parse(cmd.ExecuteScalar().ToString());
                if (stat > 0)
                {
                    message.Text = "Ledger Entries Added";
                    if(ddlHead.SelectedItem.Value.Trim()=="3")//Sales
                    {
                        cmd = new SqlCommand("CreateCustomerSales", con.cn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        
                        cmd.Parameters.AddWithValue("@custName", txtCustname.Text);
                        cmd.Parameters.AddWithValue("@custCompany", txtCustcompany.Text);
                        cmd.Parameters.AddWithValue("@custcof", ddlCustcof.Text);
                        cmd.Parameters.AddWithValue("@custMobile", txtCustmobile.Text);
                        cmd.Parameters.AddWithValue("@custCompliment", rdCompli.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("@custProductid",ddlProduct.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("@saleDate", UAE.ToString("yyyy/MM/dd hh:mm:ss tt"));
                        cmd.Parameters.AddWithValue("@saleTransid", stat);
                        cmd.Parameters.AddWithValue("@saleTransAmount", txtAmount.Text);
                        cmd.Parameters.AddWithValue("@saleinvno", txtInvNo.Text);
                        cmd.Parameters.AddWithValue("@saleStatus", "Invoiced");
                        int stat1 = cmd.ExecuteNonQuery();
                        ClearFields();                        
                        grdLedger.DataBind();  
                        
                    }
                }
            }
            catch (Exception ex)
            {
                message.Text = "Error Occured : " + ex.Message;
            }
            finally { con.cn.Close(); }
        }
        protected void ClearFields()
        {
            ddlHead.SelectedIndex = 0;
            txtAmount.Text = "";
            txtDesc.Text = "";
            ddlProduct.SelectedIndex = 0;
            txtCustcompany.Text ="";
            txtCustmobile.Text = "";
            txtCustname.Text = "";
            txtInvNo.Text = "";
            rdCompli.SelectedIndex = 0;
            message.Text = "";
        }
        protected void ddlHead_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearFields();
            if (ddlHead.SelectedItem.Text == "Sales")
                pSales.Visible = true;
            else
                pSales.Visible = false;
        }

        protected void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {              
                cmd.Connection = con.cn;
                string sql = "select * from products where prodid =" + ddlProduct.SelectedItem.Value;
                cmd.CommandText = sql;
                adp.SelectCommand = cmd;
                adp.Fill(ds);
                DataRow dr = ds.Tables[0].Rows[0];
                txtAmount.Text = dr["prodPrice"].ToString();
            }
            catch (Exception ex)
            {
                message.Text = "Error Occured : " + ex.Message;
            }
            finally { con.cn.Close(); }
        }
    }
}