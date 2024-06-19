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

namespace LifeGymWebsite
{
    public partial class WebForm21 : System.Web.UI.Page
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

            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachement;filename=Trainers.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            GridView1.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.End();
            GridView1.AllowPaging = true;
            GridView1.DataBind();

        }
        public override void VerifyRenderingInServerForm(Control control)
        {

        }
    }
}


