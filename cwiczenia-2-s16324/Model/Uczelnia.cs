using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cwiczenia_2_s16324.Model
{
    class Uczelnia
    {
        [JsonProperty(Order = 1)]
        public string createdAt { get; set; }
        [JsonProperty(Order = 2)]
        public string author { get; set; }
        [JsonProperty(Order = 3)]
        public HashSet<Student> studenci = new HashSet<Student>();

        public void addStudent(Student s)
        {
            studenci.Add(s);
        }

    }
}
