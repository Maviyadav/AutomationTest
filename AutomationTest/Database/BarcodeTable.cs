using System;
using SQLite;

namespace AutomationTest.Database
{
    public class BarcodeTable     {          [PrimaryKey, AutoIncrement, Column("_Id")]         public int Id         {             get;             set;         } // AutoIncrement and set primarykey  
        public string Barcode         {             get;             set;         }          public string Height         {             get;             set;         }          public string Width         {             get;             set;         }          public string Depth         {             get;             set;         }

        public DateTime InsertedDate
        {
            get;
            set;
        }

    }
}
