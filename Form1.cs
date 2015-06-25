using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        string icpath="";
        public Form1()
        {
            InitializeComponent();
        }

        private string GetFile()
        {
            string result = string.Empty;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            OpenFileDialog openFileDialog2 = openFileDialog;
            openFileDialog2.Filter = "Executables | *.exe|All files | *.*";
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                result = openFileDialog2.FileName;
            }
            return result;
        }
        private string StrReverse(string ToReverse)
        {
            Array arr = ToReverse.ToCharArray();
            Array.Reverse(arr); // reverse the string
            char[] c = (char[])arr;
            return (new string(c));
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = this.GetFile();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(icpath.Length>2)
            IconInjector.InjectIcon(textBox1.Text, icpath);

            FileInfo fileInfo = new FileInfo(textBox1.Text);
            File.Copy(textBox1.Text, string.Concat(new string[]
			{
				fileInfo.DirectoryName,
				"\\",
				textBox2.Text,
				"‮",
				StrReverse(textBox3.Text),
				fileInfo.Extension
			}), true);

            if (icpath.Length > 2)
                MessageBox.Show("Done! To see icon changed move file to other place or you can try rename it.");
            else
                MessageBox.Show("Done!");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {            
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            OpenFileDialog openFileDialog4 = openFileDialog1;
            openFileDialog4.Filter = "Icon File | *.ico";
            if (openFileDialog4.ShowDialog() == DialogResult.OK)
            {
                icpath = openFileDialog4.FileName;
            }
            pictureBox1.Image = Image.FromFile(icpath);
        }
    }
}
