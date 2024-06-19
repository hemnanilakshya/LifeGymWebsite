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
    public partial class WebForm14 : System.Web.UI.Page
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

                        da = new SqlDataAdapter("select distinct emailid from renew where tname in (select Name from trainer where Email='" + Session["loginid"].ToString() + "')", cn);
                        dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            ddlmember.Items.Clear();
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                ddlmember.Items.Add(dt.Rows[i][0].ToString());
                            }
                        }



                    }

                }


            }
            catch (Exception ex)
            {
                //Response.Redirect("404.aspx");
            }

        }

        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                connection();

                da = new SqlDataAdapter("select * from dietchart where month='" + ddlmonth.Text + "' and year='" + ddlyear.Text + "' and emailid='" + ddlmember.Text + "' and temailid='" + Session["loginid"].ToString() + "'", cn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Response.Write("<script>alert('Already Added for this user,same month,same year')</script>");
                }
                else
                {
                    cmd = new SqlCommand("insert into dietchart values('" + txtmonday.Text + "','" + txttue.Text + "','" + txtwed.Text + "','" + txtthu.Text + "','" + txtfri.Text + "','" + txtsat.Text + "','" + txtsun.Text + "','" + ddlmonth.Text + "','" + ddlyear.Text + "','" + ddlmember.Text + "','" + Session["loginid"].ToString() + "')", cn);
                    cmd.ExecuteNonQuery();
                    Response.Redirect("trainerprofile.aspx");
                }
            }
            catch { }
        }

        protected void ddlmonth_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}