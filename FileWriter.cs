using System;
using System.Collections.Generic;
using System.Text;

namespace GeneratorMPs
{   
    class FileWriter
    {
        public void WriteGeneratedData(string directory, string filename, List<string> data)
        {

            string dirPath = @"C:\Users\MPSENG05\Desktop\" + directory;

            if (!System.IO.Directory.Exists(dirPath))
                System.IO.Directory.CreateDirectory(dirPath);

            string filePath = dirPath+ "\\" + filename + ".txt";

            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
            System.IO.File.WriteAllText(filePath, "");       
            
            System.IO.File.AppendAllLines(filePath, data);
        }


    }
}
