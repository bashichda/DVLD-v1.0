using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;


namespace DVLD_BusinessLayer
{
    public class clsUsers
    {
        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public clsUsers()
        {
            UserID = -1;
            PersonID = -1;
            UserName = "";
            Password = "";
            IsActive = false;
        }

        private clsUsers(int UserID,int PersonID,string UserName,string Password,bool IsActive)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.UserName = UserName;
            this.Password = Password;
            this.IsActive = IsActive;
        }

        public static clsUsers Find(string UserName,string Password)
        {
            int UserID = -1, PersonID = -1;
            bool IsActive = false;

            if (clsUsersDataAccess.Find(ref UserID,ref PersonID,UserName,Password,ref IsActive))
            {
                return new clsUsers(UserID, PersonID, UserName, Password, IsActive);
            }
            else
            {
                return null;
            }
        }

        public static DataTable GetAllUsersInfo()
        {
            return clsUsersDataAccess.GetAllUsersInfo();
        }

    }
}
