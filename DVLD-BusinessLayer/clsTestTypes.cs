using System;
using System.Data;
using System.Diagnostics;
using System.Runtime.InteropServices.WindowsRuntime;
using DVLD_DataAccessLayer;
using Microsoft.Win32;

namespace DVLD_BusinessLayer
{
    public class clsTestTypes
    {
        public enum enMode { AddNew = 0,Update =1};

        public enMode Mode = enMode.AddNew;
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Fees { get; set; }

        public clsTestTypes()
        {
            ID = -1;
            Title = "";
            Description = "";
            Fees = 0;
            Mode = enMode.AddNew;
        }

        private clsTestTypes(int ID,string Title,string Description,decimal Fees)
        {
            this.ID = ID;
            this.Title = Title;
            this.Description = Description;
            this.Fees = Fees;
            Mode = enMode.Update;
        }

        public static DataTable GetAllTestTypes()
        {
            return clsTestTypesData.GetAllTestTypes();
        }

        public static clsTestTypes Find(int ID)
        {
            string Title = "", Description = "";
            decimal Fees = 0;

            bool isFound = clsTestTypesData.GetTestTypeInfoByID(ID, ref Title, ref Description, ref Fees);

            if (isFound)
            {
                return new clsTestTypes(ID, Title, Description, Fees);
            }
            else
            {
                return null;
            }
        }

        private bool _AddNewTestType()
        {
            //Code here 
            return false;
        }

        private bool _UpdateTestTyep()
        {
            return clsTestTypesData.UpdateTestType(this.ID, this.Title, this.Description, this.Fees);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTestType())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateTestTyep();
                    
            }

            return false;
        }
    }
}
