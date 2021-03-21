using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
namespace BookingSystem
{
    public partial class PastBooking : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Booking"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            gridfill1();
            gridfill2();
            gridfill3();
        }
        private void gridfill1()
        {
            SqlCommand cmdfill = new SqlCommand("Select * from ItemTable inner join BookingTable on ItemTable.ItemID=BookingTable.ItemId where StudentMailID=@mid and Status=1 order by StartTime", con);
            cmdfill.Parameters.AddWithValue("@mid", Session["Email"].ToString());
            SqlDataAdapter ad = new SqlDataAdapter(cmdfill);
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
                con.Open();
            ad.Fill(dt);
            con.Close();
            gdsuc.DataSource = dt;
            gdsuc.DataBind();
        }

        private void gridfill2()
        {
            SqlCommand cmdfill = new SqlCommand("Select * from ItemTable inner join BookingTable on ItemTable.ItemID=BookingTable.ItemId where StudentMailID=@mid and Status=0 order by StartTime", con);
            cmdfill.Parameters.AddWithValue("@mid", Session["Email"].ToString());
            SqlDataAdapter ad = new SqlDataAdapter(cmdfill);
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
                con.Open();
            ad.Fill(dt);
            con.Close();
            GridView2.DataSource = dt;
            GridView2.DataBind();
        }
        private void gridfill3()
        {
            SqlCommand cmdfill = new SqlCommand("Select * from ItemTable inner join BookingTable on ItemTable.ItemID=BookingTable.ItemId where StudentMailID=@mid and Status=2 order by StartTime", con);
            cmdfill.Parameters.AddWithValue("@mid", Session["Email"].ToString());
            SqlDataAdapter ad = new SqlDataAdapter(cmdfill);
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
                con.Open();
            ad.Fill(dt);
            con.Close();
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Student.aspx");
        }
    }
}