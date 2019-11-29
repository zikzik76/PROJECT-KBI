using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Penjaminan.Models
{
    public class tPage
    {
        public static PenjaminanDataset.tPageRow SelectByName(string Nama)
        {
            PenjaminanDatasetTableAdapters.tPageTableAdapter ta = new PenjaminanDatasetTableAdapters.tPageTableAdapter();
            PenjaminanDataset.tPageDataTable dt = new PenjaminanDataset.tPageDataTable();
            PenjaminanDataset.tPageRow dr = null;

            try
            {
                ta.FillByName(dt, Nama);

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

        public static PenjaminanDataset.tPageRow selectPageByID(int id)
        {
            PenjaminanDatasetTableAdapters.tPageTableAdapter ta = new PenjaminanDatasetTableAdapters.tPageTableAdapter();
            PenjaminanDataset.tPageDataTable dt = new PenjaminanDataset.tPageDataTable();
            PenjaminanDataset.tPageRow dr = null;

            try
            {
                ta.FillByID(dt, id);

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
        public static void SoftDeleteData(int id)
        {
            PenjaminanDatasetTableAdapters.tPageTableAdapter ta = new PenjaminanDatasetTableAdapters.tPageTableAdapter();
            PenjaminanDataset.tPageDataTable dt = ta.GetDataByID(id);

            try
            {
                if (dt != null)
                {
                    dt[0].deleted = "1";

                    ta.Update(dt);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
        }
        public static void UpdateData(int Id, string Name, string control, string icon, string active, int menuparent)
        {
            PenjaminanDatasetTableAdapters.tPageTableAdapter ta = new PenjaminanDatasetTableAdapters.tPageTableAdapter();
            PenjaminanDataset.tPageDataTable dt = ta.GetDataByID(Id);

            try
            {
                if (dt != null)
                {
                    dt[0].name = Name;
                    dt[0].control = control;
                    dt[0].icon =icon;
                    dt[0].active = active;
                    dt[0].menuparent = menuparent;
                    dt[0].creby = "1";
                    dt[0].credate = DateTime.Now;

                    ta.Update(dt);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
        }

        public static void InsertData(string Name, string control, string icon, string active,int menuparent)
        {
            PenjaminanDatasetTableAdapters.tPageTableAdapter ta = new PenjaminanDatasetTableAdapters.tPageTableAdapter();

            try
            {
                ta.Insert(Name, control,active,icon, "1", DateTime.Now, null,null, "0",menuparent);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
        }

    }
}