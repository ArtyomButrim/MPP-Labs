using SortLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextGenerator;
using System.IO;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SorterApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private async void btnSort_Click(object sender, EventArgs e)
        {
            bool isCorrect = true;
            string pathForOriginTextFile;
            pathForOriginTextFile = txtPathForOriginalFile.Text.ToString();

            string pathForSavingTextFile;
            pathForSavingTextFile = txtPathForSaveSortFile.Text.ToString();

            var time = new Stopwatch();
            time.Start();

            await Task.Run(() =>
            {
                try
                {
                    Sorter.SortTextFile(pathForOriginTextFile, pathForSavingTextFile);
                    isCorrect = true;
                }
                catch (ArgumentException)
                {
                    MessageBox.Show(@"Incorrect file path entered!", @"Error",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    isCorrect = false;
                }
                catch (DirectoryNotFoundException)
                {
                    MessageBox.Show(@"Incorrect file path entered!", @"Error",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    isCorrect = false;
                }
                catch (FileNotFoundException)
                {
                    MessageBox.Show(@"Incorrect file path entered!", @"Error",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    isCorrect = false;
                }
            });
            if (isCorrect)
            {
                MessageBox.Show(@"Sorting is complete!"+"\n"+$"Time: {time.ElapsedMilliseconds.ToString()} мс", @"Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void btnGenerate_Click_1(object sender, EventArgs e)
        {
            bool isCorrect = true;
            string pathForSavingTextFile;
            pathForSavingTextFile = txtPathToSaveOriginalFile.Text.ToString();

            string size = comboBox1.Text;
            long fileSize;
            fileSize=ReturnSizeOfFile(size);

            var time = new Stopwatch();
            time.Start();

            await Task.Run(() =>
            {
                try
                {
                    Generator.GenerateTextFileBySize(fileSize, pathForSavingTextFile);
                    isCorrect = true;
                }
                catch (ArgumentException)
                {
                    MessageBox.Show(@"Incorrect file path entered!", @"Error",
                       MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    isCorrect = false;
                }
                catch (DirectoryNotFoundException)
                {
                    MessageBox.Show(@"Incorrect file path entered!", @"Error",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    isCorrect = false;
                }

            });

            if (isCorrect)
            {
                MessageBox.Show(@"Sorting is complete!" + "\n" + $"Time: {time.ElapsedMilliseconds.ToString()} мс", @"Information",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private long ReturnSizeOfFile(string size)
        {
            switch(size)
            {
                case "250 MB":
                    return 134217728;
                case "500 MB":
                    return 268435456;
                case "1 GB":
                    return 536870912;
                case "2 GB":
                    return 1073741824;
                case "5 GB":
                    return 2684354560;
                default:
                    return 0;
            }
        }
    }
}
