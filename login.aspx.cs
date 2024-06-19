using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


namespace LifeGymWebsite
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter da;
        String e1, p1, q1, a1;

        protected void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        public void connection()
        {
            try
            {
                con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=life;Integrated Security=True");
                con.Close();
                con.Open();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.ToString() + "');</script>");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    e1 = txtEmail.Text;
                    p1 = txtPass.Text;
                    connection();


                    String enc = p1;


                    da = new SqlDataAdapter("select * from registration where emailid='" + e1 + "' and password='" + enc + "'", con);
                    dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        Session["loginid"] = e1;
                        Session["password"] = p1;

                        String type = dt.Rows[0][2].ToString();
                        if (type.Equals("admin"))
                        {
                            // Response.Write("<script>alert('Login success')</script>");

                            Response.Redirect("TrainerDetails.aspx");
                        }
                        else if (type.Equals("Member"))
                        {
                            Response.Redirect("memberProfile.aspx");

                        }
                        else
                        {
                            Response.Redirect("trainerprofile.aspx");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Login Failed')</script>");
                    }


                }
            }
            catch (Exception ex) { }
        }
    }
}