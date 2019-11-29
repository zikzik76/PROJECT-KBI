using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Penjaminan.Penjaminan
{
    public partial class EntryMitraWorkDone : System.Web.UI.Page
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
                    removeWorkDone(eID);
                }
            }
            
            lblMenu.Text = "Entry Master Mitra - Pekerjaan yang Telah Dilakukan";
            Session["activepage"] = "mitra";
        }
        
        protected void fillForm(int id)
        {
            List<Object.WorkDone2> wdList = (List<Object.WorkDone2>)Session["tWorkDoneList"];

            if (wdList.Count > 0)
            {
                Object.WorkDone2 wd = wdList.Find(x => x.id == id);

                txtId.Value = wd.id.ToString();
                txtName.Value = wd.namapaket;
                txtLokasi.Value = wd.lokasi;
                txtTanggalPelaksanaan.Value = wd.tanggalpelaksanaan.ToString("yyyy-MM-dd");
                txtNilai.Value = wd.nilai.ToString();
                txtTanggalSerah.Value = wd.tanggalserah.ToString("yyyy-MM-dd");
            }
        }

        protected void removeWorkDone(int id)
        {
            List<Object.WorkDone2> wdList = (List<Object.WorkDone2>)Session["tWorkDoneList"];

            wdList.Remove(wdList.Find(x => x.id == id ));

            Session.Remove("tWorkDoneList");
            Session["tWorkDoneList"] = wdList;

            Response.Redirect("/Penjaminan/EntryMitra.aspx?eType=" + eTypeMaster);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int tFkMitra = 0;
            tFkMitra = eID;
            int nilaiAkhir = int.Parse(Regex.Replace(txtNilai.Value, "[^0-9]+", string.Empty));
            List<Object.WorkDone2> wdList2 = new List<Object.WorkDone2>();
            Object.WorkDone2 wd2 = new Object.WorkDone2();

            if (Session["tWorkDoneList"] != null)
            {
                wdList2.AddRange((List<Object.WorkDone2>)Session["tWorkDoneList"]);
            }                       
            wd2.tipe = "D";
            wd2.fk_mitra = eID;
            wd2.namapaket = txtName.Value;
            wd2.lokasi = txtLokasi.Value;
            wd2.tanggalpelaksanaan = DateTime.Parse(txtTanggalPelaksanaan.Value);
            wd2.nilai = nilaiAkhir;
            wd2.tanggalserah = DateTime.Parse(txtTanggalSerah.Value);

           if(eType == "add")
            {
                if (!wdList2.Exists(x => x.tipe == wd2.tipe && x.namapaket == wd2.namapaket && x.lokasi == wd2.lokasi))
                {
                    wdList2.Add(wd2);
                }
            }
            else
            {
                List<Object.WorkDone2> wdList = (List<Object.WorkDone2>)Session["tWorkDoneList"];
                Object.WorkDone2 wd = wdList.Find(y => y.id == eID);

                //wd.id = int.Parse(txtId.Value);
                wd.namapaket = txtName.Value;
                wd.lokasi = txtLokasi.Value ;
                wd.tanggalpelaksanaan =Convert.ToDateTime(txtTanggalPelaksanaan.Value);
                wd.nilai = nilaiAkhir;
                wd.tanggalserah = Convert.ToDateTime(txtTanggalSerah.Value);
                tFkMitra = wd.fk_mitra;
            }

            Session.Remove("tWorkDoneList");
            Session["tWorkDoneList"] = wdList2;

            if(tFkMitra != 0)
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