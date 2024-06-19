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
    public partial class WebForm16 : System.Web.UI.Page
    {
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
                Response.Write("<script>alert(" + ex.ToString() + ")</script>");

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
                        da = new SqlDataAdapter("select * from Member where Email='" + Session["loginid"] + "'", cn);
                        dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            lblsid.Text = dt.Rows[0]["Name"].ToString();
                            txtname.Text = dt.Rows[0]["Name"].ToString();
                            txtemail.Text = dt.Rows[0]["Email"].ToString();
                            lbladdress.Text = dt.Rows[0]["Address"].ToString();
                            lblcity.Text = dt.Rows[0]["City"].ToString();
                            lblstate.Text = dt.Rows[0]["State"].ToString();
                            lblland.Text = dt.Rows[0]["Landmark"].ToString();
                            lblMobile.Text = dt.Rows[0]["Mobile"].ToString();
                            Image1.ImageUrl = "~/images/Member/" + dt.Rows[0]["Id"].ToString() + ".jpg";
                        }


                    }

                }
                else
                {
                    Response.Redirect("AccessDenied.aspx");
                }
            }


            catch (Exception ex)
            {
                //Response.Redirect("404.aspx");
            }

        }
    }
}