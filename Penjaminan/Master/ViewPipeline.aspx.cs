using Penjaminan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Penjaminan.Master
{
    public partial class ViewPipeline : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserProfile"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            lblMenu.Text = "Master Pipeline";
            Session["activepage"] = "pipeline";
            BindData();
        }

        private void BindData()
        {
            Models.PenjaminanDatasetTableAdapters.m_pipelineTableAdapter ta = new Models.PenjaminanDatasetTableAdapters.m_pipelineTableAdapter();

            Session["pipelineDt"] = (PenjaminanDataset.m_pipelineDataTable)ta.GetData();
        }
    }
}