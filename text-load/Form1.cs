using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //File.Delete("mail.txt");
            //File.Delete("pass.txt");
            //File.Delete("pass1.txt");
            string razdel = textBox1.Text;
            int count1 = File.ReadAllLines(filePath).Length;
            progressBar1.Maximum = count1;
            dataGridView1.RowCount = count1;
            dataGridView1.ColumnCount = Convert.ToInt32(numericUpDown1.Value);
            //numericUpDown2.Maximum = numericUpDown1.Value;
            int k=Convert.ToInt32(numericUpDown1.Value);
            char[,] mas = new char[count1, k];
            string[] Line;
            Line = File.ReadAllLines(filePath, Encoding.Default);
            for (int i = 0; i < count1; i++)
                for(int j=0;j<k;j++)
            {
                Line = File.ReadAllLines(filePath, Encoding.Default);
                string cod2 = Line[i].Substring(0);
                dataGridView1.Rows[i].Cells[j].Value = cod2.Split(Convert.ToChar(razdel))[j];
                //dataGridView1.Rows[i].Cells[1].Value = str;
                //StreamWriter textFile1 = new StreamWriter(new FileStream("mail.txt", FileMode.Append, FileAccess.Write));
                //textFile1.WriteLine(str2);
                //textFile1.Close();
                progressBar1.Value = progressBar1.Minimum + i;
            }
            MessageBox.Show("Готово!");
        }
        string filePath = "";
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filePath = ofd.FileName;
                label3.Text = "Файл Выбран";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string str;
            int k = dataGridView1.RowCount;
            for (int i = 0; i < k; i++)
            {
                StreamWriter textFile1 = new StreamWriter(new FileStream(@"C:\"+textBox2.Text+".txt", FileMode.Append, FileAccess.Write));
                str = dataGridView1.Rows[i].Cells[Convert.ToInt32(numericUpDown2.Value) - 1].Value.ToString();
                if (checkBox1.Enabled == true)
                {
                    str = str.Replace("<", "");
                    str = str.Replace(">", "");
                    str = str.Replace("(", "");
                    str = str.Replace(")", "");
                    str = str.Replace("\"", " ");
                }
                str = str.Trim();
                textFile1.WriteLine(str);
                textFile1.Close();
                progressBar1.Value = progressBar1.Minimum + i;
            }
            MessageBox.Show("Готово!");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0 || filePath.Length == 0)
                button1.Enabled = false;
            else
                button1.Enabled = true;
            if (textBox2.Text.Length == 0)
                button3.Enabled = false;
            else
                button3.Enabled = true;
            numericUpDown2.Maximum = numericUpDown1.Value;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string k="";
            dataGridView1.ColumnCount = 1;
            int count1 = File.ReadAllLines(filePath).Length;
            string[] Line;
            Line = File.ReadAllLines(filePath, Encoding.Default);
            for (int i = 0; i < count1; i++)
            {
                if (checkBox3.Checked == true) { k = Line[i].Substring(1, Line[i].Length-1);}
                if (checkBox4.Checked == true) { k = Line[i].Substring(0, Line[i].Length - 1); }
                if (checkBox2.Checked == true) { k = Line[i].Substring(1, Line[i].Length - 2); }
                dataGridView1.Rows.Add(k);
                StreamWriter textFile1 = new StreamWriter(new FileStream(filePath+"1", FileMode.Append, FileAccess.Write));
                textFile1.WriteLine(k);
                textFile1.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string razdel = textBox1.Text;
            int count1 = File.ReadAllLines(filePath).Length;
            int k = Convert.ToInt32(numericUpDown1.Value);
            dataGridView1.RowCount = count1;
            dataGridView1.ColumnCount = Convert.ToInt32(numericUpDown1.Value);
             string[] Line;
            Line = File.ReadAllLines(filePath, Encoding.Default);
            for (int i = 0; i < count1; i++)
                for (int j = 0; j < 8000; j++)
            {
                    Line = File.ReadAllLines(filePath, Encoding.Default);
                    string cod2 = Line[i].Split(Convert.ToChar(razdel))[j];
                    dataGridView1.Rows.Add(cod2);
                    StreamWriter textFile1 = new StreamWriter(new FileStream(filePath + "1", FileMode.Append, FileAccess.Write));
                    textFile1.WriteLine(cod2);
                    textFile1.Close();

                }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int count1 = File.ReadAllLines(filePath).Length;
            progressBar1.Maximum = count1;
            string[] Line;
            Line = File.ReadAllLines(filePath, Encoding.Default);
            for (int i = 0; i < count1; i++)
            {
                string cod = Line[i] + "@";
                StreamWriter textFile1 = new StreamWriter(new FileStream(@"C:\gov.txt", FileMode.Append, FileAccess.Write));
                textFile1.WriteLine(cod);
                textFile1.Close();
                progressBar1.Value = progressBar1.Minimum + i;
                MessageBox.Show("Готово!!!","Файл gov.txt сохранен в корневом каталоге диска С:");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int count1 = File.ReadAllLines(filePath).Length;
            progressBar1.Maximum = count1;
            string[] Line;
            Line = File.ReadAllLines(filePath, Encoding.Default);
            for (int i = 0; i < count1; i++)
            {
                Line[i] = Line[i].Substring(0,Line[i].Length-1);
                StreamWriter textFile1 = new StreamWriter(new FileStream(@"C:\gov-good.txt", FileMode.Append, FileAccess.Write));
                textFile1.WriteLine(Line[i]);
                textFile1.Close();
                progressBar1.Value = progressBar1.Minimum + i;
                MessageBox.Show("Готово!!!", "Файл gov-good.txt сохранен в корневом каталоге диска С:");
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            filePath = "";
            label3.Text = "Данные очищены";
        }
    }
}
