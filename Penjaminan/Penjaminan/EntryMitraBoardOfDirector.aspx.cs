using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Penjaminan.Models;

namespace Penjaminan.Penjaminan
{
    public partial class EntryMitraBoardOfDirector : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserProfile"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            if (!Page.IsPostBack)
            {
                if (eType == "edit")
                {
                    fillForm(eID);
                    
                }
                else if (eType == "delete")
                {
                    removePic(eID);
                }
            }

            lblMenu.Text = "Entry Master Mitra - Board Of Director";
            Session["activepage"] = "mitra";
        }

        protected void fillForm(int id)
        {
            List<Object.BoardOfDirector> bodList = (List<Object.BoardOfDirector>)Session["tBodList"];

            if (bodList.Exists(x => x.id == id))
            {
                Object.BoardOfDirector bod = bodList.Find(x => x.id == id);

                txtName.Value = bod.name;
                txtJabatan.Value = bod.jabatan;
                txtTanggalLahir.Value = bod.tglLahir.ToString("yyyy-MM-dd");
            }
        }

        protected void removePic(int id)
        {
            List<Object.BoardOfDirector> bodList = (List<Object.BoardOfDirector>)Session["tBodList"];

            bodList.Remove(bodList.Find(x => x.id == id));

            Session.Remove("tBodList");
            Session["tBodList"] = bodList;

            Response.Redirect("/Penjaminan/EntryMitra.aspx?eType=" + eTypeMaster);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int tFkMitra = 0;
            tFkMitra = eID;
            List<Object.BoardOfDirector> bodList = new List<Object.BoardOfDirector>();
            Object.BoardOfDirector bod = new Object.BoardOfDirector();

            if (Session["tBodList"] != null)
            {
                bodList.AddRange((List<Object.BoardOfDirector>)Session["tBodList"]);
            }

           
            bod.fk_mitra = 0;
            bod.name = txtName.Value;
            bod.jabatan = txtJabatan.Value;
            bod.tglLahir = DateTime.Parse(txtTanggalLahir.Value);

            if (eType == "add")
            {
                if (!bodList.Exists(x => x.name == bod.name && x.jabatan == bod.jabatan))
                {
                    bodList.Add(bod);
                }
            }
            else
            {
                Object.BoardOfDirector bodOld = bodList.Find(x => x.id == eID);

                bodOld.name = txtName.Value;
                bodOld.jabatan = txtJabatan.Value;
                bodOld.tglLahir= DateTime.Parse(txtTanggalLahir.Value);
                tFkMitra = bodOld.fk_mitra;

            }

            Session.Remove("tBodList");
            Session["tBodList"] = bodList;

            if (tFkMitra != 0)
            {
                var eMaster = Request.QueryString["eTypeMaster"];
                eMaster = "edit";
         
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