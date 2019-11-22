using Penjaminan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Penjaminan.Master
{
    public partial class ViewPerusahaan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserProfile"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            lblMenu.Text = "Master Perusahaan";
            Session["activepage"] = "perusahaan";
            BindData();
        }

        private void BindData()
        {
            Models.PenjaminanDatasetTableAdapters.m_perusahaanTableAdapter ta = new Models.PenjaminanDatasetTableAdapters.m_perusahaanTableAdapter();

            Session["perusahaanDt"] = (PenjaminanDataset.m_perusahaanDataTable)ta.GetData();
        }
    }
}