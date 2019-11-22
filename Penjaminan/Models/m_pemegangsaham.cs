using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Penjaminan.Models
{
    public class m_pemegangsaham
    {
        public static void insertData(List<Object.PemegangSaham> b, int idMitra)
        {
            PenjaminanDatasetTableAdapters.m_pemegangsahamTableAdapter ta = new PenjaminanDatasetTableAdapters.m_pemegangsahamTableAdapter();

            foreach (var data in b)
            {
                try
                {
                    if (data.id != 0)
                    {
                        int newID = data.id;
                        PenjaminanDatasetTableAdapters.m_pemegangsahamTableAdapter taX = new PenjaminanDatasetTableAdapters.m_pemegangsahamTableAdapter();
                        PenjaminanDataset.m_pemegangsahamDataTable dt = taX.GetDataByID(newID);
                        try
                        {
                            if (dt != null)
                            {
                                ta.UpdateQuery(data.name, data.jumlah,data.total,data.persentase,DateTime.Now,2,data.id);
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
                        ta.InsertQuerypemegangsaham(idMitra, data.name, data.jumlah, data.total, data.persentase, 1, DateTime.Now, DateTime.Now, 0, 1);
                    }

                }
                catch (Exception ex)
                {
                    throw new ApplicationException(ex.Message, ex);
                }
            }

        }
        public static void Delete(int fkMitra)
        {
            PenjaminanDatasetTableAdapters.m_pemegangsahamTableAdapter taX = new PenjaminanDatasetTableAdapters.m_pemegangsahamTableAdapter();
            PenjaminanDataset.m_pemegangsahamDataTable dt = taX.GetDataByFkMitra(Convert.ToDecimal(fkMitra));
            try
            {
                taX.softDelete(1, fkMitra);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
        }
        public static List<PenjaminanDataset.m_pemegangsahamRow> selectSahamFK(decimal fk)
        {
            PenjaminanDatasetTableAdapters.m_pemegangsahamTableAdapter ta = new PenjaminanDatasetTableAdapters.m_pemegangsahamTableAdapter();
            PenjaminanDataset.m_pemegangsahamDataTable dt = new PenjaminanDataset.m_pemegangsahamDataTable();

            List<PenjaminanDataset.m_pemegangsahamRow> SahamList = new List<PenjaminanDataset.m_pemegangsahamRow>();
            try
            {
                ta.FillByFkMitra(dt, fk);

                if (dt.Count > 0)
                {
                    for (int i = 0; i < dt.Count; i++)
                    {
                        SahamList.Add(dt[i]);
                    }
                }

                return SahamList;


            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to load Employee data : " + ex.Message);
            }
        }
    }
}