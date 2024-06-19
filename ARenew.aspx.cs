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
    public partial class WebForm17 : System.Web.UI.Page
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

        public void fillpackage()
        {
            try
            {
                da = new SqlDataAdapter("select * from membership", cn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    ddlpackage.Items.Clear();
                    ddlpackage.Items.Add("Select");

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ddlpackage.Items.Add(dt.Rows[i][1].ToString());
                    }

                }

            }
            catch { }
        }
        public void filltrainer()
        {
            try
            {
                da = new SqlDataAdapter("select * from trainer", cn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    ddltrainer.Items.Clear();
                    ddltrainer.Items.Add("Select");

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ddltrainer.Items.Add(dt.Rows[i][1].ToString());
                    }

                }

            }
            catch { }
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

                        clearAll();


                        getdata();
                        autogenerate();
                        lblid.Text = Session["count"].ToString();
                        fillpackage();
                        filltrainer();

                        txtemail.Text = Session["loginid"].ToString();



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
        protected void getdata()
        {
            da = new SqlDataAdapter("select * from renew", cn);
            dt = new DataTable();
            da.Fill(dt);
        }

        private void autogenerate()
        {
            int a = 0;
            getdata();
            Session["count"] = dt.Rows.Count;
            if (a.Equals(Session["count"]))
            {
                Session["count"] = 1;
            }
            else
            {
                Session["count"] = (int)Session["count"] + 1;
            }

            da = null;
            dt = null;
        }

        public void clearAll()
        {


            lblid.Text = "";
            txtemail.Text = "";
            ddlpackage.SelectedIndex = 0;
            txtduration.Text = "";
            ddltrainer.SelectedIndex = 0;
            txttotal.Text = "";
            txtemail.Text = "";


        }

        public void check()
        {
            try
            {
                connection();
                da = new SqlDataAdapter("select * from renew where todate>'" + DateTime.Now + "' and emailid='" + Session["loginid"].ToString() + "'", cn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Session["ren"] = "1";
                }
                else
                {
                    Session["ren"] = "0";
                }
            }
            catch { }
        }

        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                connection();
                String sql = "";
                String chk = "1";
                check();
                if (Session["ren"].ToString().Equals(chk))
                {
                    Response.Write("<script>alert('Already Renewed')</script>");
                }
                else
                {
                    sql = "insert into renew values('" + lblid.Text + "','" + ddlpackage.Text + "','" + DateTime.Now.AddMonths(Convert.ToInt32(txtduration.Text)) + "','" + ddltrainer.Text + "','" + txttotal.Text + "','" + txtemail.Text + "')";
                    cmd = new SqlCommand(sql, cn);
                    cmd.ExecuteNonQuery();
                    Session["renewid"] = lblid.Text;
                    Session["total"] = txttotal.Text;
                    Response.Redirect("Payment.aspx");
                    //


                }
            }
            catch (Exception ed) { }
        }

        protected void ddlpackage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                connection();

                da = new SqlDataAdapter("select * from membership where name='" + ddlpackage.Text + "'", cn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    txtduration.Text = dt.Rows[0][2].ToString();
                    txttotal.Text = dt.Rows[0][3].ToString();

                }
                else
                {
                    txtduration.Text = "";
                    txttotal.Text = "";

                }

            }
            catch { }
        }

        protected void ddltrainer_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                connection();

                da = new SqlDataAdapter("select * from trainer where Name='" + ddltrainer.Text + "'", cn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int total = 0;
                    total = Convert.ToInt32(txttotal.Text);
                    total = total + Convert.ToInt32(dt.Rows[0][9].ToString());
                    txttotal.Text = total + "";
                }
                else
                {
                    da = new SqlDataAdapter("select * from membership where name='" + ddlpackage.Text + "'", cn);
                    dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        txttotal.Text = dt.Rows[0][3].ToString();

                    }
                }

            }
            catch { }
        }
    }
}