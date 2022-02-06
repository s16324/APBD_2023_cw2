using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cwiczenia_2_s16324.Model
{
    class Studies
    {
        public string name { get; set; }
        public string mode { get; set; }

        public override string ToString()
        {
            return "name: " + name +
                ", mode: " + mode;
        }
    }

    







}
