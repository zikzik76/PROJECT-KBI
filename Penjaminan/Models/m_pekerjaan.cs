using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Penjaminan.Models
{
    public class m_pekerjaan
    {
        public static void insertData(List<Object.WorkDone2> a, List<Object.WorkProgress> b, int idMitra)
        {
            PenjaminanDatasetTableAdapters.m_pekerjaanTableAdapter ta = new PenjaminanDatasetTableAdapters.m_pekerjaanTableAdapter();

            foreach (var data in a)
            {
                try
                {
                    if (data.id != 0)
                    {
                        int newID = data.id;
                        PenjaminanDatasetTableAdapters.m_pekerjaanTableAdapter taX = new PenjaminanDatasetTableAdapters.m_pekerjaanTableAdapter();
                        PenjaminanDataset.m_pekerjaanDataTable dt = taX.GetDataPekerjaanByID(newID);
                        try
                        {
                            if (dt != null)
                            {


                                dt[0].namapaket = data.namapaket;
                                dt[0].lokasi = data.lokasi;
                                dt[0].tanggalpelaksanaan = data.tanggalpelaksanaan;
                                dt[0].tanggalserah = data.tanggalserah;
                                dt[0].nilai = data.nilai;
                                dt[0].lastupdatedby = 2;
                                dt[0].lastupdateddate = DateTime.Now;

                                ta.Update(dt);
                                idMitra = data.fk_mitra;
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new ApplicationException(ex.Message, ex);
                        }
                    }
                    else
                    {
                        ta.Insert(idMitra, data.tipe, data.namapaket, data.lokasi, data.tanggalpelaksanaan, data.nilai, data.tanggalserah, 1, DateTime.Now, 1, DateTime.Now, "0");
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException(ex.Message, ex);
                }
            }
            foreach (var data in b)
            {
                try
                {
                    if (data.id != 0)
                    {
                        int newID = data.id;
                        PenjaminanDatasetTableAdapters.m_pekerjaanTableAdapter taX = new PenjaminanDatasetTableAdapters.m_pekerjaanTableAdapter();
                        PenjaminanDataset.m_pekerjaanDataTable dt = taX.GetDataPekerjaanByID(newID);
                        try
                        {
                            if (dt != null)
                            {


                                dt[0].namapaket = data.namapaket;
                                dt[0].lokasi = data.lokasi;
                                dt[0].tanggalpelaksanaan = data.tanggalpelaksanaan;
                                dt[0].tanggalserah = data.tanggalserah;
                                dt[0].nilai = data.nilai;
                                dt[0].lastupdatedby = 2;
                                dt[0].lastupdateddate = DateTime.Now;

                                ta.Update(dt);
                                idMitra = data.fk_mitra;
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new ApplicationException(ex.Message, ex);
                        }
                    }
                    else
                    {
                        ta.Insert(idMitra, data.tipe, data.namapaket, data.lokasi, data.tanggalpelaksanaan, data.nilai, data.tanggalserah, 1, DateTime.Now, 1, DateTime.Now, "0");
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException(ex.Message, ex);
                }
            }
        }
        public static List<PenjaminanDataset.m_pekerjaanRow> selectWDFK(decimal fkBid)
        {
            PenjaminanDatasetTableAdapters.m_pekerjaanTableAdapter ta = new PenjaminanDatasetTableAdapters.m_pekerjaanTableAdapter();
            PenjaminanDataset.m_pekerjaanDataTable dt = new PenjaminanDataset.m_pekerjaanDataTable();

            List<PenjaminanDataset.m_pekerjaanRow> wdList = new List<PenjaminanDataset.m_pekerjaanRow>();
            try
            {
                ta.SelectWorkDownByFk(dt, fkBid);

                if (dt.Count > 0)
                {
                    for (int i = 0; i < dt.Count; i++)
                    {
                        wdList.Add(dt[i]);
                    }
                }

                return wdList;


            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to load Employee data : " + ex.Message);
            }
        }
        public static void Delete(int id)
        {
            PenjaminanDatasetTableAdapters.m_pekerjaanTableAdapter ta = new PenjaminanDatasetTableAdapters.m_pekerjaanTableAdapter();
            PenjaminanDataset.m_pekerjaanDataTable dt = ta.GetDataforDelete(Convert.ToDecimal(id));
            try
            {
                ta.softDelete("1", id);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to load Employee data : " + ex.Message);
            }
        }
        public static List<PenjaminanDataset.m_pekerjaanRow> selectWPFK(decimal fkBid)
        {
            PenjaminanDatasetTableAdapters.m_pekerjaanTableAdapter ta = new PenjaminanDatasetTableAdapters.m_pekerjaanTableAdapter();
            PenjaminanDataset.m_pekerjaanDataTable dt = new PenjaminanDataset.m_pekerjaanDataTable();

            List<PenjaminanDataset.m_pekerjaanRow> wdList = new List<PenjaminanDataset.m_pekerjaanRow>();
            try
            {
                ta.SelectProgresByFk(dt, fkBid);

                if (dt.Count > 0)
                {
                    for (int i = 0; i < dt.Count; i++)
                    {
                        wdList.Add(dt[i]);
                    }
                }

                return wdList;


            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to load Employee data : " + ex.Message);
            }
        }
    }
}