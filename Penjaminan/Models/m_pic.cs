using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Penjaminan.Models
{
    public class m_pic
    {
        public static void insertData(List<Object.Pic> b, int idMitra)
        {
            PenjaminanDatasetTableAdapters.m_picTableAdapter ta = new PenjaminanDatasetTableAdapters.m_picTableAdapter();
           

            foreach (var data in b)
            {
                try
                {
                    if (data.id != 0)
                    {
                        int newID = data.id;
                        PenjaminanDatasetTableAdapters.m_picTableAdapter taX = new PenjaminanDatasetTableAdapters.m_picTableAdapter();
                        PenjaminanDataset.m_picDataTable dt = taX.GetDataPicByID(newID);
                        try
                        {
                            if (dt != null)
                            {

                                ta.UpdateQuery(data.name,data.jabatan,2,DateTime.Now,data.noTelepon,data.id);
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
                        ta.InsertPIC(idMitra, data.name, data.jabatan, 1, DateTime.Now, 1, DateTime.Now, 0, data.noTelepon, data.email);
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException(ex.Message, ex);
                }
            }

        }
        public static void Delete(int id)
        {
            PenjaminanDatasetTableAdapters.m_picTableAdapter ta = new PenjaminanDatasetTableAdapters.m_picTableAdapter();
            PenjaminanDataset.m_picDataTable dt = ta.GetDataByFKMitra(Convert.ToDecimal(id));
            try
            {
                ta.softDelete(1, id);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to load Employee data : " + ex.Message);
            }
        }
        public static List<PenjaminanDataset.m_picRow> selectPICFK(decimal fk)
        {
            PenjaminanDatasetTableAdapters.m_picTableAdapter ta = new PenjaminanDatasetTableAdapters.m_picTableAdapter();
            PenjaminanDataset.m_picDataTable dt = new PenjaminanDataset.m_picDataTable();

            List<PenjaminanDataset.m_picRow> picLIst = new List<PenjaminanDataset.m_picRow>();
            try
            {
                ta.FillByFKMitra(dt, fk);

                if (dt.Count > 0)
                {
                    for (int i = 0; i < dt.Count; i++)
                    {
                        picLIst.Add(dt[i]);
                    }
                }

                return picLIst;


            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to load Employee data : " + ex.Message);
            }
        }
    }
}