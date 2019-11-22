using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace Penjaminan.Models
{
    public class t_bidangusaha
    {
        public static void insertData(List<Object.t_bidangusaha> b, int idMitra)
        {
            PenjaminanDatasetTableAdapters.t_bidangusahaTableAdapter ta = new PenjaminanDatasetTableAdapters.t_bidangusahaTableAdapter();
            
            foreach (var data in b)
            {
                try
                {
                    if(data.fk_bidangusaha != 0 && data.id != 0)
                    {
                        int newID = data.id;
                        PenjaminanDatasetTableAdapters.t_bidangusahaTableAdapter taX = new PenjaminanDatasetTableAdapters.t_bidangusahaTableAdapter();
                        PenjaminanDataset.t_bidangusahaDataTable dt = taX.GetDataByID(newID);
                        try
                        {
                            if (dt != null)
                            {
                                

                                dt[0].fk_bidangusaha =Convert.ToInt32(data.fk_bidangusaha);
                                dt[0].lastupdatedby = 2;
                                dt[0].lastupdateddate = DateTime.Now;     
                                                          
                                ta.Update(dt);
                                idMitra = Convert.ToInt32(data.fk_mitra);
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new ApplicationException(ex.Message, ex);
                        }
                    }
                    else
                    {
                        ta.InsertQuery(data.fk_bidangusaha, idMitra, 1, DateTime.Now, 1, DateTime.Now, 0);
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
            PenjaminanDatasetTableAdapters.t_bidangusahaTableAdapter taX = new PenjaminanDatasetTableAdapters.t_bidangusahaTableAdapter();
            PenjaminanDataset.t_bidangusahaDataTable dt = taX.GetForDelete(fkMitra);
            try
            {
                taX.softDelete(1, fkMitra);              
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }                       
        }
        public static List<PenjaminanViewDataset.m_bidangusahaRow> selectByFK(decimal fkBid)
        {
            PenjaminanViewDatasetTableAdapters.m_bidangusahaTableAdapter ta = new PenjaminanViewDatasetTableAdapters.m_bidangusahaTableAdapter();
            PenjaminanViewDataset.m_bidangusahaDataTable dt = new PenjaminanViewDataset.m_bidangusahaDataTable();
      
            List<PenjaminanViewDataset.m_bidangusahaRow> bidList = new List<PenjaminanViewDataset.m_bidangusahaRow>();
            try
            {
                ta.Fill(dt, fkBid);

                if (dt.Count > 0)                   
                {
                    for (int i =0; i < dt.Count; i++)
                    {
                        bidList.Add(dt[i]);
                    }                    
                }

                return bidList;

               
                }            
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to load Employee data : " + ex.Message);
            }
        }
        public static void Update(List<Object.t_bidangusaha> b,int idMitra)
        {
            PenjaminanDatasetTableAdapters.t_bidangusahaTableAdapter ta = new PenjaminanDatasetTableAdapters.t_bidangusahaTableAdapter();

            foreach (var data in b)
            {                
                try
                {
                    ta.InsertQuery(data.fk_bidangusaha, idMitra, 1, DateTime.Now, 1, DateTime.Now, 0);

                }
                catch (Exception ex)
                {
                    throw new ApplicationException(ex.Message, ex);
                }
            }

        }
        public static void insertDataSatuan(List<Object.t_bidangusaha> b, int idMitra)
        {
            PenjaminanDatasetTableAdapters.t_bidangusahaTableAdapter ta = new PenjaminanDatasetTableAdapters.t_bidangusahaTableAdapter();

            foreach (var data in b)
            {
                try
                {
                    ta.InsertQuery(data.fk_bidangusaha, idMitra, 1, DateTime.Now, 1, DateTime.Now, 0);

                }
                catch (Exception ex)
                {
                    throw new ApplicationException(ex.Message, ex);
                }
            }

        }
    }
}