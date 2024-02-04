using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BusBookingSystem
{
    public partial class UserForgotPswrd : System.Web.UI.Page
    {
        // Connection string to the database
        string strconn = "Data Source=DESKTOP-LVRAQ1E;Initial Catalog=OnlineBusBookingDb;Integrated Security=True";

        // Page load event
        protected void Page_Load(object sender, EventArgs e)
        {
            // Empty, as there is no specific action on page load
        }

        // Button click event for updating password
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Establishing a connection to the database
                SqlConnection conn = new SqlConnection(strconn);
                conn.Open();

                // SQL command to update the password in the 'usersignup' table based on username and fullname
                SqlCommand cmd2 = new SqlCommand("update usersignup set pswrd='" + TextBox3.Text + "' where username='" + TextBox1.Text + "' and fullname='" + TextBox2.Text + "'", conn);

                // Executing the SQL command and getting the number of affected rows
                int ii = cmd2.ExecuteNonQuery();

                // Checking if the update operation was successful
                if (ii > 0)
                {
                    // Retrieving password and retype password from TextBoxes
                    string pswrd = TextBox3.Text;
                    string rpswrd = TextBox4.Text;

                    // Checking if the entered password and retype password match
                    if (pswrd == rpswrd)
                    {
                        // Closing the database connection
                        conn.Close();

                        // Displaying a success message
                        Response.Write("<script>alert('Password updated successfully !!!!');</script>");

                        // Clearing TextBoxes
                        TextBox1.Text = "";
                        TextBox2.Text = "";
                        TextBox3.Text = "";
                        TextBox4.Text = "";
                    }
                    else
                    {
                        // Displaying an error message if password and retype password do not match
                        Response.Write("<script>alert('Password and retype Password does not match!!!!');</script>");
                    }
                }
                else
                {
                    // Displaying an error message if the provided username and fullname do not match in the database
                    Response.Write("<script>alert('Full name and User id does not Match !!!!');</script>");
                }
            }
            catch (Exception exx)
            {
                // Handling and displaying any exception that might occur
                Response.Write("<script>alert('" + exx.Message + "');</script>");
            }
        }
    }
}
