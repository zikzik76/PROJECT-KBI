using Penjaminan.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Penjaminan.Penjaminan
{
    public partial class PreviewMitra : System.Web.UI.Page
    {
        int tSquence = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserProfile"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (!Page.IsPostBack)
            {
                if(eType == "preview")
                {
                    BindPreview(eID);
                }
                else if (eType == "download")
                {
                    DownloadFile(eID);
                }
            }           

            lblMenu.Text = "Entry Master Mitra";
            Session["activepage"] = "mitra";            
            
        }

        protected void DownloadFile(int id)
        {
            byte[] bytes;
            string fileName;
            int tfkMitra = 0;
            string constr = ConfigurationManager.ConnectionStrings["PenjaminanConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select fk_mitra, name, tipeData from m_checklist where Id=@Id";
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        bytes = (byte[])sdr["tipeData"];
                        fileName = sdr["name"].ToString();
                        tfkMitra = Convert.ToInt32(sdr["fk_mitra"]);
                    }
                    con.Close();
                }
            }
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            if (fileName != "")
            {
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.End();
            }
            var eMaster = Request.QueryString["eTypeMaster"];
            eMaster = "preview";
            Response.Redirect("/Penjaminan/PreviewMitra.aspx?eID=" + tfkMitra + "&eType=" + eMaster);
        }
        public void BindPreview(int id)
        {
            if (Session["tMitra"] == null || Session["tBidangUsahaList"] == null || Session["tWorkDoneList"] == null || Session["tWorkProgressList"] == null || Session["tPicList"] == null || Session["documentDt"] == null || Session["tPemegangSahamList"] == null || Session["tBodList"] == null)
            {
                //ambil data mitra sesuai id 
                PenjaminanDataset.m_mitraRow dr = m_mitra.selectMitraByID(id);
                List<Object.m_mitra> mitraLIst = new List<Object.m_mitra>();
                Object.m_mitra mitra = new Object.m_mitra();

                txtCalonMitra.Value = dr.name;
                mitra.name = dr.name;
                txtLatarBelakang.Value = dr.latarbelakang;
                mitra.name = dr.latarbelakang;
                mitra.status = dr.status;
                if (mitra.status == "E")
                {
                    txtStatusE.Checked = true;
                }
                else
                {
                    txtStatusB.Checked = true;
                }
                Session.Remove("tMitra");
                Session["tMitra"] = mitraLIst;

                //ambil buat bidang usaha
                var bidList = t_bidangusaha.selectByFK(eID);
                List<Object.t_bidangusaha> bidList1 = new List<Object.t_bidangusaha>();
                foreach (var a in bidList)
                {
                    Object.t_bidangusaha bid = new Object.t_bidangusaha();
                    bid.fk_bidangusaha = Convert.ToDecimal(a.fk_bidangusaha);
                    bid.name_bidangusaha = a.name;
                    bid.fk_mitra = a.fk_mitra;
                    bid.id = Convert.ToInt32(a.ID);

                    bidList1.Add(bid);
                }
                Session.Remove("tBidangUsahaList");
                Session["tBidangUsahaList"] = bidList1;

                // ambil m_pekerjaan done
                var workDown = m_pekerjaan.selectWDFK(eID);
                List<Object.WorkDone2> workDownList = new List<Object.WorkDone2>();
                foreach (var a in workDown)
                {
                    Object.WorkDone2 Wdone = new Object.WorkDone2();

                    Wdone.fk_mitra = Convert.ToInt32(a.fk_mitra);
                    Wdone.id = Convert.ToInt32(a.id);
                    Wdone.namapaket = a.namapaket;
                    Wdone.nilai = a.nilai;
                    Wdone.tanggalpelaksanaan = a.tanggalpelaksanaan;
                    Wdone.tanggalserah = a.tanggalserah;
                    Wdone.tipe = a.tipe;
                    Wdone.lokasi = a.lokasi;

                    workDownList.Add(Wdone);
                }
                Session.Remove("tWorkDoneList");
                Session["tWorkDoneList"] = workDownList;

                //ambil m_pekerjaan progress
                var workProgres = m_pekerjaan.selectWPFK(eID);
                List<Object.WorkProgress> workProgressList = new List<Object.WorkProgress>();
                foreach (var a in workProgres)
                {
                    Object.WorkProgress WP = new Object.WorkProgress();

                    WP.fk_mitra = Convert.ToInt32(a.fk_mitra);
                    WP.id = Convert.ToInt32(a.id);
                    WP.namapaket = a.namapaket;
                    WP.nilai = a.nilai;
                    WP.tanggalpelaksanaan = a.tanggalpelaksanaan;
                    WP.tanggalserah = a.tanggalserah;
                    WP.tipe = a.tipe;
                    WP.lokasi = a.lokasi;

                    workProgressList.Add(WP);
                }
                Session.Remove("tWorkProgressList");
                Session["tWorkProgressList"] = workProgressList;

                //ambil m_PIC
                var PIC = m_pic.selectPICFK(eID);
                List<Object.Pic> picList = new List<Object.Pic>();
                foreach (var a in PIC)
                {
                    Object.Pic pic = new Object.Pic();

                    pic.fk_mitra = Convert.ToInt32(a.fk_mitra);
                    pic.id = Convert.ToInt32(a.id);
                    pic.name = a.name;
                    pic.jabatan = a.description;
                    pic.noTelepon = a.noTelepon;
                    pic.email = a.email;
                    picList.Add(pic);
                }
                Session.Remove("tPicList");
                Session["tPicList"] = picList;

                //ambil m_PemegangSaham
                var Saham = m_pemegangsaham.selectSahamFK(eID);
                List<Object.PemegangSaham> SahamList = new List<Object.PemegangSaham>();
                foreach (var a in Saham)
                {
                    Object.PemegangSaham PS = new Object.PemegangSaham();

                    PS.fk_mitra = Convert.ToInt32(a.fk_mitra);
                    PS.id = Convert.ToInt32(a.id);
                    PS.name = a.name;
                    PS.jumlah = a.jumlah;
                    PS.persentase = a.persentase;
                    PS.total = a.total;

                    SahamList.Add(PS);
                }
                Session.Remove("tPemegangSahamList");
                Session["tPemegangSahamList"] = SahamList;

                //ambil BOD
                var BOD = m_bod.selectBODFK(eID);
                List<Object.BoardOfDirector> BODList = new List<Object.BoardOfDirector>();
                foreach (var a in BOD)
                {
                    Object.BoardOfDirector bod = new Object.BoardOfDirector();

                    bod.fk_mitra = Convert.ToInt32(a.fk_mitra);
                    bod.id = a.ID;
                    bod.name = a.name;
                    bod.jabatan = a.jabatan;
                    bod.tglLahir = a.tglLahir;

                    BODList.Add(bod);
                }
                Session.Remove("tBodList");
                Session["tBodList"] = BODList;

                //ambil checklist
                Models.PenjaminanViewDatasetTableAdapters.BuatListTableAdapter ta = new Models.PenjaminanViewDatasetTableAdapters.BuatListTableAdapter();
                List<Object.Checklist> checkList = new List<Object.Checklist>();
                foreach (PenjaminanViewDataset.BuatListRow dr1 in ta.GetDataByfkMitra(id))
                {
                    Object.Checklist check = new Object.Checklist();

                    check.id = dr1.ID;
                    check.name = dr1.name;
                    check.kategoriname = dr1.KategoryName;
                    check.FileName = dr1.FileName;
                    check.fk_mitra = id;
                    checkList.Add(check);
                }
                Session.Remove("documentDt");
                Session["documentDt"] = checkList;
            }
            else
            {
                //ambil data mitra sesuai id 
                PenjaminanDataset.m_mitraRow dr = m_mitra.selectMitraByID(id);
                List<Object.m_mitra> mitraLIst = new List<Object.m_mitra>();
                Object.m_mitra mitra = new Object.m_mitra();

                txtCalonMitra.Value = dr.name;
                mitra.name = dr.name;
                txtLatarBelakang.Value = dr.latarbelakang;
                mitra.name = dr.latarbelakang;
                mitra.status = dr.status;
                if (mitra.status == "E")
                {
                    txtStatusE.Checked = true;
                }
                else
                {
                    txtStatusB.Checked = true;
                }
                Session.Remove("tMitra");
                Session["tMitra"] = mitraLIst;

                //session buat checklist
                Models.PenjaminanViewDatasetTableAdapters.BuatListTableAdapter ta = new Models.PenjaminanViewDatasetTableAdapters.BuatListTableAdapter();
                List<Object.Checklist> checkList = new List<Object.Checklist>();
                foreach (PenjaminanViewDataset.BuatListRow dr1 in ta.GetDataByfkMitra(id))
                {
                    Object.Checklist check = new Object.Checklist();
                    check.id = dr1.ID;
                    check.name = dr1.name;
                    check.kategoriname = dr1.KategoryName;
                    check.FileName = dr1.FileName;
                    checkList.Add(check);
                    check.fk_mitra = id;
                }
                Session.Remove("documentDt");
                Session["documentDt"] = checkList;
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //inisiasi u/ kebuutuhan tbl t_workflow

            var user = (PenjaminanDataset.UserProfileRow)Session["UserProfile"];
            tSquence = Convert.ToInt32(user.role);
            int tModeule = eID;
            string Module = "mitra";
            int tMwf = 0;
            int tUrutan1 = 0;
            int tUrutan2 = 0;
            //buat validasi
            if (tSquence != 1)
            {
                tUrutan1 = tSquence - 1;
                Models.PenjaminanDatasetTableAdapters.m_workflowTableAdapter taVal1 = new Models.PenjaminanDatasetTableAdapters.m_workflowTableAdapter();
                PenjaminanDataset.m_workflowDataTable dtVal1 = taVal1.GetDataTwf(tUrutan1, Module);
                PenjaminanDataset.m_workflowDataTable dtModule = taVal1.GetDataModule(Module);
                
                foreach (PenjaminanDataset.m_workflowRow drX in taVal1.GetDataModule(Module))
                {
                    var pembanding = drX.sequence - 1;
                   
                    //get data buat validasi jancuk
                    if(pembanding == tUrutan1)
                    {
                        Models.PenjaminanDatasetTableAdapters.t_workflowTableAdapter taVal2 = new Models.PenjaminanDatasetTableAdapters.t_workflowTableAdapter();
                        PenjaminanDataset.t_workflowDataTable dtVal2 = taVal2.GetDataValidasi(1, drX.sequence - 1, eID);
                        if (dtVal2.Count > 0)
                        {
                            tMwf = dtVal1[0].idModule;

                            Models.PenjaminanDatasetTableAdapters.t_workflowTableAdapter ta = new Models.PenjaminanDatasetTableAdapters.t_workflowTableAdapter();
                            PenjaminanDataset.t_workflowDataTable dtWF = ta.GetDataByforUpdateStatusMitra(tMwf, eID);

                            ta.Insert(tMwf, tModeule, drX.sequence,tSquence, "Y", textKeterangan.Value, user.id.ToString(), DateTime.Now,null, null, "0");

                            PenjaminanDataset.t_workflowDataTable dtWF2 = ta.GetDataByforUpdateStatusMitra(tMwf, eID);
                            string type = "aproove";
                            if (txtCalonMitra.Value == "")
                            {
                                throw new Exception("Field Calon Mitra is Mandatory");
                            }
                            //buat validasi apakah dia sudah terapprove semua atau tidak
                            if(dtModule.Count == dtWF2.Count)
                            {
                                m_mitra.UpdateStatus(eID, textKeterangan.Value, type);
                            }
                            Response.Redirect("/Penjaminan/ViewMitra.aspx");
                        }
                        else
                        {
                            string message = "Tidak Bisa Approve, karena level " + tUrutan1 + " Belum Approve!";
                            //ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('" + message + "');", true);
                            Response.Write("<script>alert('"+ message +"');window.location = '/Penjaminan/ViewMitra.aspx';</script>");
                           
                            //Response.Redirect("/Penjaminan/ViewMitra.aspx");
                        }
                    }
                    
                }
            }
            else
            {
                Models.PenjaminanDatasetTableAdapters.m_workflowTableAdapter taVal1 = new Models.PenjaminanDatasetTableAdapters.m_workflowTableAdapter();
                PenjaminanDataset.m_workflowDataTable dtVal1 = taVal1.GetDataTwf(tSquence, Module);
                if (dtVal1.Count > 0)
                {
                    tMwf = dtVal1[0].id;

                    Models.PenjaminanDatasetTableAdapters.t_workflowTableAdapter ta = new Models.PenjaminanDatasetTableAdapters.t_workflowTableAdapter();

                    ta.Insert(tMwf, tModeule, tSquence, tSquence, "Y", textKeterangan.Value, user.id.ToString(), DateTime.Now,null, null, "0");

                    string type = "aproove";
                    if (txtCalonMitra.Value == "")
                    {
                        throw new Exception("Field Calon Mitra is Mandatory");
                    }
                    m_mitra.UpdateStatus(eID, textKeterangan.Value, type);

                    Response.Redirect("/Penjaminan/ViewMitra.aspx");
                }
            }
            ////buat dapetin fk_m_workflow
            //Models.PenjaminanDatasetTableAdapters.m_workflowTableAdapter tax = new Models.PenjaminanDatasetTableAdapters.m_workflowTableAdapter();
            //PenjaminanDataset.m_workflowDataTable dtX = tax.GetDataTwf(tSquence, Module);
            //if(dtX.Count > 0)
            //{
            //    tMwf = dtX[0].id;
            //}

            
            //Models.PenjaminanDatasetTableAdapters.t_workflowTableAdapter ta = new Models.PenjaminanDatasetTableAdapters.t_workflowTableAdapter();

            //ta.Insert(tMwf, tModeule, tSquence, "Y", textKeterangan.Value, user.id.ToString(), DateTime.Now, null, "0");

            //////buat validasi
            ////PenjaminanDataset.t_workflowDataTable dt = ta.GetDataforAction(tMwf, eID);
            ////if(dt.Count > 0)
            ////{
            ////    ta.Insert(tMwf, tModeule, tSquence, "Y", textKeterangan.Value, user.id.ToString(), DateTime.Now,null,"0");
            ////}

            //string type = "aproove";
            //if (txtCalonMitra.Value == "")
            //{
            //    throw new Exception("Field Calon Mitra is Mandatory");
            //}
            //m_mitra.UpdateStatus(eID,textKeterangan.Value, type);

            
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            string type = "reject";
            if (txtCalonMitra.Value == "")
            {
                throw new Exception("Field Calon Mitra is Mandatory");
            }
            m_mitra.UpdateStatus(eID, textKeterangan.Value, type);

            Response.Redirect("/Penjaminan/ViewMitra.aspx");
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