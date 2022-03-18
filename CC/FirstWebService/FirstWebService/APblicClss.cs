using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;


namespace FirstWebService
{
    public class Statcdif
    {
        public static string strConn = "Data Source=10.10.26.4;Initial Catalog=VOCAPlus;Persist Security Info=True;User ID=test1;Password=@VocaPlus$21-1237wxz9";
        public static DataTable EcryptionTbl = new DataTable();                // Datatable To Initialize Encryption Base Table
    }

    public sealed class function : Statcdif
    {
        private static readonly Lazy<function> fn = new Lazy<function>(() => new function());
        public static function getfn
        {
            get
            {
                return fn.Value;
            }
        }
        public static void AppLog(String LogMsg, String ErrCd, String SSqlStrs)                                  //Insert Exception Into Log FIle
        {
            string _path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\VOCALog" + Convert.ToDateTime(DateTime.Now).ToString("MM-yy") + ".Vlg";
            string _content = DateTime.Now + "," + encrypt(LogMsg) + "$" + encrypt(ErrCd) + "$" + encrypt(SSqlStrs) + Environment.NewLine;
            File.AppendAllText(_path, _content);
        }
        public static string encrypt(string EncryptedString)
        {
            Random rnd = new Random();                      // Encryption Random
            int intKey;
            string author = EncryptedString;
            // Convert a C# string to a byte array  
            string Separtor = "₨";                          // Encryption Separator
                                                            // Get Bytes from String 
            byte[] bytes = Encoding.UTF8.GetBytes(EncryptedString);
            List<string> encryptList = new List<string>();
            foreach (byte b in bytes)
            {
                intKey = rnd.Next(1, 10);                                       // creates a number between 1 and 9
                DataRow DRW1 = DRW(EcryptionTbl, intKey, EcryptionTbl.Columns[0]);        // Get Symbole from table based on Random int from 1 - 9
                encryptList.Add((b * intKey).ToString() + DRW1.ItemArray[1]);    // store in String List the result of random * byte & Symbole
            }
            string Encrypted = string.Join(Separtor, encryptList);              // Join string list using Separator "₨"
            return Encrypted;                                                   // Return Ecrypted String
        }
        public static void populateEncryptTbl()
        {
            EcryptionTbl.Columns.Add("key", typeof(int));            // Add two Columns to the Ecryption Table
            EcryptionTbl.Columns.Add("Cahr_");
            EcryptionTbl.Rows.Add(1, "℠");                           // Add Encryption Rows to the Ecryption Table
            EcryptionTbl.Rows.Add(2, "℆");
            EcryptionTbl.Rows.Add(3, "§");
            EcryptionTbl.Rows.Add(4, "№");
            EcryptionTbl.Rows.Add(5, "¥");
            EcryptionTbl.Rows.Add(6, "℀");
            EcryptionTbl.Rows.Add(7, "₡");
            EcryptionTbl.Rows.Add(8, "₯");
            EcryptionTbl.Rows.Add(9, "₠");
        }
        public static string discrypt(string DiscryptedString)
        {

            string[] Encripted = DiscryptedString.Split('₨');
            byte[] discripted = new byte[Encripted.Length];
            for (int i = 0; i < Encripted.Length; i++)
            {
                string Sympole = Encripted[i].ToString().Substring(Encripted[i].ToString().Length - 1, 1);                               // Splite symbole from string
                string byte_ = Encripted[i].ToString().Substring(0, Encripted[i].ToString().Length - 1);                                 // Splite Byte from string
                DataRow DRW1 = DRW(EcryptionTbl, Sympole, EcryptionTbl.Columns[1]);        // Get int from Encryption Table based on Symbole from
                int OriginalByte = Convert.ToInt32(byte_) / Convert.ToInt32(DRW1.ItemArray[0]);     // Return the Original Byte with by Operation
                discripted[i] = (byte)OriginalByte;
            }

            return Encoding.UTF8.GetString(discripted);
        }
        public static DataRow DRW(DataTable tbl, object key, DataColumn col)
        {
            tbl.PrimaryKey = new DataColumn[] { col };
            DataRow DRW = tbl.Rows.Find(key);

            return DRW;
        }

    }
}