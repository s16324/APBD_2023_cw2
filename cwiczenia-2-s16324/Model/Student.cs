using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cwiczenia_2_s16324.Model
{
    class Student
    {
        public string indexNumber { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string birthdate { get; set; }
        public string email { get; set; }
        public string mothersName { get; set; }
        public string fathersName { get; set; }

        public Studies studies { get; set; }

        public void addStudies(Studies s)
        {
            studies = s;
        }

        public override bool Equals(object obj)
        {
            return obj is Student student &&
                   indexNumber == student.indexNumber &&
                   fname == student.fname &&
                   lname == student.lname;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(indexNumber, fname, lname);
        }

        public override string ToString()
        {
            return "indexNumber: " + indexNumber +
                ", fname: " + fname +
                ", lname: " + lname +
                ", birthdate: " + birthdate +
                ", email: " + email +
                ", mothersName: " + mothersName +
                ", fathersName: " + fathersName + " ("+
                studies.ToString()+")";
        }



    }
}
