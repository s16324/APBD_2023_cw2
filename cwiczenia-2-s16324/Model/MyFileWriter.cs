using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cwiczenia_2_s16324.Model
{
    class MyFileWriter
    {
        public MyFileWriter()
        {

        }

        public void saveAsJson(string json, string path)
        {
            File.WriteAllText(path, json);
        }

    }
}
