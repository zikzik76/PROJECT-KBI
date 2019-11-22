using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Penjaminan
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["UserProfile"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            Session["activepage"] = "dashboard";
        }
    }
}