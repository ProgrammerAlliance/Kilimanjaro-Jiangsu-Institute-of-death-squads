using System;
using System.IO;

namespace NL.Order.Common
{
    public class LogHelper
    {

        //// <summary>
        /// 写入日志文件
        /// </summary>
        /// <param name="input"></param>
        public static void WriteLogFile(string input)
        {
            string fname = Directory.GetCurrentDirectory() + "\\LogFile.txt";
            FileInfo finfo = new FileInfo(fname);
            if (!finfo.Exists)
            {
                FileStream fs;
                fs = File.Create(fname);
                fs.Close();
                finfo = new FileInfo(fname);
            }

            if (finfo.Length > 1024 * 1024 * 10)
            {
                File.Move(Directory.GetCurrentDirectory() + "\\LogFile.txt", Directory.GetCurrentDirectory() + DateTime.Now.TimeOfDay + "\\LogFile.txt");
            }
           
            using (FileStream fs = finfo.OpenWrite())
            {                
                StreamWriter w = new StreamWriter(fs);
                w.BaseStream.Seek(0, SeekOrigin.End);               
                w.Write("\n\rLog Entry : ");             
                w.Write("{0} {1} \n\r", DateTime.Now.ToLongTimeString(),
                DateTime.Now.ToLongDateString());
                w.Write(input + "\n\r");           
                w.Write("------------------------------------\n\r");
                w.Close();
            }
        }
    }
}
