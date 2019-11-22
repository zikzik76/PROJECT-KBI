using Penjaminan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Penjaminan.Master
{
    public partial class ViewDivisi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserProfile"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            lblMenu.Text = "Master Divisi";
            Session["activepage"] = "divisi";
            BindData();
        }
        private void BindData()
        {
            Models.PenjaminanDatasetTableAdapters.DivisiTableAdapter ta = new Models.PenjaminanDatasetTableAdapters.DivisiTableAdapter();

            Session["divisiDt"] = (PenjaminanDataset.DivisiDataTable)ta.GetData();
        }
    }
}