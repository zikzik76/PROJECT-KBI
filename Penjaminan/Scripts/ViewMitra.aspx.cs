using Penjaminan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Penjaminan.Penjaminan
{
    public partial class ViewMitra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //reset objek dan session yg ada

            if (Session["UserProfile"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            lblMenu.Text = "Master Mitra";
            Session["activepage"] = "mitra";

            Session.Remove("tBidangUsahaList");
            Session.Remove("tWorkDoneList");
            Session.Remove("tWorkProgressList");
            Session.Remove("tPicList");
            Session.Remove("tPemegangSahamList");
            Session.Remove("tBodList");

            BindData();
        }

        private void BindData()
        {
            string tModule = "mitra";
            int tUrutan = 0;
            int tSequen = 0;
            var user = (PenjaminanDataset.UserProfileRow)Session["UserProfile"];
            tUrutan = Convert.ToInt32(user.role);
            if(tUrutan - 1 != 0)
            {
                tSequen = tUrutan - 1;
            }
            else
            {
                tSequen = tUrutan;
            }

            Models.PenjaminanDatasetTableAdapters.m_mitraTableAdapter ta = new Models.PenjaminanDatasetTableAdapters.m_mitraTableAdapter();

            ////set condition
            //Models.PenjaminanDatasetTableAdapters.m_workflowTableAdapter tax = new Models.PenjaminanDatasetTableAdapters.m_workflowTableAdapter();
            //Models.PenjaminanDatasetTableAdapters.t_workflowTableAdapter taY = new Models.PenjaminanDatasetTableAdapters.t_workflowTableAdapter();

            //PenjaminanDataset.m_workflowDataTable dtX = tax.GetDataTwf(tSequen, tModule);
            
            
            Session["mitraDt"] = (PenjaminanDataset.m_mitraDataTable)ta.GetDataFLoad();
           

           
            //foreach(PenjaminanDataset.m_mitraRow dr in ((PenjaminanDataset.m_mitraDataTable)Session["mitraDT"]).Rows)
            //{
            //    var status = dr.statusMitra;
            //}
        }
    }
}