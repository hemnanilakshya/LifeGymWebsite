using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace LifeGymWebsite
{
    public partial class WebForm20 : System.Web.UI.Page
    {
        String pwd, passwd;
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
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
                Response.Write("<script>alert('Error in connection')<'/'script>");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!(Page.IsPostBack == true))
                {
                    if (Session["loginid"] == null)
                    {
                        Response.Redirect("AccessDenied.aspx");
                    }
                    else
                    {
                        connection();
                        try
                        {
                            da = new SqlDataAdapter("select Password from registration where emailid='" + Session["loginid"] + "'", cn);
                            dt = new DataTable();
                            da.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                Session["pwd"] = dt.Rows[0]["Password"].ToString();
                            }
                            else
                            {
                            }
                        }
                        catch (Exception ex)
                        {
                        }
                    }

                }

                else
                {
                    //Response.Redirect("404.aspx");
                }
            }
            catch (Exception ex)
            {
                //Response.Redirect("404.aspx");
            }

        }
        protected void CVPass_ServerValidate(object source, ServerValidateEventArgs args)
        {
            {
                string str = txtNewPass.Text;
                if (str.Length < 6)
                {
                    args.IsValid = false;
                }
                else
                {
                    args.IsValid = true;
                }
            }
        }
        protected void ImgChangePass_Click(object sender, ImageClickEventArgs e)
        {
            if (Page.IsValid == true)
            {
                passwd = txtOldPass.Text;
                if (passwd.Equals(Session["pwd"].ToString()))
                {
                    lblerror.Text = "";
                    cmd = new SqlCommand();
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    cmd.Connection = cn;




                    cmd.CommandText = "update registration set Password='" + txtNewPass.Text + "' where emailid='" + Session["loginid"] + "'";
                    cmd.ExecuteNonQuery();
                    Response.Write("<script>alert('Updated Successfully') </script>");
                    cmd = null;

                }
                else
                {
                    lblerror.Text = "Old password does not match. Please enter it again.";
                    txtOldPass.Text = "";
                    txtOldPass.Focus();
                }

            }

        }

    }
}