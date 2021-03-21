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
    public partial class AddItem : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Booking"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit(object sender, EventArgs e)
        {
            SqlCommand cmditem = new SqlCommand("Insert into ItemTable (ItemName,ItemType,BookingType,InchargemailID,Location) Values (@nm,@ty,@bt,@ic,@loc)", con);
            cmditem.Parameters.AddWithValue("@nm",txtName.Text);
            cmditem.Parameters.AddWithValue("@ty",txtType.SelectedValue);
            cmditem.Parameters.AddWithValue("@bt",Convert.ToByte(txtBtype.SelectedValue));
            if(txtIncharge.Text=="")
                cmditem.Parameters.AddWithValue("@ic",DBNull.Value);
            else
                cmditem.Parameters.AddWithValue("@ic",txtIncharge.Text);
            cmditem.Parameters.AddWithValue("@loc",txtLocation.Text);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmditem.ExecuteNonQuery();
            con.Close();
            txterror.Visible = true;
            txtName.Text = txtBtype.Text = txtIncharge.Text = txtLocation.Text = "";
        }
    }
}