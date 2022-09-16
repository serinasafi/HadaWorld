using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace HadaWorld.classes
{
   
public class connection
{
       public SqlConnection cn = new SqlConnection();
        //public string constr = "Data Source=SQL5055.site4now.net;Initial Catalog=DB_A4B358_dashboard;User ID=DB_A4B358_dashboard_admin;Password=pw_db_9d9ae0;";
        //public string constr = "Data Source=AAALP02;Initial Catalog=afserve;User Id=sa;Password=sa123;";
        public string constr = "Data Source=EDP-PC;Initial Catalog=HADA;User Id=sa;Password=sa123;";
        //public string constr = "Data Source=192.168.1.38;Initial Catalog=afserve;User Id=sa;Password=Aaa@2020mssql;";
        public connection()
        {
            cn.ConnectionString = constr;
            cn.Open();
        }
        public string PullYearMonth(string filename)
        {
            try
            {
                string[] st = filename.Split('_');
                string[] year = st[4].Split('.');
                string month = st[3];
                return year[0] + "\\" + month + "\\" + filename;
            }
            catch
            { return filename; }
        }
    }
}