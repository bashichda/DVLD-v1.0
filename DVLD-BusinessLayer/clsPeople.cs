using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;

namespace DVLD_BusinessLayer
{
    public class clsPeople
    {
        public enum enGendor { Male = 0, Female = 1};
        public enum enMode { AddNew = 0, Update = 1};

        public enMode Mode = enMode.AddNew;

        public int PersonID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NationalCountryID { get; set; }
        public string ImagePath { get; set; }


        public clsPeople()
        {
            PersonID = -1;
            NationalNo = "";
            FirstName = "";
            SecondName = "";
            ThirdName = "";
            LastName = "";
            DateOfBirth = DateTime.Now;
            Gender = 0;
            Address = "";
            Phone = "";
            Email = "";
            NationalCountryID = -1;
            ImagePath = "";
            Mode = enMode.AddNew;
        }

        private clsPeople(int PersonID,string NationalNo,string FirstName,string SecondName,string ThirdName,string LastName,
            DateTime DateOfBirth,int Gender,string Address,string Phone,string Email,int NationalityCountryID,string ImagePath)
        {
            this.PersonID = PersonID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gender = Gender;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.NationalCountryID = NationalityCountryID;
            this.ImagePath = ImagePath;

            Mode = enMode.Update;
        }

        public static DataTable GetAllPeopleInfoList()
        {
            return clsPeopleDataAccess.GetAllPeopleList();
        }

        public static bool IsExistByNationalNo(string NationalNo)
        {
            return clsPeopleDataAccess.isExistByNationalNo(NationalNo);
        }

        private bool _AddNewPerson()
        {
            this.PersonID = clsPeopleDataAccess.AddNewPerson(this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName,
                this.DateOfBirth, this.Gender, this.Address, this.Phone, this.Email, this.NationalCountryID, this.ImagePath);

            return (this.PersonID != -1);

        }

        private bool _UpdatePerson()
        {
            return clsPeopleDataAccess.Update(this.PersonID, this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName,
                this.DateOfBirth, this.Gender, this.Address, this.Phone, this.Email, this.NationalCountryID, this.ImagePath);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdatePerson();

            }
            return false;
        }

        public static clsPeople Find(int PersonID)
        {
            string NationalNo = "", FirstName = "", SecondName = "", ThirdName = "", LastName = "",
                Address = "", Email = "", Phone = "", ImagePath = "";
            int NationalityCountryID = -1, Gender = 0;
            DateTime DateOfBirth = DateTime.Now;

            if (clsPeopleDataAccess.Find(PersonID,ref NationalNo,ref FirstName,ref SecondName,ref ThirdName,
                ref LastName,ref DateOfBirth,ref Gender,ref Address,ref Phone,ref Email,ref NationalityCountryID,ref ImagePath))
            {
                return new clsPeople(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gender, Address, Phone, Email, NationalityCountryID,
                    ImagePath);
            }
            else
            {
                return null;
            }
        }

        public static bool Delete(int PersonID)
        {
            return clsPeopleDataAccess.Delete(PersonID);
        }
    }
}
