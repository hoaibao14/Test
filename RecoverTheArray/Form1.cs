using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace RecoverTheArray
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog oFile = new OpenFileDialog();
            oFile.Filter = "All files (*.*)|*.*";
            if (oFile.ShowDialog() == DialogResult.OK)
            {
                tbPath.Text = oFile.FileName;
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            try
            {

                string path = tbPath.Text;
                var reader = new StreamReader(File.OpenRead(path));
                var line = reader.ReadLine();
                int n = int.Parse(line.ToString());
                if ((n >= 2) && (n <= 100000))
                {
                    var line2 = reader.ReadLine();
                    string[] mString = line2.Split(' ');
                    int[] m = Array.ConvertAll(mString, s => int.Parse(s));
                    int i = m.Count();
                    if (n == i)
                    {
                        int numberOfArray = 0;
                        string contentArray = "";
                        while (i != 0)
                        {

                            int m1 = m[0];
                            for (int j = 0; j <= m1; j++)
                            {
                                contentArray += m[j].ToString() + " ";
                            }
                            contentArray += "\r\n";

                            m = m.Skip(m1 + 1).Take(m.Count() - m1 - 1).ToArray();
                            i = m.Count();
                            numberOfArray++;

                        }
                        tbResult.Text = numberOfArray.ToString() + "\r\n" + contentArray;
                    }
                    else {
                        tbResult.Text = "Number of element is not equal number of integers in the file!";
                    }
                }
                else {
                    tbResult.Text = "Invalid n!";
                }
            }
            catch (Exception ex)
            {
                tbResult.Text = "Processing file: error!";
            }
        }
    }
}
