using Penjaminan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Penjaminan.Master
{
    public partial class ViewWorkflow : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserProfile"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            lblMenu.Text = "Master Workflow";
            Session["activepage"] = "workflow";
            BindData();
        }

        private void BindData()
        {
            Models.PenjaminanDatasetTableAdapters.m_workflowTableAdapter ta = new Models.PenjaminanDatasetTableAdapters.m_workflowTableAdapter();

            Session["workflowDt"] = (PenjaminanDataset.m_workflowDataTable)ta.GetData();
        }
    }
}