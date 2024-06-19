using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;

namespace LifeGymWebsite
{
    public partial class WebForm10 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!(Page.IsPostBack == true))
            {
                if (Session["loginid"] == null)
                {
                    Response.Redirect("AccessDenied.aspx");
                }

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Treport.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Mreport.aspx");
        }
    }
}