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
        public static async Task SortTextFile(string pathToFile, string pathToSortFile)
        {

            int numberOfFiles;
            numberOfFiles = SplitTextFile(pathToFile);

            for (int i = 0; i < numberOfFiles; i++)
            {
                SortSubFile($"d:/Temp2/time{i}.txt");
            }

            numberOfFiles++;
            MergeSort($"d:/Temp2/time{0}.txt", $"d:/Temp2/time{1}.txt", $"d:/Temp2/time{numberOfFiles}.txt");
            
            int num = numberOfFiles-1;
            int num2=2;
           
            for (int i = 0; i <num-3;i++)
            {
                MergeSort($"d:/Temp2/time{numberOfFiles}.txt", $"d:/Temp2/time{num2}.txt", $"d:/Temp2/time{numberOfFiles+1}.txt");
                numberOfFiles++;
                num2++;
            }

            MergeSort($"d:/Temp2/time{numberOfFiles}.txt", $"d:/Temp2/time{num2}.txt", pathToSortFile);
        }

        public static int SplitTextFile(string path)
        {
            int filesNumber = 0;
            int textSize = 0;
            string line;
            bool isReady = false;

            using (var streamReader = new StreamReader(path, Encoding.Unicode))
            {
                while (isReady == false)
                {
                    using (var streamWriter = new StreamWriter($"d:/Temp2/time{filesNumber}.txt", true, Encoding.Unicode))
                    {

                        while (((line = streamReader.ReadLine()) != null) && (textSize <= 104857600))
                        {
                            streamWriter.WriteLine(line);
                            textSize += Encoding.Unicode.GetByteCount(line);
                        }

                        textSize = 0;
                        filesNumber++;
                       
                    }

                    if (line == null)
                    {
                        isReady = true;
                    }

                }
            }

            return filesNumber;
        }

        public static void SortSubFile(string path)
        {
            string line;
            var list = new List<string>();
            using (var sr = new StreamReader(path, Encoding.Unicode))
            {

                while ((line = sr.ReadLine()) != null)
                {
                    list.Add(line);
                }
            }

            list.Sort(StringComparer.Ordinal);

            using (var sw = new StreamWriter(path, false, Encoding.Unicode))
            {
                foreach (string str in list)
                {
                    sw.WriteLine(str);
                }
            }

            list.Clear();
        }
        public static void MergeSort(string path1, string path2,string pathToSave)
        {
            string line1;
            string line2;
            using (var sw = new StreamWriter(pathToSave, false, Encoding.Unicode))
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

            File.Delete(path1);
            File.Delete(path2);
        }
    }
}
