using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace LifeGymWebsite
{
    public partial class WebForm6 : System.Web.UI.Page
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

                    else
                    {
                        /*Response.Redirect("404.aspx");*/
                    }
                    Image1.ImageUrl = "~/images/nopic.jpg";
                }



            }
            catch (Exception ex)
            {
                //Response.Redirect("404.aspx");
            }

        }

        protected void getdata()
        {
            da = new SqlDataAdapter("select * from Member", cn);
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
            txtemail.Text = "";
            DropDownListdept.SelectedIndex = 0;
            txtadd.Text = "";
            txtcity.Text = "";
            txtState.Text = "";
            txtLandmark.Text = "";
            txtMobile.Text = "";

            Image1.ImageUrl = "~/images/nopic.jpg";

        }
        public void disable()
        {
            txtname.Enabled = false;

            txtemail.Enabled = false;
            DropDownListdept.Enabled = false;
            txtadd.Enabled = false;
            txtcity.Enabled = false;
            txtState.Enabled = false;
            txtLandmark.Enabled = false;
            txtMobile.Enabled = false;
            FileUpload1.Enabled = false;
        }
        public void enable()
        {

            txtname.Enabled = true;

            txtemail.Enabled = true;

            DropDownListdept.Enabled = true;
            txtadd.Enabled = true;
            txtcity.Enabled = true;
            txtState.Enabled = true;
            txtLandmark.Enabled = true;
            txtMobile.Enabled = true;
            FileUpload1.Enabled = true;
        }
        protected void display()
        {
            lblid.Text = dt.Rows[0]["Id"].ToString();
            txtname.Text = dt.Rows[0]["Name"].ToString();

            txtemail.Text = dt.Rows[0]["Email"].ToString();

            DropDownListdept.Text = dt.Rows[0]["Gender"].ToString();
            txtadd.Text = dt.Rows[0]["Address"].ToString();
            txtcity.Text = dt.Rows[0]["City"].ToString();
            txtState.Text = dt.Rows[0]["State"].ToString();
            txtLandmark.Text = dt.Rows[0]["Landmark"].ToString();
            txtMobile.Text = dt.Rows[0]["Mobile"].ToString();

            Image1.ImageUrl = "~/images/Member/" + dt.Rows[0]["Id"].ToString() + ".jpg";

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
            txtemail.Enabled = false;
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

                    checkit();


                    //send mail code




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
                    cmd.CommandText = "update Member set  Name='" + txtname.Text + "',Email='" + txtemail.Text + "',Gender='" + DropDownListdept.Text + "',Mobile='" + txtMobile.Text + "',Address='" + txtadd.Text + "',City='" + txtcity.Text + "',State='" + txtState.Text + "',Landmark='" + txtLandmark.Text + "' where Id='" + lblid.Text + "' ";
                    cmd.ExecuteNonQuery();
                    if (FileUpload1.FileName != "")
                    {
                        FileUpload1.SaveAs(Server.MapPath("~") + "/images/Member/" + lblid.Text + ".jpg");
                        Image1.ImageUrl = "~/images/Member/" + lblid.Text + ".jpg";
                    }
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
                cmd.CommandText = "Delete from Member where Id='" + lblid.Text + "' ";
                cmd.ExecuteNonQuery();
                String s;
                s = "s" + lblid.Text;
                try
                {
                    cmd.CommandText = "Delete from registration where emailid='" + txtemail.Text + "'";
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                }

                Response.Write("<script>alert('Removed Successfully') </script>");
                cmd = null;

                clearAll();

                disable();
                gridfill();

                da = new SqlDataAdapter("select * from Member where Email='" + txtemail.Text + "'", cn);
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
        public void checkit()
        {
            da = new SqlDataAdapter("select * from Registration where emailid='" + txtemail.Text + "'", cn);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count == 0)
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cn.Open();
                cmd.Connection = cn;


                cmd.CommandText = "insert into Member values('" + lblid.Text + "','" + txtname.Text + "','" + txtemail.Text + "','" + DropDownListdept.Text + "','" + txtadd.Text + "','" + txtcity.Text + "','" + txtState.Text + "','" + txtLandmark.Text + "','" + txtMobile.Text + "')";
                cmd.ExecuteNonQuery();
                if (FileUpload1.FileName != "")
                {
                    FileUpload1.SaveAs(Server.MapPath("~") + "/images/Member/" + Session["count"].ToString() + ".jpg");
                    Image1.ImageUrl = "~/images/Member/" + Session["count"].ToString() + ".jpg";
                }
                String s;
                s = "s" + lblid.Text;
                Response.Write("<script>alert('Saved Successfully') </script>");
                cmd = null;

            }
            else
            {
                Response.Write("<script>alert('Email-Id Already Present') </script>");
                cmd = null;
            }

        }
        
        public void gridfill()
        {
            String sqlq = "select Name,Email,Gender from Member";
            da = new SqlDataAdapter(sqlq, cn);
            dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            i = GridView1.SelectedRow.Cells[2].Text;

            try
            {
                da = new SqlDataAdapter("select * from Member where Email='" + i + "' ", cn);
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
        protected void txtemail_TextChanged(object sender, EventArgs e)
        {

        }
    }

}

