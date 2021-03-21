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
    public partial class InchargePage : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Booking"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                gridfill();
            }
        }

        private void gridfill()
        {
            SqlCommand cmdfill = new SqlCommand("Select * from ItemTable inner join BookingTable on ItemTable.ItemID=BookingTable.ItemId where InchargemailID=@mid and Status=0", con);
            cmdfill.Parameters.AddWithValue("@mid", Session["Email"].ToString());
            SqlDataAdapter ad = new SqlDataAdapter(cmdfill);
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
                con.Open();
            ad.Fill(dt);
            con.Close();
            gdReq.DataSource = dt;
            gdReq.DataBind();
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

        protected void Accept(object sender, EventArgs e)
        {
            string id = (sender as Button).CommandArgument;
            StringBuilder msgbody = new StringBuilder();
            msgbody.Append("Hi ");
            msgbody.Append("<br><br>");
            msgbody.Append("Your Booking is Accepted.");
            msgbody.Append("<br><br>");
            msgbody.Append("Please visit the Booking Page to view Status");
            Mail(Getid(Convert.ToInt64(id)), msgbody);
            SqlCommand cmd = new SqlCommand("UPDATE BookingTable set Status=1 where BookID=@id", con);
            cmd.Parameters.AddWithValue("@id", Convert.ToInt64(id));
            if (con.State == ConnectionState.Closed)
                    con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            gridfill();
        }
        protected void Reject(object sender, EventArgs e)
        {
            string id = (sender as Button).CommandArgument;
            StringBuilder msgbody = new StringBuilder();
            msgbody.Append("Hi " );
            msgbody.Append("<br><br>");
            msgbody.Append("Your Booking is Rejected.");
            msgbody.Append("<br><br>");
            msgbody.Append("Reason for Rejection: <br>");
            msgbody.Append(txtReason.Text);
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