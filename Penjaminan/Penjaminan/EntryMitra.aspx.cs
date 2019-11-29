using Penjaminan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Penjaminan.Models;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;

namespace Penjaminan.Penjaminan
{
    public partial class EntryMitra : System.Web.UI.Page
    {
        int tMitraID = 0;
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
                    bindDataChecklist();
                }
                else if (eType == "edit")
                {
                    bindData(eID);


                }
                else if (eType == "delete")
                {
                    softDeleteData(eID);
                }
                else if (eType == "download")
                {
                    DownloadFile(eID);
                }
            }
           
            lblMenu.Text = "Entry Master Mitra";
            Session["activepage"] = "mitra";
        }
        private void softDeleteData(int id)
        {
            m_mitra.Delete(eID);
            tMitraID = eID;

            //insert and update bidangusaha
            t_bidangusaha.Delete(tMitraID);

            m_pekerjaan.Delete(tMitraID);

            m_pic.Delete(tMitraID);

            m_pemegangsaham.Delete(tMitraID);

            m_bod.Delete(tMitraID);
            m_checklist.Delete(tMitraID);

            Response.Redirect("/Penjaminan/ViewMitra.aspx");
        }
        public void bindData(int id)
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

                    Session.Remove("tBidangUsahaList");
                    Session["tBidangUsahaList"] = bidList1;
                }
                

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

                    Session.Remove("tWorkDoneList");
                    Session["tWorkDoneList"] = workDownList;
                }
               

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

                    Session.Remove("tWorkProgressList");
                    Session["tWorkProgressList"] = workProgressList;
                }
               

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

                    Session.Remove("tPicList");
                    Session["tPicList"] = picList;
                }
               

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

                    Session.Remove("tPemegangSahamList");
                    Session["tPemegangSahamList"] = SahamList;
                }
               

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

                    Session.Remove("tBodList");
                    Session["tBodList"] = BODList;
                }
               

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

                    Session.Remove("documentDt");
                    Session["documentDt"] = checkList;
                }
               
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
        protected void bindDataChecklist()
        {
            if(Session["documentDt"] != null)
            {
                Session.Remove("documentDt");
            }

            Models.PenjaminanViewDatasetTableAdapters.DocumentViewTableAdapter ta = new Models.PenjaminanViewDatasetTableAdapters.DocumentViewTableAdapter();
            List<Object.Checklist> checkList = new List<Object.Checklist>();
            foreach(PenjaminanViewDataset.DocumentViewRow dr in ta.GetData())
            {
                Object.Checklist check = new Object.Checklist();               
                check.name = dr.name;
                check.kategoriname = dr.kategoriName;
                check.FileName = "";               
                checkList.Add(check);                
            }

            Session["documentDt"] = checkList;
            
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
            if(fileName != "")
            {
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.End();
            }
            var eMaster = Request.QueryString["eTypeMaster"];
            eMaster = "edit";            
            Response.Redirect("/Penjaminan/EntryMitra.aspx?eID=" + tfkMitra + "&eType=" + eMaster);
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int tMitraID = 0;

            //ini untuk nyimpen session nya si mitra ya
            List<Object.m_mitra> mitraList = new List<Object.m_mitra>();
            Object.m_mitra mitra = new Object.m_mitra();

            if (Session["tMitra"] != null)
            {
                mitraList.AddRange((List<Object.m_mitra>)Session["tMitra"]);
            }
            //end 

            string status = "";
            if (txtCalonMitra.Value == "")
            {
                throw new Exception("Field Calon Mitra is Mandatory");
            }

            if ((!txtStatusB.Checked && !txtStatusE.Checked) || (txtStatusB.Checked && txtStatusE.Checked))
            {
                throw new Exception("Field Status Mitra is Mandatory");
            }
            else
            {
                status = txtStatusB.Checked ? "B" : "L";
            }

            if (txtLatarBelakang.Value == "")
            {
                throw new Exception("Field latar belakang is Mandatory");
            }

            using (TransactionScope tr = new TransactionScope())
            {
               
                try
                {
                    //insert and update mitra
                    if (eType == "add")
                    {
                        tMitraID = m_mitra.insertData(txtCalonMitra.Value, txtLatarBelakang.Value, status);
                    }
                    else
                    {
                        m_mitra.Update(eID, txtCalonMitra.Value, txtLatarBelakang.Value, status);
                        tMitraID = eID;
                    }
                   
                    //insert and update bidangusaha
                    t_bidangusaha.insertData((List<Object.t_bidangusaha>)Session["tBidangUsahaList"], tMitraID);

                    m_pekerjaan.insertData((List<Object.WorkDone2>)Session["tWorkDoneList"], (List<Object.WorkProgress>)Session["tWorkProgressList"], tMitraID);

                    m_pic.insertData((List<Object.Pic>)Session["tPicList"], tMitraID);

                    m_pemegangsaham.insertData((List<Object.PemegangSaham>)Session["tPemegangSahamList"], tMitraID);

                    m_bod.insertData((List<Object.BoardOfDirector>)Session["tBodList"], tMitraID);

                    //<<-- START -->>
                    //insert
                    if (eType == "add")
                    {
                        Models.PenjaminanDatasetTableAdapters.m_checklistTableAdapter ta = new Models.PenjaminanDatasetTableAdapters.m_checklistTableAdapter();
                        fuSample.DataBind();
                        int c = 0;
                        foreach (var data in ((List<Object.Checklist>)Session["documentDt"]))
                        {

                            try
                            {
                                byte[] dataType = new byte[0];
                                int Size = 0;
                                var kukuk = fuSample.FileName;
                                string FileName = "";
                                var kukuruyuk = fuSample.PostedFiles[c].FileName;

                                if (fuSample.HasFile)
                                {
                                    HttpPostedFile file = fuSample.PostedFile;
                                    BinaryReader br = new BinaryReader(fuSample.PostedFiles[c].InputStream);
                                    dataType = br.ReadBytes(file.ContentLength);
                                    Size = fuSample.PostedFiles[c].ContentLength;
                                    FileName = file.FileName;

                                    ta.InsertQuery(tMitraID, data.id, kukuruyuk, data.kategoriname, 1, DateTime.Now, 1, DateTime.Now, "0", Size, dataType);
                                }
                                else
                                {
                                    ta.InsertQuery(tMitraID, c + 1, kukuruyuk, data.kategoriname, 1, DateTime.Now, 1, DateTime.Now, "0", Size, dataType);
                                }
                                c++;
                            }
                            catch (Exception ex)
                            {
                                throw new ApplicationException(ex.Message, ex);
                            }
                        }

                    }
                    else //-->> buat update ceklist
                    {
                        Models.PenjaminanDatasetTableAdapters.m_checklistTableAdapter ta = new Models.PenjaminanDatasetTableAdapters.m_checklistTableAdapter();
                        fuSample.DataBind();
                        int c = 0;
                        foreach (var data in ((List<Object.Checklist>)Session["documentDt"]))
                        {

                            try
                            {
                                byte[] dataType = new byte[0];
                                int Size = 0;
                                var kukuk = fuSample.PostedFiles[c].FileName;

                                if (kukuk != "")
                                {

                                    HttpPostedFile file = fuSample.PostedFiles[c];
                                    BinaryReader br = new BinaryReader(fuSample.PostedFiles[c].InputStream);
                                    dataType = br.ReadBytes(file.ContentLength);
                                    Size = fuSample.PostedFiles[c].ContentLength;
                                    int newID = data.id;
                                    PenjaminanDataset.m_checklistDataTable dt = ta.GetDataByIdForEdit(newID);
                                    if (dt != null)
                                    {
                                        ta.UpdateQuery(kukuk, 2, DateTime.Now, Size, dataType, data.id);
                                    }
                                    else
                                    {
                                        ta.InsertQuery(tMitraID, data.id, kukuk, data.kategoriname, 1, DateTime.Now, 1, DateTime.Now, "0", Size, dataType);
                                    }

                                }
                                c++;
                            }
                            catch (Exception ex)
                            {
                                throw new ApplicationException(ex.Message, ex);
                            }
                        }
                    }


                    //<<-- END LAH -->>                   

                    tr.Complete();
                    tr.Dispose();
                    Session.Remove("tBidangUsahaList");
                    Session.Remove("tWorkDoneList");
                    Session.Remove("tWorkProgressList");
                    Session.Remove("tPicList");
                    Session.Remove("tPemegangSahamList");
                    Session.Remove("tBodList");
                    }
                    catch (Exception ex)
                    {
                        //Rollback
                        tr.Dispose();
                        throw ex;
                    }
                }

                              
          

            Session.Remove("tMitra");
            Session["tMitra"] = mitraList;

            Response.Redirect("/Penjaminan/ViewMitra.aspx");
        }
        protected void btnCancle_Click(object sender, EventArgs e)
        {
            Session.Remove("tBidangUsahaList");
            Session.Remove("tWorkDoneList");
            Session.Remove("tWorkProgressList");
            Session.Remove("tPicList");
            Session.Remove("tPemegangSahamList");
            Session.Remove("tBodList");
            
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