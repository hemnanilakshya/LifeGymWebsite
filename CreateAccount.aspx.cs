using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Data;


namespace LifeGymWebsite
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        SqlDataAdapter da1 = new SqlDataAdapter();
        DataTable dt1 = new DataTable();
        String sq, sa, email;
        SqlCommand cmd = new SqlCommand();
        int i = 0;
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

                    if (Session["loginid"] == null)
                    {
                        Response.Redirect("AccessDenied.aspx");
                    }
                    else
                    {

                    }
            }
            catch (Exception ex)
            {
                //Response.Redirect("404.aspx");
            }

        }

        private void getdata()
        {
            try
            {
                ddlName.Items.Clear();
                ddlName.Items.Add("--Select--");

                if (ddlType.SelectedIndex == 1)
                {
                    da = new SqlDataAdapter("select Email from Member", cn);
                    dt = new DataTable();
                    da.Fill(dt);
                }
                if (ddlType.SelectedIndex == 2)
                {
                    da = new SqlDataAdapter("select Email from Trainer", cn);
                    dt = new DataTable();
                    da.Fill(dt);
                }


                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    ddlName.Items.Add(dt.Rows[i][0].ToString());
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error LN:93 CreateAccount')</script>");
            }
        }

        private void clearAll()
        {


            ddlName.Items.Clear();
        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            da1 = new SqlDataAdapter("select * from Registration where emailid='" + ddlName.Text + "'", cn);
            dt1 = new DataTable();
            da1.Fill(dt1);
            try
            {
                String a = dt1.Rows[0][0].ToString();
                Response.Write("<script>alert('Account with same email id already exist! ')</script>");
                ddlName.Items.Clear();
                ddlType.SelectedIndex = 0;


            }
            catch (Exception ex)
            {

                if (ddlType.SelectedIndex == 1)
                {
                    da = new SqlDataAdapter("select Name,Mobile from Member where Email='" + ddlName.Text + "'", cn);
                    dt = new DataTable();
                    da.Fill(dt);
                }
                if (ddlType.SelectedIndex == 2)
                {
                    da = new SqlDataAdapter("select Name,Mobile from Trainer where Email='" + ddlName.Text + "'", cn);
                    dt = new DataTable();
                    da.Fill(dt);
                }



                cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cn.Open();
                cmd.Connection = cn;

                
                cmd.CommandText = "insert into registration values('" + ddlName.Text + "','" + dt.Rows[0][1].ToString() + "','" + ddlType.Text + "')";

                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Account Created Successfully!!!')</script>");
                ddlName.Items.Clear();
                getdata();
            }


        }

        

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlName.Items.Clear();

            getdata();
        }
        protected void ddlName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void btnDelete_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cn.Open();
                cmd.Connection = cn;

                cmd.CommandText = "delete from registration where emailid='" + ddlName.Text + "'";

                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Account Deleted Successfully!!!')</script>");
                ddlName.Items.Clear();
                getdata();
            }
            catch { }

        }
    }

}