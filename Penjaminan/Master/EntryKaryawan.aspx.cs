using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Penjaminan.Models;
using System.IO;

namespace Penjaminan.Master
{
    public partial class EntryKaryawan : System.Web.UI.Page
    {
        int tDivisiID = 0;
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
                   
                    //PenjaminanDataset.DivisiRow dr = m_divisi.selectDivisiByID(Convert.ToInt16(DropDownList1.Text));
                }
                else if (eType == "delete")
                {
                    softDeleteData(eID);
                }
            }

            lblMenu.Text = "Entry Master Karyawan";
            Session["activepage"] = "karyawan";

            if (!Page.IsPostBack)
            {


                Models.PenjaminanDatasetTableAdapters.DivisiTableAdapter ta = new Models.PenjaminanDatasetTableAdapters.DivisiTableAdapter();

                DropDownList1.DataSource = (PenjaminanDataset.DivisiDataTable)ta.GetData();
                DropDownList1.DataBind();

                if (eType=="edit")
                {
                    PenjaminanDataset.KaryawanRow dr = Karyawan.selectKaryawanByID(eID);
                    tDivisiID = dr.DivisiID;
                    DropDownList1.SelectedValue = tDivisiID.ToString();
                }
               
                //DropDownList1.DataTextFormatString = "{0} - {1}";
                //DropDownList1.DataTextField = "ID,NamaDivisi";

            }

        }
        private void bindData()
        {
            PenjaminanDataset.KaryawanRow dr = Karyawan.selectKaryawanByID(eID);
            Models.PenjaminanDatasetTableAdapters.DivisiTableAdapter ta = new Models.PenjaminanDatasetTableAdapters.DivisiTableAdapter();

            DropDownList1.DataSource = (PenjaminanDataset.DivisiDataTable)ta.GetDataByID(dr.DivisiID);
            DropDownList1.DataBind();

            txtName.Value = dr.Nama.ToString();
            
            txtAlamat.Value = dr.Alamat.ToString();            
        }
        protected void btnSubmit_click(object sender, EventArgs e)
        {        
            try
            {
                //var a = DropDownList1.SelectedIndex;
                //var b = DropDownList1.SelectedValue;
                //var c = DropDownList1.SelectedItem;
                if (eID != 0 && IsValidEntry())
                {                                      
                    Karyawan.UpdateData(eID, txtName.Value, Convert.ToInt16(DropDownList1.SelectedValue), txtAlamat.Value);
                }
                else if (eID == 0 && IsValidEntry())
                {
                    Karyawan.InsertData(txtName.Value,Convert.ToInt16(DropDownList1.SelectedValue), txtAlamat.Value);
                }
                Response.Redirect("/Master/ViewKaryawan.aspx");
            }
            catch (Exception ex)
            {
                //uiBLError.Items.Add(ex.Message);
                //uiBLError.Visible = true;
            }
        }

        private void softDeleteData(int id)
        {
            //if ()
            //Karyawan.SoftDeleteData(id);
            Response.Redirect("/Master/ViewKaryawan.aspx");
        }

        protected void uiBtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Master/ViewKaryawan.aspx");
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

        //protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    PenjaminanDataset.DivisiRow dr = m_divisi.selectIDByNamaDivisi(DropDownList1.SelectedItem.Text);

        //    tDivisiID = dr.ID;
        //}
        protected void itemSelected(object sender, EventArgs e)
        {
            PenjaminanDataset.DivisiRow dr = m_divisi.selectIDByNamaDivisi(DropDownList1.SelectedItem.Text);
            tDivisiID = dr.ID;
            //string message = DropDownList1.SelectedItem.Text + " - " + DropDownList1.SelectedItem.Value;
            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + message + "');", true);            
        }
    }
}