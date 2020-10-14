using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using TextGenerator;
using SortLibrary;
using System.Diagnostics;
using System.IO;

namespace ConsokeSorter
{
    class Program
    {
        static async Task Main()
        {
            do
            {
                Console.WriteLine("Commands:");
                Console.WriteLine("1. Generate file;");
                Console.WriteLine("2. Sort file;");
                Console.WriteLine("3. Close programm;");
                Console.Write("Input nessecary command: ");

                int actionNumber;
                try
                {
                    actionNumber = int.Parse(Console.ReadLine() ?? string.Empty);
                }
                catch
                {
                    Console.WriteLine("Error: invalid character entered!");
                    Console.WriteLine("Press ENTER to end the program...");
                    Console.ReadLine();
                    return;
                }

                switch (actionNumber)
                {
                    case 1:
                        Console.Write("Enter the path to save the generated file: ");
                        string pathToSaveGeneratedFile = Console.ReadLine();
                        Console.Write("Enter the size of the generated file in bytes: ");

                        int fileSizeInBytes;

                        try
                        {
                            fileSizeInBytes = int.Parse(Console.ReadLine() ?? string.Empty);
                        }
                        catch
                        {
                            Console.WriteLine("Error: invalid data entered!");
                            Console.WriteLine("Press ENTER to end the program...");
                            Console.ReadLine();
                            return;
                        }

                        try
                        {
                            Generator.GenerateTextFileBySize(fileSizeInBytes / 2, pathToSaveGeneratedFile);
                        }
                        catch (ArgumentException)
                        {
                            Console.WriteLine("Error: incorrect file path entered!");
                            Console.WriteLine("Press ENTER to end the program...");
                            Console.ReadLine();
                            return;
                        }
                        catch (DirectoryNotFoundException)
                        {
                            Console.WriteLine("Error: incorrect file path entered!");
                            Console.WriteLine("Press ENTER to end the program...");
                            Console.ReadLine();
                            return;
                        }

                        Console.WriteLine($"Success!\n");
                        break;
                    case 2:
                        Console.Write("Enter the path to the file you want to sort: ");
                        string pathToSourceFile = Console.ReadLine();
                        Console.Write("Enter the path to save the sorted file: ");
                        string pathToSortedFile = Console.ReadLine();

                        var sorter = new Sorter();
                        try
                        {
                            Sorter.SortTextFile(pathToSourceFile, pathToSortedFile);
                        }
                        catch (ArgumentException)
                        {
                            Console.WriteLine("Error: incorrect file path entered!");
                            Console.WriteLine("Press ENTER to end the program...");
                            Console.ReadLine();
                            return;
                        }
                        catch (DirectoryNotFoundException)
                        {
                            Console.WriteLine("Error: incorrect file path entered!");
                            Console.WriteLine("Press ENTER to end the program...");
                            Console.ReadLine();
                            return;
                        }
                        catch (FileNotFoundException)
                        {
                            Console.WriteLine("Error: incorrect file path entered!");
                            Console.WriteLine("Press ENTER to end the program...");
                            Console.ReadLine();
                            return;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"An error occurred while sorting! ERROR: {ex.Message}.");
                            Console.WriteLine("Press ENTER to end the program...");
                            Console.ReadLine();
                            return;
                        }

                        Console.WriteLine($"Success!\n");
                        break;
                    case 3:
                        Console.WriteLine("Press ENTER to end the program ...");
                        Console.ReadLine();
                        return;
                    default:
                        Console.WriteLine("Error: a non-existent command has been introduced!\n");
                        break;
                }

            } while (true);
        }
    }
}
