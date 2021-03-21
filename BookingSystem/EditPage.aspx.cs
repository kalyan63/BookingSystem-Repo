using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
namespace BookingSystem
{
    public partial class EditPage : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Booking"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                SqlCommand cmd = new SqlCommand("Select * from ItemTable where ItemID=@id", con);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(Request.QueryString["Id"]));
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                txtName.Text = dr["ItemName"].ToString();
                txtType.Items.FindByValue(dr["ItemType"].ToString()).Selected = true;
                txtBtype.Items.FindByValue(Convert.ToInt32 (dr["BookingType"]).ToString()).Selected = true;
                txtIncharge.Text = dr["InchargemailID"].ToString();
                txtLocation.Text = dr["Location"].ToString();
                con.Close();
            }
        }
        protected void btnSubmit(object sender, EventArgs e)
        {
            SqlCommand cmditem = new SqlCommand("Update ItemTable set  ItemName=@nm,ItemType=@ty,BookingType=@bt,InchargemailID=@ic,Location=@loc Where ItemID=@id", con);
            cmditem.Parameters.AddWithValue("@nm", txtName.Text);
            cmditem.Parameters.AddWithValue("@ty", txtType.SelectedValue);
            cmditem.Parameters.AddWithValue("@bt", Convert.ToByte(txtBtype.SelectedValue));
            if (txtIncharge.Text == "")
                cmditem.Parameters.AddWithValue("@ic", DBNull.Value);
            else
                cmditem.Parameters.AddWithValue("@ic", txtIncharge.Text);
            cmditem.Parameters.AddWithValue("@loc", txtLocation.Text);
            cmditem.Parameters.AddWithValue("@id", Convert.ToInt32(Request.QueryString["Id"]));
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmditem.ExecuteNonQuery();
            con.Close();
            txterror.Visible = true;
            txtName.Text = txtBtype.Text = txtIncharge.Text = txtLocation.Text = "";
        }

        protected void btnRemove(object sender,EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Delete from ItemTable where ItemID=@id", con);
            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(Request.QueryString["Id"]));
            SqlCommand cmd2 = new SqlCommand("Update BookingTable set Status=2,RejectReason=@rs where ItemID=@id and Status=1", con);
            cmd2.Parameters.AddWithValue("@id", Convert.ToInt32(Request.QueryString["Id"]));
            cmd2.Parameters.AddWithValue("@rs", txtrsn.Text);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            con.Close();
            Response.Redirect("EditItem.aspx");
        }
    }
}