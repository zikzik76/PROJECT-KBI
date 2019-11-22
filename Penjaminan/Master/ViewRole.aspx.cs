using Penjaminan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Penjaminan.Master
{
    public partial class ViewRole : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserProfile"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            lblMenu.Text = "Master Role";
            Session["activepage"] = "role";
            BindData();
        }

        private void BindData()
        {
            Models.PenjaminanDatasetTableAdapters.u_roleTableAdapter ta = new Models.PenjaminanDatasetTableAdapters.u_roleTableAdapter();

            Session["roleDt"] = (PenjaminanDataset.u_roleDataTable)ta.GetData();
        }
    }
}