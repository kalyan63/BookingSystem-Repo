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
    public partial class BookPage : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Booking"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                SqlCommand cmdname = new SqlCommand("Select ItemName from ItemTable Where ItemID=@id", con);
                cmdname.Parameters.AddWithValue("@id", Request.QueryString["Id"]);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                ItemName.Text = cmdname.ExecuteScalar().ToString();
                con.Close();
                gridfill();
            }
        }
        protected void btnbook(object sender,EventArgs e)
        {
            txtst.Text = Convert.ToDateTime(txtst.Text+" "+txtstm.Text).ToString();
            txtet.Text = Convert.ToDateTime(txtet.Text + " " + txtetm.Text).ToString();
            DateTime st = Convert.ToDateTime(txtst.Text);
            DateTime ed = Convert.ToDateTime(txtet.Text);
            if (DateTime.Compare(st,ed)>0)
            {
                err.Visible = true;
                err.Text = "Invalid start and end time";
                err.ForeColor = System.Drawing.Color.Red;
                txtst.Text = txtet.Text = txtreason.Text = "";
            }
            else
            {
                SqlCommand cmdchk = new SqlCommand("Select count(*) from BookingTable where @st< EndTime and @ed>StartTime and ItemID=@id", con);
                cmdchk.Parameters.AddWithValue("@st", st);
                cmdchk.Parameters.AddWithValue("@ed", ed);
                cmdchk.Parameters.AddWithValue("@id", Request.QueryString["Id"]);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                int chkbook = Convert.ToInt32(cmdchk.ExecuteScalar());
                con.Close();
                if (chkbook >= 1)
                {
                    err.Visible = true;
                    err.Text = "The Slot in already Booked, Please try other slot";
                    err.ForeColor = System.Drawing.Color.Red;
                    txtst.Text = txtet.Text = txtreason.Text = "";
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("Insert into BookingTable (ItemID,StudentMailID,StartTime,EndTime,Reason,Status) Values (@id,@mail,@st,@ed,@rs,@stat)", con);
                    cmd.Parameters.AddWithValue("@id", Request.QueryString["Id"]);
                    cmd.Parameters.AddWithValue("@mail", Session["Email"].ToString());
                    cmd.Parameters.AddWithValue("@st", st);
                    cmd.Parameters.AddWithValue("@ed", ed);
                    cmd.Parameters.AddWithValue("@rs", txtreason.Text);
                    cmd.Parameters.AddWithValue("@stat", 0);
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    err.Text = "Successfuly Booked the slot, Wait for confirmation mail.";
                    err.Visible = true;
                    err.ForeColor = System.Drawing.Color.Green;
                    txtst.Text = txtet.Text = txtreason.Text = "";
                }
            }
        }
        private void gridfill()
        {
            SqlCommand cmd = new SqlCommand("select * from BookingTable Where ItemID=@id order by StartTime", con);
            cmd.Parameters.AddWithValue("@id", Request.QueryString["Id"]);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
                con.Open();
            ad.Fill(dt);
            con.Close();
            gridBook.DataSource = dt;
            gridBook.DataBind();
        }
        protected void start(object sender, EventArgs e)
        { 
            txtst.Text = Calendar1.SelectedDate.ToShortDateString().ToString();
        }
        protected void end(object sender, EventArgs e)
        {
            txtet.Text = Calendar2.SelectedDate.ToShortDateString().ToString();
        }
    }
}