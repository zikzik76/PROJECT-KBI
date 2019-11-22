using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Penjaminan.Models
{
    public class u_role
    {
        public static PenjaminanDataset.u_roleRow selectRoleByID(int id)
        {
            PenjaminanDatasetTableAdapters.u_roleTableAdapter ta = new PenjaminanDatasetTableAdapters.u_roleTableAdapter();
            PenjaminanDataset.u_roleDataTable dt = new PenjaminanDataset.u_roleDataTable();
            PenjaminanDataset.u_roleRow dr = null;

            try
            {
                ta.FillRoleByID(dt, id);

                if (dt.Count > 0)
                {
                    dr = dt[0];
                }

                return dr;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to load role data : " + ex.Message);
            }
        }
        public static PenjaminanDataset.u_roleRow selectIDByRole(string Nama)
        {
            PenjaminanDatasetTableAdapters.u_roleTableAdapter ta = new PenjaminanDatasetTableAdapters.u_roleTableAdapter();
            PenjaminanDataset.u_roleDataTable dt = new PenjaminanDataset.u_roleDataTable();
            PenjaminanDataset.u_roleRow dr = null;

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
        public static void UpdateData(int Id, string Name, string Description)
        {
            PenjaminanDatasetTableAdapters.u_roleTableAdapter ta = new PenjaminanDatasetTableAdapters.u_roleTableAdapter();
            PenjaminanDataset.u_roleDataTable dt = ta.GetDataRoleByID(Id);

            try
            {
                if (dt != null)
                {
                    dt[0].name = Name;
                    dt[0].description = Description;
                    dt[0].lastupdatedby = 1;
                    dt[0].lastupdateddate = DateTime.Now;

                    ta.Update(dt);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
        }

        public static void InsertData(string Name, string Description)
        {
            PenjaminanDatasetTableAdapters.u_roleTableAdapter ta = new PenjaminanDatasetTableAdapters.u_roleTableAdapter();

            try
            {
                ta.Insert(Name, Description, 1, DateTime.Now, 1, DateTime.Now, 0);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
        }

        public static void SoftDeleteData(int id)
        {
            PenjaminanDatasetTableAdapters.u_roleTableAdapter ta = new PenjaminanDatasetTableAdapters.u_roleTableAdapter();
            PenjaminanDataset.u_roleDataTable dt = ta.GetDataRoleByID(id);

            try
            {
                if (dt != null)
                {
                    dt[0].deleted = 1;

                    ta.Update(dt);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
        }
    }
}