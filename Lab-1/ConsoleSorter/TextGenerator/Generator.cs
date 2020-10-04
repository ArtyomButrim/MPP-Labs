using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics.SymbolStore;

namespace TextGenerator
{
    public class Generator
    {
        public static async Task GenerateTextFileBySize(long fileSize, string directoryForCreation)
        {
            char[] symbols = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '\n'};

            using (var sw = new StreamWriter(directoryForCreation,false,Encoding.Unicode))
            {
                var Random = new Random();
                long size = 0;

                while ( size < fileSize)
                {
                    int stringLength = Random.Next(20, 240);
                    for (int i = 0; i < stringLength; i++)
                    {

                        sw.Write(symbols[Random.Next(0, symbols.Length - 1)]);
                        size++;
                    }

                    sw.Write('\n');
                    size++;
                }
            }
        }
    }
}
