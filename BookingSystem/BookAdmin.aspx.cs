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
    public partial class BookAdmin : System.Web.UI.Page
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
            if (con.State == ConnectionState.Closed)
                con.Open();
            ad.Fill(dt);
            Items.DataSource = dt;
            Items.DataBind();
            con.Close();
        }
        protected void Book(object sender, EventArgs e)
        {
            string id = (sender as Button).CommandArgument;
            Response.Redirect("BookPageAdmin.aspx?Id=" + id);
        }
        protected void gridSelect(object sender, EventArgs e)
        {
            string type = txtType.SelectedValue;
            SqlCommand cmdgrid = new SqlCommand("Select * from ItemTable where ItemType=@it", con);
            cmdgrid.Parameters.AddWithValue("@it", type);
            SqlDataAdapter ad = new SqlDataAdapter(cmdgrid);
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
                con.Open();
            ad.Fill(dt);
            Items.DataSource = dt;
            Items.DataBind();
            con.Close();
        }
    }
}