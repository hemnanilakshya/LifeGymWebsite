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
    public partial class WebForm9 : System.Web.UI.Page
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

                        clearAll();

                        disable();

                        btnNew.Enabled = true;
                        btnSave.Enabled = false;
                        btnCancel.Enabled = false;
                        btnModify.Enabled = false;
                        btnRemove.Enabled = false;

                        getdata();
                        if (dt.Rows.Count > 0)
                        {
                            gridfill();
                        }

                    }

                }

                else
                {

                }

            }
            catch (Exception ex)
            {

            }

        }

        protected void getdata()
        {
            da = new SqlDataAdapter("select * from Membership", cn);
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

            txtname.Text = "";
            lblid.Text = "";

            txtMobile.Text = "";
            txtcost.Text = "";


        }
        public void disable()
        {
            txtname.Enabled = false;

            txtcost.Enabled = false;
            txtMobile.Enabled = false;
        }
        public void enable()
        {

            txtname.Enabled = true;


            txtMobile.Enabled = true;
            txtcost.Enabled = true;
        }
        protected void display()
        {
            lblid.Text = dt.Rows[0]["id"].ToString();
            txtname.Text = dt.Rows[0]["name"].ToString();


            txtMobile.Text = dt.Rows[0]["duration"].ToString();
            txtcost.Text = dt.Rows[0]["cost"].ToString();


        }


        protected void btnNew_Click(object sender, ImageClickEventArgs e)
        {
            enable();
            Session["save_code"] = "true";
            autogenerate();
            lblid.Text = Session["count"].ToString();
            btnNew.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            btnModify.Enabled = false;
            btnRemove.Enabled = false;


        }
        protected void btnModify_Click(object sender, ImageClickEventArgs e)
        {
            enable();
            Session["save_code"] = "false";

            btnNew.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            btnModify.Enabled = false;
            btnRemove.Enabled = false;


        }
        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {
            if (Page.IsValid == true)
            {
                String t = "true";
                //image

                //code for new record

                if (t.Equals(Session["save_code"].ToString()))
                {




                    cmd = new SqlCommand();
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    cmd.Connection = cn;
                    cmd.CommandText = "insert into membership values('" + lblid.Text + "','" + txtname.Text + "','" + txtMobile.Text + "','" + txtcost.Text + "') ";
                    cmd.ExecuteNonQuery();

                    Response.Write("<script>alert('Added Successfully') </script>");
                    cmd = null;


                    clearAll();
                    disable();
                    gridfill();
                    btnNew.Enabled = true;
                    btnModify.Enabled = false;
                    btnSave.Enabled = false;
                    btnRemove.Enabled = false;
                    btnCancel.Enabled = false;
                }
                else
                {

                    //code for modify i.e. update.
                    cmd = new SqlCommand();
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    cmd.Connection = cn;
                    cmd.CommandText = "update membership set  name='" + txtname.Text + "',duration='" + txtMobile.Text + "',cost='" + txtcost.Text + "' where id='" + lblid.Text + "' ";
                    cmd.ExecuteNonQuery();

                    Response.Write("<script>alert('Updated Successfully') </script>");
                    cmd = null;

                    clearAll();
                    disable();
                    gridfill();
                    btnNew.Enabled = true;
                    btnModify.Enabled = false;
                    btnSave.Enabled = false;
                    btnRemove.Enabled = false;
                    btnCancel.Enabled = false;
                }
            }
        }
        protected void btnRemove_Click(object sender, ImageClickEventArgs e)
        {
            if (lblid.Text != "")
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cn.Open();
                cmd.Connection = cn;
                cmd.CommandText = "Delete from membership where id='" + lblid.Text + "' ";
                cmd.ExecuteNonQuery();

                Response.Write("<script>alert('Removed Successfully') </script>");
                cmd = null;

                clearAll();

                disable();
                gridfill();

                da = new SqlDataAdapter("select * from membership where id='" + lblid.Text + "'", cn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    btnNew.Enabled = true;
                    btnModify.Enabled = false;
                    btnSave.Enabled = false;
                    btnRemove.Enabled = false;
                    btnCancel.Enabled = false;
                }
                else
                {
                    btnNew.Enabled = true;
                    btnModify.Enabled = true;
                    btnSave.Enabled = false;
                    btnRemove.Enabled = true;
                    btnCancel.Enabled = false;
                }
            }

        }
        protected void btnCancel_Click(object sender, ImageClickEventArgs e)
        {
            disable();
            clearAll();
            Session["save_code"] = "";
            btnNew.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            btnModify.Enabled = false;
            btnRemove.Enabled = false;

        }



        public void gridfill()
        {
            String sqlq = "select * from membership";
            da = new SqlDataAdapter(sqlq, cn);
            dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            i = GridView1.SelectedRow.Cells[1].Text;

            try
            {
                da = new SqlDataAdapter("select * from membership where id='" + i + "' ", cn);
                dt = new DataTable();
                da.Fill(dt);
                display();
                btnNew.Enabled = false;
                btnModify.Enabled = true;
                btnSave.Enabled = false;
                btnRemove.Enabled = true;
                btnCancel.Enabled = true;
            }
            catch (Exception ex)
            {

            }


        }

    }

}
