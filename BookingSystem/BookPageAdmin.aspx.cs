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
using System.Net.Mail;
namespace BookingSystem
{
    public partial class BookPageAdmin : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Booking"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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
        private void gridfill()
        {
            SqlCommand cmd = new SqlCommand("Select * from BookingTable where ItemID=@id and Status=1", con);
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
        protected void start(object sender,EventArgs e)
        {
            DateTime st = Calendar1.SelectedDate;
            SqlCommand cmd = new SqlCommand("Select * from BookingTable where Cast(@st as Date)>=Cast(StartTime as Date) and Cast(@st as Date)<=Cast(EndTime as Date) and ItemID=@id and Status=1", con);
            cmd.Parameters.AddWithValue("@st",st);
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
        private string Getid(long id)
        {
            SqlCommand cmd = new SqlCommand("Select StudentMailID from BookingTable where BookID=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            if (con.State == ConnectionState.Closed)
                con.Open();
            string mailid = cmd.ExecuteScalar().ToString();
            con.Close();
            return mailid;
        }
        protected void Reject(object sender, EventArgs e)
        {
            string id = (sender as Button).CommandArgument;
            StringBuilder msgbody = new StringBuilder();
            msgbody.Append("Hi ");
            msgbody.Append("<br><br>");
            msgbody.Append("Your Booking is Rejected.");
            msgbody.Append("Reason for Rejection: <br>");
            msgbody.Append(txtReason.Text);
            msgbody.Append("<br><br>");
            msgbody.Append("Please visit the Booking Page to view Status");
            Mail(Getid(Convert.ToInt64(id)), msgbody);
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE BookingTable set Status=2,RejectReason=@rs where BookID=@id", con);
            cmd.Parameters.AddWithValue("@id", Convert.ToInt64(id));
            cmd.Parameters.AddWithValue("@rs", txtReason.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            gridfill();
        }

        private void Mail(string to_address, StringBuilder msgbody)
        {
            MailMessage msg = new MailMessage("fundum31@gmail.com", to_address);
            msg.IsBodyHtml = true;
            msg.Body = msgbody.ToString();
            msg.Subject = "Room Booking";
            SmtpClient clnt = new SmtpClient("smtp.gmail.com", 587);
            clnt.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "fundum31@gmail.com",
                Password = "dummy@20@itsfun"
            };
            clnt.EnableSsl = true;
            clnt.Send(msg);
        }

    }
}