using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformTask.DataLoader
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!args.Any())
                WriteMessage("Uppps! You didn't define source folder");

            var folderName = args.FirstOrDefault();
            var processor = new NodeProcessorFactory().Create(folderName);
            try
            {
                processor.Process();
                Console.WriteLine("All files from passed directory ({0}) have been processed!", folderName);
            }
            catch (Exception exc)
            {
                Console.WriteLine("Upps ! :( Something went wrong. Exceptopn occured: {0}", exc.Message);
            }
            Console.Read();
        }

        private static void WriteMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
