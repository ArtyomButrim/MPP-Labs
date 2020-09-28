using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using TextGenerator;

namespace ConsokeSorter
{
    class Program
    {
        static async Task Main(string[] args)
        {
            TextGenerator.Generator.GenerateTextFileBySize(1024*1024*1024, "d:/test.txt");
            Console.WriteLine("Complete");
            Console.ReadLine();
        }
    }
}
