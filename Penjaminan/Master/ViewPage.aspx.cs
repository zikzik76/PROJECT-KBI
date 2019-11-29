using Penjaminan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Penjaminan.Master
{
    public partial class ViewPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserProfile"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            lblMenu.Text = "Master Page";
            Session["activepage"] = "page";
            BindData();
        }

        private void BindData()
        {
            Models.PenjaminanViewDatasetTableAdapters.tPageTableAdapter ta = new Models.PenjaminanViewDatasetTableAdapters.tPageTableAdapter();

            Session["pageDt"] = (PenjaminanViewDataset.tPageDataTable)ta.GetData();
            //foreach (PenjaminanViewDataset.tPageRow dr in ((PenjaminanViewDataset.tPageDataTable)Session["pageDt"]).Rows)
            //{
            //    try
            //    {
            //        var x = dr.name;
            //        var y = dr.menuparentname;
            //    }
            //    catch(Exception ex)
            //    {

            //    }
                
            //}
            
        }
    }
}