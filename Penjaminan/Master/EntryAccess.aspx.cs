using Penjaminan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Penjaminan.Master
{
    public partial class EntryAccess : System.Web.UI.Page
    {
        int tRoleID = 0;
        int tPageID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserProfile"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (!Page.IsPostBack)
            {
                if (eType == "add")
                {

                }
                else if (eType == "edit")
                {
                    bindData();
                }
                else if (eType == "delete")
                {
                    softDeleteData(eID);
                }
               
            }
           
            lblMenu.Text = "Entry Master Access";
            Session["activepage"] = "Access";

            if (!Page.IsPostBack)
            {
                
                Models.PenjaminanDatasetTableAdapters.tPageTableAdapter ta = new Models.PenjaminanDatasetTableAdapters.tPageTableAdapter();
                Models.PenjaminanDatasetTableAdapters.u_roleTableAdapter taRole = new Models.PenjaminanDatasetTableAdapters.u_roleTableAdapter();

                PageList.DataSource = (PenjaminanDataset.tPageDataTable)ta.GetData();
                PageList.DataBind();

                RoleList.DataSource = (PenjaminanDataset.u_roleDataTable)taRole.GetData();
                RoleList.DataBind();

                if (eType == "edit")
                {
                    PenjaminanViewDataset.AccessRow dr = Access.selectAccessByID(eID);
                    tPageID = Convert.ToInt16(dr.fk_page);
                    tRoleID = Convert.ToInt16(dr.fk_role);

                    PageList.SelectedValue = tPageID.ToString();
                    RoleList.SelectedValue = tRoleID.ToString();

                }
            }


            }
    
         private void bindData()
        {
            PenjaminanViewDataset.AccessRow dr = Access.selectAccessByID(eID);
            Models.PenjaminanDatasetTableAdapters.u_roleTableAdapter taRole = new Models.PenjaminanDatasetTableAdapters.u_roleTableAdapter();
            Models.PenjaminanDatasetTableAdapters.tPageTableAdapter ta = new Models.PenjaminanDatasetTableAdapters.tPageTableAdapter();

            PageList.DataSource = (PenjaminanDataset.tPageDataTable)ta.GetDataByID(Convert.ToInt16(dr.fk_page));
            RoleList.DataSource = (PenjaminanDataset.u_roleDataTable)taRole.GetDataRoleByID(Convert.ToInt16(dr.fk_role));

            PageList.DataBind();
            RoleList.DataBind();
            //txtUsername.Value = dr.username.ToString();
            //txtPassword.Value = dr.password.ToString();
            //txtRole.Value = dr.role.ToString();
            //txtDivision.Value = dr.division.ToString();
        }

        private void softDeleteData(int id)
        {
            Access.SoftDeleteData(id);
            Response.Redirect("/Master/ViewAccess.aspx");
        }
        //public int validasi(int fk_role, int fk_page)
        //{
        //    var val = Access.validasi(fk_role, fk_page);
        //    return val;
        //    //Response.Redirect("/Master/ViewAccess.aspx");
        //}
        protected void uiBtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Master/ViewAccess.aspx");
        }

        protected void btnSubmit_click(object sender, EventArgs e)
        {
            try
            {
                var val = Access.validasi(Convert.ToInt16(RoleList.SelectedValue), Convert.ToInt16(PageList.SelectedValue));
                if(val == 0)
                {
                    if (eID != 0 && IsValidEntry())
                    {
                        //UserProfile.UpdateData(eID, txtUsername.Value, txtPassword.Value, Convert.ToInt16(RoleList.SelectedValue), Convert.ToInt16(DropDownList1.SelectedValue));
                        Access.UpdateData(eID, Convert.ToInt16(RoleList.SelectedValue), Convert.ToInt16(PageList.SelectedValue));
                    }
                    else if (eID == 0 && IsValidEntry())
                    {

                        //UserProfile.InsertData(txtUsername.Value, txtPassword.Value, Convert.ToInt16(RoleList.SelectedValue), Convert.ToInt16(DropDownList1.SelectedValue));
                        Access.InsertData(Convert.ToInt16(RoleList.SelectedValue), Convert.ToInt16(PageList.SelectedValue));
                    }
                    Response.Redirect("/Master/ViewAccess.aspx");
                }
                else if(val == 2)
                {
                    Response.Redirect("/Master/ViewAccess.aspx");
                }
                else
                {
                    string message ="Page " + PageList.SelectedItem.Text + " - dengan Role  " + RoleList.SelectedItem.Text + " Sudah tersdia !";
                    ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('" + message + "');", true);
                    //string script = "alert('abc');";
                    //ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);

                    //Response.Write(@"<script langauge='text/javascript'>alert('...Alert Goes here...');</script>");
                }
                
            }
            catch (Exception ex)
            {
                //uiBLError.Items.Add(ex.Message);
                //uiBLError.Visible = true;
            }
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
        protected void itemSelectedPage(object sender, EventArgs e)
        {

            PenjaminanDataset.tPageRow dr = tPage.SelectByName(PageList.SelectedItem.Text);
            tPageID = dr.id;
            //string message = PageList.SelectedItem.Text + " - " + PageList.SelectedItem.Value;
            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + message + "');", true);
        }
        protected void itemSelectedRole(object sender, EventArgs e)
        {
            PenjaminanDataset.u_roleRow dr = u_role.selectIDByRole(RoleList.SelectedItem.Text);
            tRoleID = dr.id;
            ////string message = DropDownList1.SelectedItem.Text + " - " + DropDownList1.SelectedItem.Value;
            ////ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + message + "');", true);            
        }
    }
}