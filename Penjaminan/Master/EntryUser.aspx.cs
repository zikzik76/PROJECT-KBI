using Penjaminan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Penjaminan.Master
{
    public partial class EntryUser : System.Web.UI.Page
    {
        int tDivisiID = 0;       
        int tRoleID = 0;
 
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
                else if(eType == "delete")
                {
                    softDeleteData(eID);
                }
            }

            lblMenu.Text = "Entry Master User";
            Session["activepage"] = "user";         

            if (!Page.IsPostBack)
            {


                Models.PenjaminanDatasetTableAdapters.DivisiTableAdapter ta = new Models.PenjaminanDatasetTableAdapters.DivisiTableAdapter();
                Models.PenjaminanDatasetTableAdapters.u_roleTableAdapter taRole = new Models.PenjaminanDatasetTableAdapters.u_roleTableAdapter();

                DropDownList1.DataSource = (PenjaminanDataset.DivisiDataTable)ta.GetData();
                DropDownList1.DataBind();

                RoleList.DataSource = (PenjaminanDataset.u_roleDataTable)taRole.GetData();
                RoleList.DataBind();

                //set jadi kosong ketika add new
               

                if (eType == "edit")
                {
                    PenjaminanDataset.UserProfileRow dr = UserProfile.selectUserProfileByID(eID);
                    tDivisiID =Convert.ToInt16(dr.division);
                    tRoleID = Convert.ToInt16(dr.role);

                    DropDownList1.SelectedValue = tDivisiID.ToString();
                    RoleList.SelectedValue = tRoleID.ToString();

                }
                //else if(eType == "add")
                //{
                //    DropDownList1.SelectedValue = " ";
                //    RoleList.SelectedValue = " ";
                //}

                //DropDownList1.DataTextFormatString = "{0} - {1}";
                //DropDownList1.DataTextField = "ID,NamaDivisi";

            }
        }

        private void bindData()
        {
            PenjaminanDataset.UserProfileRow dr = UserProfile.selectUserProfileByID(eID);
            Models.PenjaminanDatasetTableAdapters.u_roleTableAdapter taRole = new Models.PenjaminanDatasetTableAdapters.u_roleTableAdapter();
            Models.PenjaminanDatasetTableAdapters.DivisiTableAdapter ta = new Models.PenjaminanDatasetTableAdapters.DivisiTableAdapter();

            DropDownList1.DataSource = (PenjaminanDataset.DivisiDataTable)ta.GetDataByID(Convert.ToInt16(dr.division));
            RoleList.DataSource = (PenjaminanDataset.u_roleDataTable)taRole.GetDataRoleByID(Convert.ToInt16(dr.role));

            DropDownList1.DataBind();
            RoleList.DataBind();
            txtUsername.Value = dr.username.ToString();
            txtPassword.Value = dr.password.ToString();
            //txtRole.Value = dr.role.ToString();
            //txtDivision.Value = dr.division.ToString();
        }

        private void softDeleteData(int id)
        {
            UserProfile.SoftDeleteData(id);
            Response.Redirect("/Master/ViewUser.aspx");
        }

        protected void uiBtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Master/ViewUser.aspx");
        }

        protected void btnSubmit_click(object sender, EventArgs e)
        {
            try
            {
                if (eID != 0 && IsValidEntry())
                {
                    UserProfile.UpdateData(eID, txtUsername.Value, txtPassword.Value, Convert.ToInt16(RoleList.SelectedValue), Convert.ToInt16(DropDownList1.SelectedValue));
                }
                else if(eID == 0 && IsValidEntry())
                {

                    UserProfile.InsertData(txtUsername.Value, txtPassword.Value, Convert.ToInt16(RoleList.SelectedValue), Convert.ToInt16(DropDownList1.SelectedValue));
                }
                Response.Redirect("/Master/ViewUser.aspx");
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
        protected void itemSelectedDivisi(object sender, EventArgs e)
        {
            PenjaminanDataset.DivisiRow dr = m_divisi.selectIDByNamaDivisi(DropDownList1.SelectedItem.Text);
            tDivisiID = dr.ID;
            //string message = DropDownList1.SelectedItem.Text + " - " + DropDownList1.SelectedItem.Value;
            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + message + "');", true);            
        }
        protected void itemSelectedRole(object sender, EventArgs e)
        {
            PenjaminanDataset.u_roleRow dr = u_role.selectIDByRole(RoleList.SelectedItem.Text);
            tDivisiID = dr.id;
            //string message = DropDownList1.SelectedItem.Text + " - " + DropDownList1.SelectedItem.Value;
            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + message + "');", true);            
        }
    }
}