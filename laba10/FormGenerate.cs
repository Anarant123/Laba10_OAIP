﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba10
{
    public partial class FormGenerate : Form
    {
        private Random random = new Random();
        public static Form1 form1;
        public FormGenerate()
        {
            InitializeComponent();
            label2.Text = "";
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            tbCount.Text = Convert.ToString(trackBar1.Value);
        }

        private void tbCount_TextChanged(object sender, EventArgs e)
        {
            int flag = 0;
            if (!(int.TryParse(tbCount.Text, out flag)))
            {
                label2.Text = "Введенно некорректное значение.";
                this.Height = 200;
            }
            else if (!(int.Parse(tbCount.Text) > trackBar1.Maximum))
            {
                label2.Text = "";
                this.Height = 175;
                trackBar1.Value = int.Parse(tbCount.Text);
            }
            else if ((int.Parse(tbCount.Text) > trackBar1.Maximum) || (int.Parse(tbCount.Text) < trackBar1.Minimum))
            {
                label2.Text = "Введенное значение вышло \nза допустимый интервал.";
                this.Height = 200;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Context.array = new int[trackBar1.Value];
            for (int i = 0; i < Context.array.Length; i++)
            {
                Context.array[i] = random.Next(0, 1000);
            }

            form1.lbOutput.Items.Add("");
            foreach (var item in Context.array)
            {
                form1.lbOutput.Items[form1.count] += Convert.ToString(item) + " ";
            }
            form1.count++;

            this.Close();
        }
    }
}
