using Penjaminan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Penjaminan.Master
{
    public partial class ViewAccess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UserProfile"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            lblMenu.Text = "Master Access";
            Session["activepage"] = "Access";
            BindData();
        }

        private void BindData()
        {
            Models.PenjaminanViewDatasetTableAdapters.AccessTableAdapter ta = new Models.PenjaminanViewDatasetTableAdapters.AccessTableAdapter();

            Session["AccessDt"] = (PenjaminanViewDataset.AccessDataTable)ta.GetData();
        }
    }
}