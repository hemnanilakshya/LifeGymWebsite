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
    public partial class WebForm18 : System.Web.UI.Page
    {
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        SqlCommand cmd = new SqlCommand();
        int count = 0;
        String i;

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

                        ddlmember.Items.Add(Session["loginid"].ToString());



                    }


                }
            }
            catch (Exception ex)
            {
                //Response.Redirect("404.aspx");
            }


        }

        protected void ddlmonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {


                da = new SqlDataAdapter("select * from dietchart where month='" + ddlmonth.Text + "' and year='" + ddlyear.Text + "' and emailid='" + ddlmember.Text + "'", cn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    txtmonday.Text = dt.Rows[0][0].ToString();
                    txttue.Text = dt.Rows[0][1].ToString();
                    txtwed.Text = dt.Rows[0][2].ToString();
                    txtthu.Text = dt.Rows[0][3].ToString();
                    txtfri.Text = dt.Rows[0][4].ToString();
                    txtsat.Text = dt.Rows[0][5].ToString();
                    txtsun.Text = dt.Rows[0][6].ToString();

                }
                else
                {
                    txtmonday.Text = "";
                    txttue.Text = "";
                    txtwed.Text = "";
                    txtthu.Text = "";
                    txtfri.Text = "";
                    txtsat.Text = "";
                    txtsun.Text = "";

                }




            }
            catch { }
        }
    }
}