using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;

namespace Penjaminan.Models
{
    public class m_mitra
    {
        public static PenjaminanDataset.m_mitraRow selectID()
        {
            PenjaminanDatasetTableAdapters.m_mitraTableAdapter ta = new PenjaminanDatasetTableAdapters.m_mitraTableAdapter();
            PenjaminanDataset.m_mitraDataTable dt = new PenjaminanDataset.m_mitraDataTable();
            PenjaminanDataset.m_mitraRow dr = null;

            try
            {
                ta.Fill(dt);

                if (dt.Count > 0)
                {
                    dr = dt[0];
                }

                return dr;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to load Mitra data : " + ex.Message);
            }
        }
        public static PenjaminanDataset.m_mitraRow selectMitraByID(int id)
        {
            PenjaminanDatasetTableAdapters.m_mitraTableAdapter ta = new PenjaminanDatasetTableAdapters.m_mitraTableAdapter();
            PenjaminanDataset.m_mitraDataTable dt = new PenjaminanDataset.m_mitraDataTable();
            PenjaminanDataset.m_mitraRow dr = null;

            try
            {
                ta.FillMitraByID(dt, id);

                if (dt.Count > 0)
                {
                    dr = dt[0];
                }

                return dr;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to load Employee data : " + ex.Message);
            }
        }

        public static PenjaminanDataset.m_mitraRow GetIDforAll()
        {
            PenjaminanDatasetTableAdapters.m_mitraTableAdapter ta = new PenjaminanDatasetTableAdapters.m_mitraTableAdapter();
            PenjaminanDataset.m_mitraDataTable dt = new PenjaminanDataset.m_mitraDataTable();
            PenjaminanDataset.m_mitraRow dr = null;

            try
            {
               ta.FillID(dt);
                if (dt.Count > 0)
                {
                    dr = dt[0];
                }
                return dr;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to load Mitra data : " + ex.Message);
            }
        }
        public static int insertData(string nama, string latarbelakang, string status)
        {
            int newID;
            PenjaminanDatasetTableAdapters.m_mitraTableAdapter ta = new PenjaminanDatasetTableAdapters.m_mitraTableAdapter();
           
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                     newID = int.Parse("" + ta.InsertQuerySelect(nama,latarbelakang,status,1,DateTime.Now,DateTime.Now,1,0,"0"));

                    scope.Complete();
                }


                return newID;
            }
            
            catch(Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
                
            }
        }
        public static void Update(int id, string nama, string latarbelakang, string status)
        {
            PenjaminanDatasetTableAdapters.m_mitraTableAdapter ta = new PenjaminanDatasetTableAdapters.m_mitraTableAdapter();
            PenjaminanDataset.m_mitraDataTable dt = ta.GetDataMitraByID(id);

            try
            {
                if (dt != null)
                {

                    dt[0].name = nama;
                    dt[0].latarbelakang = latarbelakang;
                    dt[0].status = status;
                    dt[0].lastupdatedby = 2;
                    dt[0].lastupdateddate = DateTime.Now;
                    //dt[0].NamaDivisi = NamaDivisi;

                    ta.Update(dt);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
        }
        public static void UpdateStatus(int id, string keterangan, string type)
        {
            PenjaminanDatasetTableAdapters.m_mitra1TableAdapter ta = new PenjaminanDatasetTableAdapters.m_mitra1TableAdapter();
            PenjaminanDataset.m_mitra1DataTable dt = ta.GetDataByID(id);

            try
            {
                if (dt != null)
                {
                    if(type == "aproove")
                    {
                        ta.UpdateQuery(2, DateTime.Now, "1", keterangan, id);
                    }
                    else
                    {
                        ta.UpdateQuery(2, DateTime.Now, "2", keterangan, id);
                    }
                   
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
        }
        public static void Delete(int id)
        {
            PenjaminanDatasetTableAdapters.m_mitraTableAdapter ta = new PenjaminanDatasetTableAdapters.m_mitraTableAdapter();
            PenjaminanDataset.m_mitraDataTable dt = ta.GetDataMitraByID(id);

            try
            {
               if (dt.Count > 0)
                {
                    ta.softDelete(1, id);
                }                
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
        }
    }
}