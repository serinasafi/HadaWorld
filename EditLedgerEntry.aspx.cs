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
            if (!Page.IsPostBack)
            {
                BindGrid();
            }
        }

        protected void ddlHead_SelectedIndexChanged(object sender, EventArgs e)
        {

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
        protected void grdLedger_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                con = new connection();
                string traLedid = grdLedger.Rows[Convert.ToInt16(e.CommandArgument.ToString())].Cells[1].Text.Trim();
                
                if (e.CommandName == "Delete")
                {
                    
                }
               
                if (e.CommandName == "Change")
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
                        ddlHead.SelectedValue = r["transLedId"].ToString();
                        if(ddlHead.SelectedItem.Text.ToLower() == "sales")
                        {
                            pSales.Visible = true;
                            txtCustname.Text = r["custname"].ToString();
                            txtCustcompany.Text = r["custcompany"].ToString();
                            txtCustmobile.Text = r["custmobile"].ToString();
                            ddlCustcof.SelectedItem.Text = r["custcof"].ToString();
                            if(Convert.ToBoolean(r["custCompliment"])==true)
                            {
                                rdCompli.SelectedItem.Value = "Yes";
                            }
                            else
                                rdCompli.SelectedItem.Value = "No";
                            txtInvNo.Text = r["saleinvno"].ToString();
                        }
                        txtAmount.Text = r["transamount"].ToString();
                        txtDesc.Text = r["transdescription"].ToString();
                    }
                   

                }
            }
            catch (Exception ex) { message.Text = ex.Message; }
            finally
            { con.cn.Close(); }
        }
        protected void BindGrid()
        {
            try
            {
                cmd = new SqlCommand();
                cmd.Connection = con.cn;
                cmd.CommandText = "select * from LedgerEntries order by transid desc";
                adp = new SqlDataAdapter();
                adp.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    grdLedger.DataSource = dt.DefaultView;
                    grdLedger.DataBind();
                }
            }
            catch(Exception ex)
            { }
            finally { }

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {                
                cmd.Connection = con.cn;
                string sql = "select * from LedgerEntries where transdate >= '" + Convert.ToDateTime(txtFrom.Text).ToString("yyyy-MM-dd") + "' and transdate<='" + Convert.ToDateTime(txtTo.Text).ToString("yyyy-MM-dd") + "'";
                cmd.CommandText = sql;
                adp.SelectCommand = cmd;
                adp.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    grdLedger.DataSource = ds.Tables[0].DefaultView;
                    grdLedger.DataBind();
                }
            }
            catch (Exception ex)
            {
                message.Text = "Error Occured : " + ex.Message;
            }
            finally { con.cn.Close(); }
        }
    }
}