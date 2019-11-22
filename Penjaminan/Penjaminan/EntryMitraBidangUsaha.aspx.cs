using Penjaminan.Models;
using Penjaminan.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Penjaminan.Penjaminan
{
    public partial class EntryMitraBidangUsaha : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!Page.IsPostBack)
            {
                populateBidangUsaha();

                if(eType == "edit")
                {
                  
                    cboBidangUsaha.ClearSelection();
                    cboBidangUsaha.Items.FindByValue(eID.ToString()).Selected = true;

                    updateListBidangUsaha(eID);
                   
                }
                else if(eType == "delete")
                {
                    removeBidangUsaha(eID);
                }
            }
        }
        protected void updateListBidangUsaha(int id)
        {
            List<Object.t_bidangusaha> tbuList = (List<Object.t_bidangusaha>)Session["tBidangUsahaList"];
            
            tbuList.Remove(tbuList.Find(x => x.fk_bidangusaha == id));
                     
            Session["tBidangUsahaList"] = tbuList;

            //Response.Redirect("/Penjaminan/EntryMitra.aspx?eType=" + eTypeMaster);
        }
        protected void removeBidangUsaha(int id)
        {
            List<Object.t_bidangusaha> tbuList = (List<Object.t_bidangusaha>) Session["tBidangUsahaList"];

            tbuList.Remove(tbuList.Find(x => x.fk_bidangusaha == id));

            Session.Remove("tBidangUsahaList");
            Session["tBidangUsahaList"] = tbuList;

            Response.Redirect("/Penjaminan/EntryMitra.aspx?eType=" + eTypeMaster);
        }

        protected void populateBidangUsaha()
        {
            Models.PenjaminanDatasetTableAdapters.m_bidangusahaTableAdapter ta = new Models.PenjaminanDatasetTableAdapters.m_bidangusahaTableAdapter();
            
            cboBidangUsaha.DataSource = ta.GetData();
            cboBidangUsaha.DataTextField = "name";
            cboBidangUsaha.DataValueField = "id";
            cboBidangUsaha.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int tFkMitra = 0;
            tFkMitra = eID;
            List<Object.t_bidangusaha> tbuList = new List<Object.t_bidangusaha>();
            Object.t_bidangusaha tbu = new Object.t_bidangusaha();

            if (Session["tBidangUsahaList"] != null)
            {
                tbuList.AddRange((List<Object.t_bidangusaha>)Session["tBidangUsahaList"]);
                
            }
                    
            tbu.fk_bidangusaha = int.Parse(cboBidangUsaha.SelectedItem.Value);
            tbu.name_bidangusaha = cboBidangUsaha.SelectedItem.Text;

           

            if (!tbuList.Exists(x => x.fk_bidangusaha == tbu.fk_bidangusaha))
            {
                tbuList.Add(tbu);
            }
            //else
            //{
            //    Response.Redirect("/Penjaminan/ViewMessage.aspx");
            //}
            Session.Remove("tBidangUsahaList");
            Session["tBidangUsahaList"] = tbuList;

            if (tFkMitra != 0)
            {
                var eMaster = Request.QueryString["eTypeMaster"];
                eMaster = "edit";
                eID = tFkMitra;
                Response.Redirect("/Penjaminan/EntryMitra.aspx?eID=" + tFkMitra + "&eType=" + eMaster);
            }
            else
            {
                Response.Redirect("/Penjaminan/EntryMitra.aspx?eType=" + eTypeMaster);
            }
        }

        private string eType
        {
            get { return Request.QueryString["eType"].ToString(); }
        }

        private string eTypeMaster
        {
            get { return Request.QueryString["eTypeMaster"].ToString(); }
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