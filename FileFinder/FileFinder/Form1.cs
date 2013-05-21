using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FileFinder
{
    public partial class Form1 : Form
    {

        private string searchFolder = "C:/Users/Rook/Documents/Downloads/complete/";

        private string fileToOpen = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void findFileButton_Click_1(object sender, EventArgs e)
        {
            string fileName = fileNameInput.Text;

            resultsTxt.Text = "";

            var fileList = Directory.GetFiles(searchFolder, "*" + fileName + "*.*", SearchOption.AllDirectories);

            foreach (string file in fileList)
            {
                resultsTxt.Text += file + "\n";
            }

            fileToOpen = fileList[0];
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(fileToOpen);
        }
    }
}
