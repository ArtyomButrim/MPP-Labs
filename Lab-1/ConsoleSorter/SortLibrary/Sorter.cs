using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SortLibrary
{
    public class Sorter
    {
        static char[] symbols = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' , 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};

        public static async Task SortTextFile(string pathToFile, string pathToSortFile)
        { 
            foreach (char symbol in symbols)
            {
                int index = Array.IndexOf(symbols, symbol);
                using (var file = File.Create($"d:/Temp/time{index}.txt")) { } ;
            }

            using (var streamReader = new StreamReader(pathToFile, Encoding.Default))
            {
                string line;

                while ((line = streamReader.ReadLine()) != null)
                {
                    using (var fStream = new FileStream($"d:/Temp/time{Array.IndexOf(symbols, line[0])}.txt", FileMode.Open))
                    {
                        using (var writer = new StreamWriter(fStream, Encoding.Default))
                        {
                           writer.WriteLine(line);
                        }
                    }
                }
            }

            using (var fileStream = new FileStream(pathToSortFile, FileMode.Open))
            {
                using (var streamWriter = new StreamWriter(fileStream, Encoding.Default))
                {
                    foreach (char symbol in symbols)
                    {
                        var list = new List<string>();
                        using (var streamReader = new StreamReader($"d:/Temp/time{Array.IndexOf(symbols, symbol)}.txt", Encoding.Default))
                        {
                            string line;
                            while ((line = streamReader.ReadLine()) != null)
                            {
                                list.Add(line);
                            }
                        }

                        list.Sort();

                        foreach (string str in list)
                        {
                            streamWriter.WriteLine(str);
                        }
                    }
                }
            }
        }
    }
}
