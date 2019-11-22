using Penjaminan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Penjaminan.Master
{
    public partial class ViewBidangUsaha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserProfile"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            lblMenu.Text = "Master Bidang Usaha";
            Session["activepage"] = "bidangusaha";
            BindData();
        }

        private void BindData()
        {
            Models.PenjaminanDatasetTableAdapters.m_bidangusahaTableAdapter ta = new Models.PenjaminanDatasetTableAdapters.m_bidangusahaTableAdapter();

            Session["bidangusahaDt"] = (PenjaminanDataset.m_bidangusahaDataTable)ta.GetData();
        }
    }
}