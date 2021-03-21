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
    public partial class Student : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Booking"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(Session["Email"]==null)
                {
                    Response.Redirect("WebForm1.aspx");
                }
                gridFill();
                checkInc();
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
        private void checkInc()
        {
            SqlCommand cmdchk = new SqlCommand("Select count(*) from ItemTable where InchargemailID=@mid", con);
            cmdchk.Parameters.AddWithValue("@mid", Session["Email"].ToString());
            if (con.State == ConnectionState.Closed)
                con.Open();
            int isinc =Convert.ToInt32( cmdchk.ExecuteScalar());
            con.Close();
            if(isinc>=1)
            {
                btnInc.Visible = true;
            }
        }
        protected void Book(object sender,EventArgs e)
        {
            string id = (sender as Button).CommandArgument;
            Response.Redirect("BookPage.aspx?Id=" + id);
        }
        protected void Past(object sender, EventArgs e)
        {
            Response.Redirect("PastBooking.aspx");
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

        protected void btnInc_Click(object sender, EventArgs e)
        {
            Response.Redirect("InchargePage.aspx");
        }
    }
}