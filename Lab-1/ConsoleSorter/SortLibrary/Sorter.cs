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
        // static readonly char[] symbols = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

        public static async Task SortTextFile(string pathToFile, string pathToSortFile)
        {
            for (int i = 0; i<=10; i++)
            { 
                using (var file = File.Create($"d:/Temp/time{i}.txt")) { };
            }

            using (var streamReader = new StreamReader(pathToFile, Encoding.Unicode))
            {
                for (int i = 0; i <= 10; i++)
                {
                    string line;
                    int size = 0;
                    using (var streamWriter = new StreamWriter($"d:/Temp/time{i}.txt", true, Encoding.Unicode))
                    {
                        if (i != 10)
                        {
                            while (size < 100000000)
                            {
                                line = streamReader.ReadLine();
                                streamWriter.WriteLine(line);
                                size += Encoding.Unicode.GetByteCount(line);
                            }
                        }
                        else
                        {
                            while ((line = streamReader.ReadLine()) != null)
                            {
                                streamWriter.WriteLine(line);
                            }
                        }
                    }
                }

            }

            for (int i = 0; i <= 10; i++)
            {
                string line;
                var list = new List<string>();
                using (var sr = new StreamReader($"d:/Temp/time{i}.txt", Encoding.Unicode))
                {

                    while ((line = sr.ReadLine()) != null)
                    {
                        list.Add(line);
                    }
                }

                list.Sort(StringComparer.Ordinal);

                using (var sw = new StreamWriter($"d:/Temp/time{i}.txt", false, Encoding.Unicode))
                {
                    foreach (string str in list)
                    {
                        sw.WriteLine(str);
                    }
                }
            }



            /*using (var streamReader = new StreamReader(pathToFile, Encoding.Unicode))
            {
                string line;

                while ((line = streamReader.ReadLine()) != null)
                {
                    using (var writer = new StreamWriter($"d:/Temp/time{Array.IndexOf(symbols, line[0])}.txt", true, Encoding.Unicode))
                    {
                        writer.WriteLine(line);

                    }
                }
            }

            using (var streamWriter = new StreamWriter(pathToSortFile,false, Encoding.Unicode))
            {
                foreach (char symbol in symbols)
                {
                    var list = new List<string>();
                    using (var streamReader = new StreamReader($"d:/Temp/time{Array.IndexOf(symbols, symbol)}.txt", Encoding.Unicode))
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
                }*/
            
        }
    }
}
