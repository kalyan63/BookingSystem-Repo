using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace BookingSystem
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Booking"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                gridFill();
            }
        }
        private void gridFill()
        {
            SqlCommand cmdgrid = new SqlCommand("Select * from ItemTable", con);
            SqlDataAdapter ad = new SqlDataAdapter(cmdgrid);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            Items.DataSource = dt;
            Items.DataBind();
        }

        protected void edit(object sender,EventArgs e)
        {
            string id = (sender as Button).CommandArgument;
            Response.Redirect("EditPage.aspx?Id=" + id);
        }
    }
}