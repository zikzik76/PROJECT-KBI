using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Penjaminan.Penjaminan
{
    public partial class EntryMitraWorkProgress : System.Web.UI.Page
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
                    removeWorkProgress(eID);
                }
            }

            lblMenu.Text = "Entry Master Mitra - Pekerjaan yang Sedang Dilakukan";
            Session["activepage"] = "mitra";
        }

        protected void fillForm(int id)
        {
            List<Object.WorkProgress> wpList = (List<Object.WorkProgress>)Session["tWorkProgressList"];

            if (wpList.Exists(x => x.id == id))
            {
                Object.WorkProgress wp = wpList.Find(x => x.id == id);

                txtName.Value = wp.namapaket;
                txtLokasi.Value = wp.lokasi;
                txtTanggalPelaksanaan.Value = wp.tanggalpelaksanaan.ToString("yyyy-MM-dd");
                txtNilai.Value = wp.nilai.ToString();
                txtTanggalSerah.Value = wp.tanggalserah.ToString("yyyy-MM-dd");
            }
        }

        protected void removeWorkProgress(int id)
        {
            List<Object.WorkProgress> wpList = (List<Object.WorkProgress>)Session["tWorkProgressList"];

            wpList.Remove(wpList.Find(x => x.id == id));

            Session.Remove("tWorkProgressList");
            Session["tWorkProgressList"] = wpList;

            Response.Redirect("/Penjaminan/EntryMitra.aspx?eType=" + eTypeMaster);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int tFkMitra = 0;
            tFkMitra = eID;

            List<Object.WorkProgress> wpList = new List<Object.WorkProgress>();
            Object.WorkProgress wp = new Object.WorkProgress();

            if (Session["tWorkProgressList"] != null)
            {
                wpList.AddRange((List<Object.WorkProgress>)Session["tWorkProgressList"]);
            }           
            wp.tipe = "P";
            wp.namapaket = txtName.Value;
            wp.lokasi = txtLokasi.Value;
            wp.tanggalpelaksanaan = DateTime.Parse(txtTanggalPelaksanaan.Value);
            wp.nilai = decimal.Parse(txtNilai.Value);
            wp.tanggalserah = DateTime.Parse(txtTanggalSerah.Value);


            if (eType == "add")
            {
                if (!wpList.Exists(x => x.tipe == wp.tipe && x.namapaket == wp.namapaket && x.lokasi == wp.lokasi))
                {
                    wpList.Add(wp);
                }
            }
            else
            {
                List<Object.WorkProgress> wdList = (List<Object.WorkProgress>)Session["tWorkProgressList"];
                Object.WorkProgress wd = wdList.Find(y => y.id == eID);

                //wd.id = int.Parse(txtId.Value);
                wd.namapaket = txtName.Value;
                wd.lokasi = txtLokasi.Value;
                wd.tanggalpelaksanaan = Convert.ToDateTime(txtTanggalPelaksanaan.Value);
                wd.nilai = int.Parse(txtNilai.Value);
                wd.tanggalserah = Convert.ToDateTime(txtTanggalSerah.Value);
            }

            Session.Remove("tWorkProgressList");
            Session["tWorkProgressList"] = wpList;

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