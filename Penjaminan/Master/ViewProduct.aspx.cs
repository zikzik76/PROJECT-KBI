using Penjaminan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Penjaminan.Master
{
    public partial class ViewProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserProfile"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            lblMenu.Text = "Master Product";
            Session["activepage"] = "product";
            BindData();
        }

        private void BindData()
        {
            Models.PenjaminanDatasetTableAdapters.m_productTableAdapter ta = new Models.PenjaminanDatasetTableAdapters.m_productTableAdapter();

            Session["productDt"] = (PenjaminanDataset.m_productDataTable)ta.GetData();
        }
    }
}