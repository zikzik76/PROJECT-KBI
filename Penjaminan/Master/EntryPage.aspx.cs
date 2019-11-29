using Penjaminan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Penjaminan.Master
{
    public partial class EntryPage : System.Web.UI.Page
    {
        int ValueList = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!Page.IsPostBack)
            {
                populateBidangUsaha();

                if (Session["UserProfile"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }
                if (eType == "add")
                {

                }
                else if (eType == "edit")
                {
                    //listmenuparent.ClearSelection();                    
                    ////updateListBidangUsaha(eID);
                    bindData();
                }
                else if (eType == "delete")
                {
                    softDeleteData(eID);
                }
            }

            lblMenu.Text = "Entry Master Page";
            Session["activepage"] = "page";
        }

        private void bindData()
        {
            PenjaminanDataset.tPageRow dr = tPage.selectPageByID(eID);
            txtName.Value = dr.name;
            txtControl.Value = dr.control;
            txtIcon.Value = dr.icon;
            txtActive.Value = dr.active;
            ValueList = dr.menuparent;
            listmenuparent.SelectedValue = ValueList.ToString();
        }

        private void softDeleteData(int id)
        {
            tPage.SoftDeleteData(id);
            Response.Redirect("/Master/ViewPage.aspx");
        }

        protected void uiBtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Master/ViewPage.aspx");
        }
        protected void populateBidangUsaha()
        {
            Models.PenjaminanViewDatasetTableAdapters.tPageTableAdapter ta = new Models.PenjaminanViewDatasetTableAdapters.tPageTableAdapter();

            listmenuparent.DataSource = ta.GetDataforParent();
            listmenuparent.DataTextField = "menuparentname";
            listmenuparent.DataValueField = "id";
            listmenuparent.DataBind();
        }

        protected void btnSubmit_click(object sender, EventArgs e)
        {
            
            try
            {
                if (eID != 0 && IsValidEntry())
                {
                    tPage.UpdateData(eID, txtName.Value, txtControl.Value, txtIcon.Value, txtActive.Value, Convert.ToInt32(listmenuparent.SelectedValue));
                }
                else if (eID == 0 && IsValidEntry())
                {
                    tPage.InsertData(txtName.Value, txtControl.Value,txtIcon.Value,txtActive.Value,Convert.ToInt32(listmenuparent.SelectedValue));
                }
                Response.Redirect("/Master/ViewPage.aspx");
            }
            catch (Exception ex)
            {
                //uiBLError.Items.Add(ex.Message);
                //uiBLError.Visible = true;
            }
        }
        protected void itemSelectedPage(object sender, EventArgs e)
        {

            PenjaminanDataset.tPageRow dr = tPage.SelectByName(listmenuparent.SelectedItem.Text);
            ValueList = dr.menuparent;

            //string message = PageList.SelectedItem.Text + " - " + PageList.SelectedItem.Value;
            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + message + "');", true);
        }

        private bool IsValidEntry()
        {
            bool isValid = true;

            return isValid;
        }

        private string eType
        {
            get { return Request.QueryString["eType"].ToString(); }
        }

        private int eID
        {
            get
            {
                if (Request.QueryString["eID"] == null)
                {
                    return 0;
                }
                else
                {
                    return int.Parse(Request.QueryString["eID"]);
                }
            }
            set { ViewState["eID"] = value; }
        }
    }
}