using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Penjaminan.Models
{
    public class m_bod
    {
        public static void insertData(List<Object.BoardOfDirector> b, int idMitra)
        {
            PenjaminanDatasetTableAdapters.m_bodTableAdapter ta = new PenjaminanDatasetTableAdapters.m_bodTableAdapter();

            foreach (var data in b)
            {
                try
                {
                    if (data.id != 0)
                    {
                        int newID = data.id;
                        PenjaminanDatasetTableAdapters.m_bod2TableAdapter taX = new PenjaminanDatasetTableAdapters.m_bod2TableAdapter();
                        PenjaminanDataset.m_bod2DataTable dt = taX.GetDataByID(newID);
                        try
                        {
                            if (dt != null)
                            {
                                dt[0].name = data.name;
                                dt[0].jabatan = data.jabatan;                               
                                dt[0].lastupdatedby = 2;
                                dt[0].lastupdateddate = DateTime.Now;

                                taX.UpdateQuery(data.tglLahir, DateTime.Now, 2, data.jabatan, data.name, data.id);
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
                        ta.Insert(idMitra, data.name, data.jabatan, 1, DateTime.Now, 1, DateTime.Now, "0", data.tglLahir);
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
            PenjaminanDatasetTableAdapters.m_bod2TableAdapter taX = new PenjaminanDatasetTableAdapters.m_bod2TableAdapter();
            PenjaminanDatasetTableAdapters.m_bodTableAdapter ta = new PenjaminanDatasetTableAdapters.m_bodTableAdapter();
            PenjaminanDataset.m_bod2DataTable dt = taX.GetDataforDelete(Convert.ToDecimal(fkMitra));
            try
            {
                if (dt != null)
                {
                    ta.softDelete("1", fkMitra);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
        }
        public static List<PenjaminanDataset.m_bod1Row> selectBODFK(decimal fk)
        {
            PenjaminanDatasetTableAdapters.m_bod1TableAdapter ta = new PenjaminanDatasetTableAdapters.m_bod1TableAdapter();
            PenjaminanDataset.m_bod1DataTable dt = new PenjaminanDataset.m_bod1DataTable();

            List<PenjaminanDataset.m_bod1Row> bodList = new List<PenjaminanDataset.m_bod1Row>();
            try
            {
                ta.FillBy(dt, fk);

                if (dt.Count > 0)
                {
                    for (int i = 0; i < dt.Count; i++)
                    {
                        bodList.Add(dt[i]);
                    }
                }

                return bodList;


            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to load Employee data : " + ex.Message);
            }
        }
    }
}