﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BusBookingSystem
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        string strconn = "Data Source=DESKTOP-LVRAQ1E;Initial Catalog = OnlineBusBookingDb;Integrated Security = True";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconn);
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from adminlogin where username ='" + TextBox1.Text + "' and pswrd='" + TextBox2.Text + "';", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();

                if (dr.HasRows)
                {                             
                    Response.Redirect("AdminHomePage.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Invalid login details. Please check again.');</script>");
                }
                conn.Close();

            }
            catch (Exception exx)
            {
                Response.Write("<script>alert('" + exx.Message + "');</script>");

            }
        }

    }
}

          
        
    
