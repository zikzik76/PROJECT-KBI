﻿using Penjaminan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Penjaminan.Master
{
    public partial class EntryProduct : System.Web.UI.Page
    {
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

            lblMenu.Text = "Entry Master Product";
            Session["activepage"] = "product";
        }

        private void bindData()
        {
            PenjaminanDataset.m_productRow dr = m_product.selectProductByID(eID);
            txtName.Value = dr.name.ToString();
            txtDescription.Value = dr.description.ToString();
        }

        private void softDeleteData(int id)
        {
            m_product.SoftDeleteData(id);
            Response.Redirect("/Master/ViewProduct.aspx");
        }

        protected void uiBtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Master/ViewProduct.aspx");
        }

        protected void btnSubmit_click(object sender, EventArgs e)
        {
            try
            {
                if (eID != 0 && IsValidEntry())
                {
                    m_product.UpdateData(eID, txtName.Value, txtDescription.Value);
                }
                else if (eID == 0 && IsValidEntry())
                {
                    m_product.InsertData(txtName.Value, txtDescription.Value);
                }
                Response.Redirect("/Master/ViewProduct.aspx");
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
    }
}