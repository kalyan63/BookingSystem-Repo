using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookingSystem
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BtnAdmin(object sender,EventArgs e)
        {
            Session["type"] = "Admin";
            Response.Redirect("AddItem.aspx");
        }

        protected void BtnLogin(object sender,EventArgs e)
        {
            Session["type"] = "Student";
            Session["Sid"] = txtID.Text;
            Session["Email"] = txtEmail.Text;
            Response.Redirect("Student.aspx");
        }
    }
}