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

            var processor = new NodeProcessorFactory().Create(args.FirstOrDefault());
            processor.Process();
        }

        private static void WriteMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
