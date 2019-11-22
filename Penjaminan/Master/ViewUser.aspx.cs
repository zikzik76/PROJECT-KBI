using Penjaminan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Penjaminan.Master
{
    public partial class ViewUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserProfile"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            lblMenu.Text = "Master User";
            Session["activepage"] = "user";
            BindData();
        }

        private void BindData()
        {
            Models.PenjaminanViewDatasetTableAdapters.UserProfileTableAdapter ta = new Models.PenjaminanViewDatasetTableAdapters.UserProfileTableAdapter();

            Session["userProfileDt"] = (PenjaminanViewDataset.UserProfileDataTable)ta.GetDataJoin();
        }
    }
}