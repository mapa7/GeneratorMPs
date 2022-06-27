using System;

namespace GeneratorMPs
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleReader consoleReader = new ConsoleReader();
            FileReader fileReader = new FileReader();
            FileWriter fileWriter = new FileWriter();
            Generator generator = new Generator();

            const string dirName = "MPsGeneratedData";
            int netNumber = 1;
            int timerNumber = 1;

            var readComponents = fileReader.ReadComponentsList("components.csv");
            Console.WriteLine("Odczytano {0} komponenty",readComponents.Count);

            #region FC4
            Console.WriteLine("\nKodowanie statusów");
            Console.WriteLine("Startowy nr networku");
            netNumber = consoleReader.GetInt();

            var generatedFC4 = generator.GenerateFC4(readComponents, netNumber);
            fileWriter.WriteGeneratedData(dirName, "FC4", generatedFC4);
    
            #endregion

            #region FC10
            Console.WriteLine("\nDekodowanie komend");
            Console.WriteLine("Startowy nr networku");
            netNumber = consoleReader.GetInt();
            var generatedFC10 = generator.GenerateFC10(readComponents, netNumber);
            fileWriter.WriteGeneratedData(dirName, "FC10", generatedFC10);
            
            #endregion

            #region FC13 
            Console.WriteLine("\nBłędy gotowości");
            Console.WriteLine("Startowy nr networku");
            netNumber = consoleReader.GetInt();
            Console.WriteLine("Startowy nr timera");
            timerNumber = consoleReader.GetInt();

            var generatedFC13ReadyErr = generator.GenerateFC13ReadyErr(readComponents, timerNumber, netNumber);
            fileWriter.WriteGeneratedData(dirName, "FC13_BledyGot", generatedFC13ReadyErr);
            

            Console.WriteLine("\nBłędy run");
            Console.WriteLine("Startowy nr networku");
            netNumber = consoleReader.GetInt();
            Console.WriteLine("Startowy nr timera");
            timerNumber = consoleReader.GetInt();

            var generatedFC13RunErr = generator.GenerateFC13RunErr(readComponents, timerNumber, netNumber);
            fileWriter.WriteGeneratedData(dirName, "FC13_BledyRun", generatedFC13RunErr);
            

            Console.WriteLine("\nBłędy pozycji");
            Console.WriteLine("Startowy nr networku");
            netNumber = consoleReader.GetInt();
            Console.WriteLine("Startowy nr timera");
            timerNumber = consoleReader.GetInt();

            var generatedFC13PosErr = generator.GenerateFC13PosErr(readComponents, timerNumber, netNumber);
            fileWriter.WriteGeneratedData(dirName, "FC13_BledyPoz", generatedFC13PosErr);
            

            Console.WriteLine("\nSumy awarii");
            Console.WriteLine("Startowy nr networku");
            netNumber = consoleReader.GetInt();

            var generatedFC13SumErr = generator.GenerateFC13SumErr(readComponents, netNumber);
            fileWriter.WriteGeneratedData(dirName, "FC13_SumyAwarii", generatedFC13SumErr);
            
            #endregion

            #region FC16
            Console.WriteLine("\nWyjścia sterujące");
            Console.WriteLine("Startowy nr networku");
            netNumber = consoleReader.GetInt();
            Console.WriteLine("Startowy nr timera");
            timerNumber = consoleReader.GetInt();

            var generatedFC16 = generator.GenerateFC16(readComponents, timerNumber, netNumber);
            fileWriter.WriteGeneratedData(dirName, "FC16", generatedFC16);
            
            #endregion

            #region FC201
            Console.WriteLine("\nFalowniki");
            Console.WriteLine("Startowy nr networku");
            netNumber = consoleReader.GetInt();

            var generatedFC201 = generator.GenerateFC201(readComponents, netNumber);
            fileWriter.WriteGeneratedData(dirName, "FC201", generatedFC201);
            
            #endregion
            Console.WriteLine("\nKONIEC");
            Console.ReadKey();
        }
    }
}
