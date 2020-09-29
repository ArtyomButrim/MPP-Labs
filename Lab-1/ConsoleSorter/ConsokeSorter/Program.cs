using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using TextGenerator;
using SortLibrary;

namespace ConsokeSorter
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Input path with name and extention for creationfile:");
            string path = Console.ReadLine();

            Console.WriteLine("Input path name and extention for creation sort file:");
            string pathForSortFile = Console.ReadLine();

            Console.WriteLine("Input size of file:");
            long fileSize = Convert.ToInt64(Console.ReadLine());
            
            await Generator.GenerateTextFileBySize(fileSize, path);
            Console.WriteLine("Generation Complete");

            await SortLibrary.Sorter.SortTextFile(path, pathForSortFile);
            Console.WriteLine("sorting Complete");
            Console.ReadLine();
        }
    }
}
