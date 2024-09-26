using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Collections;
using sql;
using Decrypter;
namespace Textdata
{
    class dep
    {


        private System.IO.StreamWriter file;
        public void openTxt(string src)
        {
            file = new System.IO.StreamWriter("Media/" + src, true, System.Text.Encoding.Unicode);

        }
        public void closeTxt()
        {
            file.Close();

        }
        public void txtWrite(string str , bool line)
        {

            if (line != true)
                file.Write(str + "	");
            else
                file.WriteLine(str);
        }
        public void txtClear(string src)
        {
            for (int i = 0; i < 51; i++)
            {
                FileInfo fi = new FileInfo("Media/" + src);
                fi.Delete();

            }
        }
        public void getAndWrite(string query)
        {
        sqlClass db = new sqlClass();
           var reader = db.query(query);
            
                        do
                        {
                            int count = reader.FieldCount;
                            while (reader.Read())
                            {
                                for (int i = 0; i < count; i++)
                                {
                                    txtWrite(reader.GetValue(i).ToString(), false);
                                    //Console.Write(reader.GetValue(i).ToString() + "	");
                                }
                                //Console.Write("\r");
                                txtWrite("", true);
                         
                            }
                        } while (reader.NextResult());
            
        }
        private void writeBytes(string file, byte[] array)
        {
            try
            {

                byte[] enc = { 0x0d, 0x00, 0x0a, 0x00, 0x2f, 0x00, 0x2f, 0x00, 0x65, 0x00, 0x6e, 0x00, 0x63, 0x00, 0x72, 0x00, 0x79, 0x00, 0x70, 0x00, 0x74, 0x00 };
                using (var stream = new FileStream("Media/" + file, FileMode.Append))
                {
                    stream.Write(array, 0, array.Length);
                    stream.Write(enc, 0, enc.Length);
                    Console.WriteLine("Media/" + file);
                    stream.Close();
                }



            }
            catch
            {
                Console.WriteLine("Cant encode");
            }
    
        

        }
        public bool skillDataENC()
        {

            byte[] s1 = { 0x47, 0x4F, 0x91, 0xF2 };
            byte[] s2 = { 0x82, 0xD5, 0x12, 0x7F };
            byte[] s3 = { 0x78, 0x87, 0xce, 0x6b };
            byte[] s4 = { 0x11, 0x5a, 0x56, 0x5d };
            byte[] s5 = { 0x12, 0x33, 0x0f, 0x5d };
            byte[] s6 = { 0x6e, 0x59, 0x5c, 0xbf };
            byte[] s7 = { 0x69, 0xf2, 0xa5, 0x31 };
            try
            {
                Decrypt enc = new Decrypt();
               
                enc.ReadAndDecryptFile("Media\\skilldata_5000.txt");
                enc.SaveFile(@"Media\\skilldata_5000enc.txt");
                writeBytes("skilldata_5000enc.txt", s1);
                enc.ReadAndDecryptFile("Media\\skilldata_10000.txt");
                enc.SaveFile(@"Media\\skilldata_10000enc.txt");
                writeBytes("skilldata_10000enc.txt", s2);
                enc.ReadAndDecryptFile("Media\\skilldata_15000.txt");
                enc.SaveFile(@"Media\\skilldata_15000enc.txt");
                writeBytes("skilldata_15000enc.txt", s3);
                enc.ReadAndDecryptFile("Media\\skilldata_20000.txt");
                enc.SaveFile(@"Media\\skilldata_20000enc.txt");
                writeBytes("skilldata_20000enc.txt", s4);
                enc.ReadAndDecryptFile("Media\\skilldata_25000.txt");
                enc.SaveFile(@"Media\\skilldata_25000enc.txt");
                writeBytes("skilldata_25000enc.txt", s5);
                enc.ReadAndDecryptFile("Media\\skilldata_30000.txt");
                enc.SaveFile(@"Media\\skilldata_30000enc.txt");
                writeBytes("skilldata_30000enc.txt", s6);
                enc.ReadAndDecryptFile("Media\\skilldata_35000.txt");
                enc.SaveFile(@"Media\\skilldata_35000enc.txt");
                writeBytes("skilldata_35000enc.txt", s7);

            return true;

            }
            catch
            {

            return false;

            }
        }



    }
}
