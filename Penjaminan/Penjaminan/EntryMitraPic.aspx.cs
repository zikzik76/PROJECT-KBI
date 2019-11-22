using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Penjaminan.Penjaminan
{
    public partial class EntryMitraPic : System.Web.UI.Page
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

            lblMenu.Text = "Entry Master Mitra - PIC";
            Session["activepage"] = "mitra";
        }

        protected void fillForm(int id)
        {
            List<Object.Pic> picList = (List<Object.Pic>)Session["tPicList"];

            if (picList.Exists(x => x.id == id))
            {
                Object.Pic pic = picList.Find(x => x.id == id);

                txtName.Value = pic.name;
                txtJabatan.Value = pic.jabatan;
                txtNoTelepon.Value = pic.noTelepon;
                txtEmail.Value = pic.email;
            }
        }

        protected void removePic(int id)
        {
            List<Object.Pic> picList = (List<Object.Pic>)Session["tPicList"];

            picList.Remove(picList.Find(x => x.id == id));

            Session.Remove("tPicList");
            Session["tPicList"] = picList;

            Response.Redirect("/Penjaminan/EntryMitra.aspx?eType=" + eTypeMaster);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int tFkMitra = 0;
            tFkMitra = eID;

            List<Object.Pic> picList = new List<Object.Pic>();
            Object.Pic pic = new Object.Pic();

            if (Session["tPicList"] != null)
            {
                picList.AddRange((List<Object.Pic>)Session["tPicList"]);
            }
           
            pic.fk_mitra = 0;
            pic.name = txtName.Value;
            pic.jabatan = txtJabatan.Value;
            pic.noTelepon = txtNoTelepon.Value;
            pic.email = txtEmail.Value;

            if ( eType == "add")
            {
                if (!picList.Exists(x => x.name == pic.name && x.jabatan == pic.jabatan))
                {
                    picList.Add(pic);
                }
            }
            else
            {
                List<Object.Pic> picOList = (List<Object.Pic>)Session["tPicList"];
                Object.Pic picOL = picOList.Find(y => y.id == eID);

                picOL.name = txtName.Value;
                picOL.jabatan = txtJabatan.Value;
                picOL.noTelepon = txtNoTelepon.Value;
                picOL.email = txtEmail.Value;
                tFkMitra = picOL.fk_mitra;
            }

            Session.Remove("tPicList");
            Session["tPicList"] = picList;

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