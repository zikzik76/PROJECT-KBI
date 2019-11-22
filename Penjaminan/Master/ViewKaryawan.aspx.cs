using Penjaminan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Penjaminan.Master
{
    public partial class ViewKaryawan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserProfile"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            lblMenu.Text = "Master Karyawan";
            Session["activepage"] = "karyawan";
            BindData();
        }
        private void BindData()
        {
            Models.PenjaminanViewDatasetTableAdapters.KaryawanViewTableAdapter ta = new Models.PenjaminanViewDatasetTableAdapters.KaryawanViewTableAdapter();

            Session["karyawanDt"] = (PenjaminanViewDataset.KaryawanViewDataTable)ta.GetDataBy();
        }
    }
}