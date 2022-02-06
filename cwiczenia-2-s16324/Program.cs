using cwiczenia_2_s16324.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.IO;
using System.Text.Json;

namespace cwiczenia_2_s16324
{
    class Program
    {
        static MyFileWriter writer = new MyFileWriter();
        static ErrorLogger errorLogger;
        static void Main(string[] args)
        {

            if (args.Length != 3)
            {
                throw new ArgumentException("no input arguments");
            }

            //Getting arguments
            string inPath = args[0];
            string outPath = args[1];
            string outputFormat = args[2];

            //Initialize error logger obj
            errorLogger = new ErrorLogger(outPath);

            //timestamp for root object
            DateTime timestamp = DateTime.Today;

            //wrapper (Root -> Uczelnia -> Student -> Studies)
            Root root = new Root();
            Uczelnia uczelnia = new Uczelnia();
            uczelnia.createdAt = timestamp.ToString("d");
            uczelnia.author = "Jakub Lewandowski";

            //Readling csv file
            FileInfo fileInfo = new FileInfo(inPath);
            StreamReader streamReader = new StreamReader(fileInfo.OpenRead());
            string line = null;
            while ((line = streamReader.ReadLine()) != null)
            {
                string[] tokens = line.Split(',');
                //Adding row data to Uczelnia obj
                addData(tokens, uczelnia);

            }

            //Create Json output
            root.uczelnia = uczelnia;
            MyJsonParser parser = new MyJsonParser();
            var json = parser.parse(root);
            //Console.WriteLine(json);

            //Create output file
            //MyFileWriter writer = new MyFileWriter();
            writer.saveAsJson(json, outPath + @"\output.json");
            errorLogger.logDataErrors();

        }

        public static void addData(string[] tokens, Uczelnia uczelnia)
        {

            //null values validation
            Boolean err = false;
            foreach (string t in tokens)
            {
                if ((t == null || t == " ") && !err)
                {
                    err = true;
                    //Error
                    errorLogger.addDataError(tokens, "Incorrect data row (empty columns)");
                }
            }

            //Number of columns validation
            if (tokens.Length == 9 && !err)
            {

                Student student = new Student
                {
                    indexNumber = tokens[4],
                    fname = tokens[0],
                    lname = tokens[1],
                    birthdate = tokens[5],
                    email = tokens[6],
                    mothersName = tokens[7],
                    fathersName = tokens[8]

                };
                Studies studies = new Studies { name = tokens[2], mode = tokens[3] };
                student.addStudies(studies);
                uczelnia.addStudent(student);

            }
            else
            {
                //Error
                errorLogger.addDataError(tokens, "Incorrect data row (missing columns)");
            }
        }
    }
}
