using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace LifeGymWebsite
{
    public partial class WebForm13 : System.Web.UI.Page
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
                if (Session["loginid"] == null)
                {
                    Response.Redirect("AccessDenied.aspx");
                }
                else

                {
                    connection();
                    da = new SqlDataAdapter("select Name,Gender,City,Mobile from member where email in (select emailid from renew where tname in (select Name from trainer where Email='" + Session["loginid"].ToString() + "')) ", cn);
                    dt = new DataTable();
                    da.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}