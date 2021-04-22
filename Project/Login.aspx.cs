using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Project
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                Response.Redirect("LoginSuccess.aspx");
            }
        }

        protected void RegisterRedirect_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            string Email = "";
            string Pass = "";
            string UserID2 = "";

            // declare SQLDataReader
            SqlDataReader readerOne;

            // declare SQLConnection
            SqlConnection connectionOne = new SqlConnection(SqlDataSource1.ConnectionString);

            // declare SQLCommand with command
            SqlCommand commandOne = new SqlCommand(SqlDataSource1.SelectCommand);

            // Defining the connection
            commandOne.Connection = connectionOne;


            // Define what values are sent to database
            commandOne.Parameters.AddWithValue("@Email", txtLogOne.Text.Trim());
            commandOne.Parameters.AddWithValue("@Password", txtPassLog.Text.Trim());

            // Open the connection to DB
            connectionOne.Open();

            // Execute and populate datareader with results of query
            readerOne = commandOne.ExecuteReader(CommandBehavior.CloseConnection);


            // Loop through values to assign variables for email and pass
            while (readerOne.Read())
            {
                // Assign UserID with index 0 (email)
                Email = readerOne.GetString(1).Trim();

                // Same but with password
                Pass = readerOne.GetString(2).Trim();

                // Create session variable with full name
                UserID2 = readerOne.GetString(3).Trim() + " "
                    + readerOne.GetString(4).Trim();
            }

            // Close the connection
            connectionOne.Close();

            if (txtLogOne.Text == Email && txtPassLog.Text == Pass)
            {
                Session["UserID"] = UserID2;
                Session["Email"] = Email;
                Response.Redirect("LoginSuccess.aspx");
            }
            else
            {
                lblLogError.Text = "Invalid User ID or Password";
            }
        }

        protected void ClearButton_Click(object sender, EventArgs e)
        {
            txtLogOne.Text = "";
            txtPassLog.Text = "";
            Session["UserID"] = null;
        }
    }
}
