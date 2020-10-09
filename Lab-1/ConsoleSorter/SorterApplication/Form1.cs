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
            string pathForOriginTextFile;
            pathForOriginTextFile = txtPathForOriginalFile.Text.ToString();

            string pathForSavingTextFile;
            pathForSavingTextFile = txtPathForSaveSortFile.Text.ToString();

            await Sorter.SortTextFile(pathForOriginTextFile, pathForSavingTextFile);
        }

        private async void btnGenerate_Click_1(object sender, EventArgs e)
        {
            string pathForSavingTextFile;
            pathForSavingTextFile = txtPathToSaveOriginalFile.Text.ToString();

            string size = comboBox1.Text;
            long fileSize;
            fileSize=ReturnSizeOfFile(size);

            await Generator.GenerateTextFileBySize(fileSize, pathForSavingTextFile);
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
