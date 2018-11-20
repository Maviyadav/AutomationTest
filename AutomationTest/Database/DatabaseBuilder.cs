using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using SQLite;

namespace AutomationTest.Database
{
    public static class DatabaseBuilder
    {
        #region " Database Connection "

        /// <summary>
        /// Get the database connection object through dependency service
        /// </summary>
        /// <returns></returns>
        public static SQLiteConnection GetDbConnection()
        {
            string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Barcode.db3");
            var dbConnection = new SQLiteConnection(dpPath);
            return dbConnection;
        }

        #endregion

        #region " Database Structure "

        public static bool CreateDatabase()
        {
            bool isSucceeded = false;
            try
            {
                GetDbConnection();

                isSucceeded = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return isSucceeded;
        }

        public static bool CreateTables()
        {
            bool isSucceeded = false;
            try
            {
                var dbConnection = GetDbConnection();
                dbConnection.CreateTable<BarcodeTable>();
                isSucceeded = true;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return isSucceeded;
        }

        public static void SaveBarcodeInfo(BarcodeTable BarcodeInfo)
        {
            //GetDbConnection().DeleteAll<BarcodeTable>();
            GetDbConnection().Insert(BarcodeInfo);
        }


        public static List<BarcodeTable> GetBarcodeInfo()
        {
            List<BarcodeTable> lstBarcode = new List<BarcodeTable>();
            try
            {
                var today = DateTime.Now;

                // 21/11/2018 00:36:09   // 21/11/2018 00:41:31
                lstBarcode = GetDbConnection().Table<BarcodeTable>().Where(b => b.InsertedDate < today).ToList<BarcodeTable>();
               
            }
            catch (Exception ex)
            {

            }
            return lstBarcode;
        }

       

        public static void ClearBarcodeInfo()
        {
            GetDbConnection().DeleteAll<BarcodeTable>();
        }

        #endregion

    }
}
