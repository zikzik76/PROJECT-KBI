using Penjaminan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Penjaminan.Master
{
    public partial class EntryDocument1 : System.Web.UI.Page
    {
        int tKategoriID =0;
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

            lblMenu.Text = "Entry Master Document";
            Session["activepage"] = "document";

            if (!Page.IsPostBack)
            {


                Models.PenjaminanDatasetTableAdapters.m_kategoriTableAdapter ta = new Models.PenjaminanDatasetTableAdapters.m_kategoriTableAdapter();

                DropDownList1.DataSource = (PenjaminanDataset.m_kategoriDataTable)ta.GetData();
                DropDownList1.DataBind();

                if (eType == "edit")
                {
                    PenjaminanDataset.m_documentRow dr = m_document.selectDocumentByID(eID);
                    tKategoriID = dr.fk_kategori;
                    DropDownList1.SelectedValue = tKategoriID.ToString();
                }

                //DropDownList1.DataTextFormatString = "{0} - {1}";
                //DropDownList1.DataTextField = "ID,NamaDivisi";

            }
        }

        private void bindData()
        {
            PenjaminanDataset.m_documentRow dr = m_document.selectDocumentByID(eID);
            Models.PenjaminanDatasetTableAdapters.m_kategoriTableAdapter ta = new Models.PenjaminanDatasetTableAdapters.m_kategoriTableAdapter();

            DropDownList1.DataSource = (PenjaminanDataset.m_kategoriDataTable)ta.GetDataKategoriByID(dr.fk_kategori);
            DropDownList1.DataBind();
            txtName.Value = dr.name.ToString();
            txtDescription.Value = dr.description.ToString();
        }

        private void softDeleteData(int id)
        {
            m_document.SoftDeleteData(id);
            Response.Redirect("/Master/ViewDocument.aspx");
        }

        protected void uiBtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Master/ViewDocument.aspx");
        }

        protected void btnSubmit_click(object sender, EventArgs e)
        {
            try
            {
                if (eID != 0 && IsValidEntry())
                {
                    m_document.UpdateData(eID, Convert.ToInt16(DropDownList1.SelectedValue), txtName.Value, txtDescription.Value);
                }
                else if (eID == 0 && IsValidEntry())
                {
                    m_document.InsertData(Convert.ToInt16(DropDownList1.SelectedValue),txtName.Value, txtDescription.Value);
                }
                Response.Redirect("/Master/ViewDocument.aspx");
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
        protected void itemSelected(object sender, EventArgs e)
        {
            PenjaminanDataset.m_kategoriRow dr = m_kategori.SelectDataByName(DropDownList1.SelectedItem.Text);
            tKategoriID = dr.id;
            //string message = DropDownList1.SelectedItem.Text + " - " + DropDownList1.SelectedItem.Value;
            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + message + "');", true);            
        }
    }
}