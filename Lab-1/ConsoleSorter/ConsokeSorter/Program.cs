using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using TextGenerator;
using SortLibrary;
using System.Diagnostics;

namespace ConsokeSorter
{
    class Program
    {
        static async Task Main()
        {
            Console.WriteLine("Input path with name and extention for creationfile:");
            string path = Console.ReadLine();

            Console.WriteLine("Input path name and extention for creation sort file:");
            string pathForSortFile = Console.ReadLine();
            
            Console.WriteLine("Input size of file:");
            long fileSize = Convert.ToInt64(Console.ReadLine());
           
            var sw = new Stopwatch();
            sw.Start();
            await Generator.GenerateTextFileBySize(fileSize, path);
            sw.Stop();
            var time = sw.ElapsedMilliseconds.ToString();
            
            Console.WriteLine(time);
            Console.WriteLine("Generation Complete");

            var time1 = new Stopwatch();
            time1.Start();
            await SortLibrary.Sorter.SortTextFile(path, pathForSortFile);
            time1.Stop();
            string time2 = time1.ElapsedMilliseconds.ToString();
            
            Console.WriteLine("sorting Complete");
            Console.WriteLine(time2);
            Console.ReadLine();
        }
    }
}
