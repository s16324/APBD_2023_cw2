using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cwiczenia_2_s16324.Model
{
    class MyJsonParser
    {

        JsonSerializer serializer;
        StringWriter stringWriter;

        public MyJsonParser()
        {
            serializer = new Newtonsoft.Json.JsonSerializer();
            stringWriter = new StringWriter();
        }

        public string parse(Root o)
        {
            using (JsonTextWriter writer = new JsonTextWriter(stringWriter))
            {
                writer.Formatting = Formatting.Indented;
                writer.QuoteName = false;
                serializer.Serialize(writer, o);


            }
            var json = stringWriter.ToString();
            return json;
        }

    }
}
