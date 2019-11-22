using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penjaminan.Models
{
    class UserProfile
    {
        public static PenjaminanDataset.UserProfileRow selectUserProfileByID(int id)
        {
            PenjaminanDatasetTableAdapters.UserProfileTableAdapter ta = new PenjaminanDatasetTableAdapters.UserProfileTableAdapter();
            PenjaminanDataset.UserProfileDataTable dt = new PenjaminanDataset.UserProfileDataTable();
            PenjaminanDataset.UserProfileRow dr = null;

            try
            {
                ta.FillUserProfileByID(dt, id);

                if (dt.Count > 0)
                {
                    dr = dt[0];
                }

                return dr;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to load user profile data : " + ex.Message);
            }
        }

        public static void UpdateData(int Id, string Username, string Password, int Role, int Division)
        {
            PenjaminanDatasetTableAdapters.UserProfileTableAdapter ta = new PenjaminanDatasetTableAdapters.UserProfileTableAdapter();
            PenjaminanDataset.UserProfileDataTable dt = ta.GetDataUserProfileByID(Id);

            try
            {
                if(dt != null)
                {
                    dt[0].username = Username;
                    dt[0].password = Password;
                    dt[0].role = Role.ToString();
                    dt[0].division = Division.ToString();
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

        public static void InsertData(string Username, string Password, int Role, int Division)
        {
            PenjaminanDatasetTableAdapters.UserProfileTableAdapter ta = new PenjaminanDatasetTableAdapters.UserProfileTableAdapter();

            try
            {
                ta.Insert(Username, Password, Role.ToString(), Division.ToString(), 1, DateTime.Now, 1, DateTime.Now, 0);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
        }

        public static void SoftDeleteData(int id)
        {
            PenjaminanDatasetTableAdapters.UserProfileTableAdapter ta = new PenjaminanDatasetTableAdapters.UserProfileTableAdapter();
            PenjaminanDataset.UserProfileDataTable dt = ta.GetDataUserProfileByID(id);

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

        public static PenjaminanDataset.UserProfileRow getUserLogin(string username, string password)
        {
            PenjaminanDatasetTableAdapters.UserProfileTableAdapter ta = new PenjaminanDatasetTableAdapters.UserProfileTableAdapter();
            PenjaminanDataset.UserProfileDataTable dt = new PenjaminanDataset.UserProfileDataTable();
            PenjaminanDataset.UserProfileRow dr = null;

            try
            {
                ta.FillUserProfileByUsernamePassword(dt, username, password);

                if (dt.Count > 0)
                {
                    dr = dt[0];
                }

                return dr;
            }
            catch(Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
        }
    }
}
