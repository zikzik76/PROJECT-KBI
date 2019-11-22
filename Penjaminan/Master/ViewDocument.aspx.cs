using Penjaminan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Penjaminan.Master
{
    public partial class ViewDocument : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserProfile"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            lblMenu.Text = "Master Dokumen";
            Session["activepage"] = "document";
            BindData();
        }

        private void BindData()
        {
            Models.PenjaminanViewDatasetTableAdapters.DocumentViewTableAdapter ta = new Models.PenjaminanViewDatasetTableAdapters.DocumentViewTableAdapter();

            Session["documentViewDt"] = (PenjaminanViewDataset.DocumentViewDataTable) ta.GetData();
        }
    }
}