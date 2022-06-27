using System;
using System.Collections.Generic;
using System.Text;
  

namespace GeneratorMPs
{
    class FileReader
    {

        public List<Component> ReadComponentsList(string filename)
        {
            var lines = ReadLinesFromFile(filename);

            List<Component> components=new List<Component>();

            var firstLine = false;

            foreach (var line in lines)
            {
                if(!firstLine)
                {
                    firstLine = true;
                }
                else
                {              
                    var extractedComp= ExtractComponentData(line);
                    if(extractedComp.Symbol!="")
                    {
                    components.Add(extractedComp);
                    }
                }
            }

            return components;
        }

        private string[] ReadLinesFromFile(string filename)
        {
            string filePath = @"C:\Users\MPSENG05\Desktop\" + filename;

            return System.IO.File.ReadAllLines(filePath);
        }

        private Component ExtractComponentData(string line)
        {
            string symbol = "";
            string cmdNumber = "";
            string cmdPart = "";
            string type = "";
            string safetyZone = "";
            string dpAdress = "";

            string[] substrings = line.Split(';');

            if(substrings.Length==6)
            {
                cmdPart = substrings[0];
                cmdNumber = substrings[1];
                symbol = substrings[2];
                type = substrings[3];
                safetyZone = substrings[4];
                dpAdress = substrings[5];
            }
 
            return new Component(symbol, cmdNumber, cmdPart, type, safetyZone, dpAdress);
        }

    }
}
