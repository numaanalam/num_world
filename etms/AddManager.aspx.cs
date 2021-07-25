﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace etms
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Numaan\Desktop\etms\etms\App_Data\etms.mdf;Integrated Security=True");
       
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void addmngrbtn_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("spAddUser", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@user_Id", SqlDbType.VarChar, 20).Value = TextBox1.Text.ToString();
            cmd.Parameters.Add("@user_Name", SqlDbType.VarChar, 20).Value = TextBox2.Text.ToString();
            cmd.Parameters.Add("@user_Address", SqlDbType.VarChar, 50).Value = TextBox3.Text.ToString();
            cmd.Parameters.Add("@user_PhoneNo", SqlDbType.VarChar, 20).Value = TextBox4.Text.ToString();
            cmd.Parameters.Add("@user_Email", SqlDbType.VarChar, 20).Value = TextBox5.Text.ToString();
            cmd.Parameters.Add("@user_Department", SqlDbType.VarChar, 20).Value = TextBox6.Text.ToString();
            cmd.Parameters.Add("@user_Role", SqlDbType.VarChar, 20).Value = "M";
            cmd.Parameters.Add("@user_Password", SqlDbType.VarChar, 20).Value = TextBox7.Text.ToString();

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Response.Write("registration done successfully");
            }
            catch (Exception ex)
            {
                Response.Write("input different user ID!");

            }
            finally
            {
                con.Close();
                con.Dispose();
            }
           
        }
    }
}