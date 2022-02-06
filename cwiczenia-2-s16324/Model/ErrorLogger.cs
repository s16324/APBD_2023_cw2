using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cwiczenia_2_s16324.Model
{
    class ErrorLogger
    {

        string path;
        List<string> errList = new List<string>();

        public ErrorLogger(string p)
        {
            path = p;
        }

        public void addDataError(string[] row, string desc)
        {
            string strRow = "";
            foreach (string s in row)
            {
                strRow += "<"+s+"> ";
            }
            errList.Add("ERR: " + desc + " - row:[" + strRow + "] - data skipped");
        }

        public void logDataErrors()
        {
            DateTimeOffset now = (DateTimeOffset)DateTime.UtcNow;
            using (System.IO.TextWriter tw = new System.IO.StreamWriter(path+@"\DataError_" + now.ToString("yyyyMMddHHmmssfff") + ".txt"))
            {
                foreach (String s in errList)
                    tw.WriteLine(s);
            }
        }
    }
}
