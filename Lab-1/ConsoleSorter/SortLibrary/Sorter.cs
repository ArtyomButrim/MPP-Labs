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

                list.Clear();
            }

            MergeSort("d:/Temp/time0.txt", "d:/Temp/time1.txt", 11);
        }

        public static void MergeSort(string path1, string path2,int num)
        {
            string line1;
            string line2;
            using (var sw = new StreamWriter($"d:/Temp/time{num}.txt", false, Encoding.Unicode))
            {
                using (var sr1 = new StreamReader(path1, Encoding.Unicode))
                {
                    using (var sr2 = new StreamReader(path2, Encoding.Unicode))
                    {
                        line1 = sr1.ReadLine();
                        line2 = sr2.ReadLine();
                        while ((line1 != null) && (line2 != null))
                        {
                            if (String.Compare(line1,line2,false) == 0)
                            {
                                sw.WriteLine(line1);
                                sw.WriteLine(line2);
                                line1 = sr1.ReadLine();
                                line2 = sr2.ReadLine();
                            }
                            else if(String.Compare(line1, line2, false) > 0)
                            {
                                sw.WriteLine(line2);
                                line2 = sr2.ReadLine();
                            }
                            else if (String.Compare(line1, line2, false) < 0)
                            {
                                sw.WriteLine(line1);
                                line1 = sr1.ReadLine();
                            }
                        }

                        if (line1 == null)
                        {
                            while ((line2 = sr2.ReadLine()) != null)
                            {
                                sw.WriteLine(line2);
                            }
                        }
                        else
                        {
                            while ((line1 = sr1.ReadLine()) != null)
                            {
                                sw.WriteLine(line1);
                            }
                        }
                    }
                }
            }

           // File.Delete(path1);
            //File.Delete(path2);
        }
    }
}
