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
            string fname = "C:\\LogFile.txt";
            FileInfo finfo = new FileInfo(fname);
            if (!finfo.Exists)
            {
                FileStream fs;
                fs = File.Create(fname);
                fs.Close();
                finfo = new FileInfo(fname);
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
