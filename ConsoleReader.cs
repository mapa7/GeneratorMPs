using System;
using System.Collections.Generic;
using System.Text;

namespace GeneratorMPs
{
   public class ConsoleReader
    {

      public int GetInt()
        {
            var intData = 1;

            while (true)
            {              
                var input = Console.ReadLine();
                if (Int32.TryParse(input, out intData))
                    break;
            }

            return intData;
        }

    }
}
