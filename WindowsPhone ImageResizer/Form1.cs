using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsPhone_ImageResizer
{
    public partial class Form1 : Form
    {
        string originalFileName;
        string originalImageFileAddress;
        string originalImageFileExtension;
        string destinationFolder;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                originalImageFileAddress   = openFileDialog1.FileName;
                originalImageFileExtension = originalImageFileAddress.Split('.').Last<string>();
                originalFileName = originalImageFileAddress.Split('\\').Last<string>().Split('.').First<string>();
                textBox1.Text = originalFileName;
            }
        }

        private void Generate_Click(object sender, EventArgs e)
        {
            Size desiredSize;

            listBox1.Items.Clear();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                destinationFolder = folderBrowserDialog1.SelectedPath;
            else
                return;

            foreach (CheckBox item in groupBox1.Controls.OfType<CheckBox>())
            {
                if (item.Checked)
                {
                    try
                    {
                        string[] splitedSize = item.Text.Split('×');
                        desiredSize = new Size(Int32.Parse(splitedSize[0]), Int32.Parse(splitedSize[1]));
                        string destinationFileName = textBox1.Text + " " + item.Text + "." + originalImageFileExtension;
                        string destinationFileFullName = destinationFolder + "\\" + destinationFileName;
                        utility.imageResizer(originalImageFileAddress, destinationFileFullName, desiredSize);
                        listBox1.Items.Add("Image got resized to " + item.Text + "successfully");
                    }
                    catch (Exception ex)
                    {
                        listBox1.Items.Add("Resizing Failed for " + item.Text + " : " + ex.Message);
                    }
                    
                }
            }
            
        }
    }
}
