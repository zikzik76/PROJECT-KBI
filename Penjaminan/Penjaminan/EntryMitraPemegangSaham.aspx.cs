using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Penjaminan.Penjaminan
{
    public partial class EntryMitraPemegangSaham : System.Web.UI.Page
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

            lblMenu.Text = "Entry Master Mitra - Pemegang Saham";

            Session["activepage"] = "mitra";
        }

        protected void fillForm(int id)
        {
            List<Object.PemegangSaham> psList = (List<Object.PemegangSaham>)Session["tPemegangSahamList"];

            if (psList.Exists(x => x.id == id))
            {
                Object.PemegangSaham ps = psList.Find(x => x.id == id);

                txtName.Value = ps.name;
                txtJumlahSaham.Value = ps.jumlah.ToString();
                txtTotal.Value = ps.total.ToString();
                txtPersentase.Value = ps.persentase.ToString();
            }
        }

        protected void removePic(int id)
        {
            List<Object.PemegangSaham> psList = (List<Object.PemegangSaham>)Session["tPemegangSahamList"];

            psList.Remove(psList.Find(x => x.id == id));

            Session.Remove("tPemegangSahamList");
            Session["tPemegangSahamList"] = psList;

            Response.Redirect("/Penjaminan/EntryMitra.aspx?eType=" + eTypeMaster);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int tFkMitra = 0;
            tFkMitra = eID;

            List<Object.PemegangSaham> psList = new List<Object.PemegangSaham>();
            Object.PemegangSaham ps = new Object.PemegangSaham();

            if (Session["tPemegangSahamList"] != null)
            {
                psList.AddRange((List<Object.PemegangSaham>)Session["tPemegangSahamList"]);
            }
           
            ps.fk_mitra = 0;
            ps.name = txtName.Value;
            ps.jumlah = decimal.Parse(txtJumlahSaham.Value);
            ps.total = decimal.Parse(txtTotal.Value);
            ps.persentase = decimal.Parse(txtPersentase.Value);

            if(eType == "add")
            {
                if (!psList.Exists(x => x.name == ps.name))
                {
                    psList.Add(ps);
                }
            }
            else
            {
                Object.PemegangSaham psOld = psList.Find(x => x.id == eID);

                psOld.name = txtName.Value;
                psOld.jumlah = decimal.Parse(txtJumlahSaham.Value);
                psOld.total = decimal.Parse(txtTotal.Value);
                psOld.persentase = decimal.Parse(txtPersentase.Value);
                tFkMitra = psOld.fk_mitra;
            }

            Session.Remove("tPemegangSahamList");
            Session["tPemegangSahamList"] = psList;

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