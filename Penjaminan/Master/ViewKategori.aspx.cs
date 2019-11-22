using Penjaminan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Penjaminan.Master
{
    public partial class ViewKategori : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserProfile"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            lblMenu.Text = "Master Kategori";
            Session["activepage"] = "kategori";
            BindData();
        }

        private void BindData()
        {
            Models.PenjaminanDatasetTableAdapters.m_kategoriTableAdapter ta = new Models.PenjaminanDatasetTableAdapters.m_kategoriTableAdapter();

            Session["kategoriDt"] = (PenjaminanDataset.m_kategoriDataTable)ta.GetData();
        }
    }
}