using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookingSystem
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["type"] == null)
                {
                    Response.Redirect("WebForm1.aspx");
                }
            }
        }

        protected void BtnAdd(object sender, EventArgs e)
        {
            Response.Redirect("AddItem.aspx");
        }
        protected void BtnEdit(object sender, EventArgs e)
        {
            Response.Redirect("EditItem.aspx");
        }
        protected void Btnbook(object sender, EventArgs e)
        {
            Response.Redirect("BookAdmin.aspx");
        }
    }
}