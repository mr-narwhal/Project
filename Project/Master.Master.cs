using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidateLogin();
        }

        private void ValidateLogin()
        {
            if (Session["UserID"] != null)
            {
                LoginLabel.Text = Session["UserID"].ToString().Split(' ')[0];
            }
            else
            {
                LoginLabel.Text = "     Login";
            }
        }
    }
}
