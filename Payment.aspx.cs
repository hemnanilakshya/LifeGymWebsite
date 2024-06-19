using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;

namespace LifeGymWebsite
{
    public partial class WebForm22 : System.Web.UI.Page
    {
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        SqlDataAdapter da1 = new SqlDataAdapter();
        DataTable dt1 = new DataTable();
        SqlCommand cmd = new SqlCommand();


        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        public void connection()
        {
            try
            {
                cn.Close();
                cn.Open();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.ToString() + "')</script>");

            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Page.IsPostBack == true))
            {
                connection();
                Ddlyear.Items.Clear();
                for (int i = 1; i <= 10; i++)
                {
                    Ddlyear.Items.Add((Convert.ToInt16(DateTime.Today.Year - 1) + i).ToString());
                }


                lblorderid.Text = Session["renewid"].ToString();

                lblcid.Text = Session["loginid"].ToString();
                lbltotalamt.Text = Session["total"].ToString();


            }
        }





        public void order_mail(String sender, String pass, String tos, String subject, String message)
        {
            try
            {
                NetworkCredential loginInfo = new NetworkCredential();
                loginInfo = new NetworkCredential(sender, pass);
                MailMessage msg = new MailMessage();
                msg = new MailMessage();
                msg.From = new MailAddress(sender);
                msg.To.Add(new MailAddress(tos));
                msg.Subject = subject;
                msg.Body = message;
                msg.IsBodyHtml = true;
                SmtpClient client = new SmtpClient();
                client = new SmtpClient("smtp.gmail.com");
                client.Port = 587;
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = loginInfo;
                client.Send(msg);

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Email Not Sent !!!' + '" + ex.ToString() + "')</script>");

            }
        }

        protected void btnbook_Click(object sender, ImageClickEventArgs e)
        {
            String month, year;
            month = DateTime.Now.Date.Month.ToString();
            year = DateTime.Now.Date.Year.ToString();

            if (((txtn1.Text.Length) + (txtn2.Text.Length) + (txtn3.Text.Length) + (txtn4.Text.Length)) < 16)
            {
                lblerror.Text = "Enter proper 16 digit Card Number.";

            }
            else
            {
                if (Convert.ToInt32(Ddlyear.Text) == Convert.ToInt32(year))
                {
                    if (Convert.ToInt32(Ddlmonth.Text) < Convert.ToInt32(month))
                    {
                        lblerror.Text = "Card is Invalid.";
                    }
                    else
                    {
                        lblerror.Text = "";
                    }
                }
                else
                {
                    lblerror.Text = "";
                }
            }
            if (lblerror.Text == "")
            {


                try
                {
                    cn.Open();
                }
                catch
                {
                    cn.Close();
                    cn.Open();
                }



                String str = "insert into payment values('" + lblorderid.Text + "','" + lblcid.Text + "','" + lbltotalamt.Text + "','" + DateTime.Today.Date.ToShortDateString() + "','" + DdlMode.Text + "','" + txtn1.Text + txtn2.Text + txtn3.Text + txtn4.Text + "','" + Ddlmonth.Text + "','" + Ddlyear.Text + "')";

                cmd = new SqlCommand(str, cn);
                cmd.CommandType = CommandType.Text;
                try
                {
                    cn.Close();
                    cn.Open();
                }
                catch (Exception ex) { }
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();


                order_mail("applefitness00@gmail.com", "bhavesh29", Session["loginid"].ToString(), "Renewal Payment", "Hello User<br>Thank you for staying with us by renewing membership.<br><br>Thanking You,<br>Team AFC");





                Response.Write("<script type=text/javascript>alert('Membership Renewed, For Details Check Your Mail Box') </script>");



                Response.Redirect("memberProfile.aspx");
            }
        }
    }
}