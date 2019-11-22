using Penjaminan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Penjaminan
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Value == null || txtUsername.Value == "")
            {
                throw new ApplicationException("field username is mandatory");
            }

            if (txtPassword.Value == null || txtPassword.Value == "")
            {
                throw new ApplicationException("field password is mandatory");
            }

            if(txtUsername.Value != null && txtUsername.Value != "")
            {
                PenjaminanDataset.UserProfileRow dr = UserProfile.getUserLogin(txtUsername.Value, txtPassword.Value);

                if(dr != null)
                {
                    if(dr.password == txtPassword.Value)
                    {
                        Session["UserProfile"] = dr;
                        Response.Redirect("/Dashboard.aspx");
                    }
                }
                else
                {
                    throw new ApplicationException("Username and Password not found");
                }
            }
        }
    }
}