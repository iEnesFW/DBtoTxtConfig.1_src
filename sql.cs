using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.IO;
using System.Collections;
using MyIni;
using Textdata;


namespace sql
{
    class sqlClass
    {

        
        
        private static SqlConnection Connect()
        {
              
            try
            {
                 IniFile ini = new IniFile();
                 SqlConnection db = new SqlConnection("Data Source=" + ini.getSetting("Host", "CONNECTION") + ";Initial Catalog=" + ini.getSetting("Db", "CONNECTION") + ";User ID=" + ini.getSetting("User", "CONNECTION") + ";Password=" + ini.getSetting("Pass", "CONNECTION"));
                 db.Open();
                 //Console.WriteLine("Connected!");
         
                return db;
            }
            catch
            {
                Console.WriteLine("Cannot Connect! Check Settings.ini");
            }
            return new SqlConnection();


         
        }

        public SqlDataReader query(string q)
        {

             SqlCommand cmd = new SqlCommand(q , Connect());
             SqlDataReader reader = cmd.ExecuteReader();


             return reader;
         
        }





    }
}
