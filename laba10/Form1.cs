using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba10
{
    public partial class Form1 : Form
    {
        public Context context;
        public int count = 0;
        public Form1()
        {
            InitializeComponent();

            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            IOFile.form1 = this;
            ShellSort.form1 = this;
            ChooseSort.form1 = this;
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            if (Context.array != null)
            {
                if (rbChoose.Checked == true)
                {
                    this.context = new Context(new ChooseSort());
                    context.ExecuteAlgorithm();
                    this.AddItemsListBox();
                    IOFile.SaveData();
                    btnSort.Enabled = false;
                }
                if (rbShell.Checked == true)
                {
                    this.context = new Context(new ShellSort());
                    context.ExecuteAlgorithm();
                    this.AddItemsListBox();
                    IOFile.SaveData();
                    btnSort.Enabled = false;
                }
                IOFile.content = "";
            }
            else
            {
                MessageBox.Show("Массив пуст, сортировка невозможна");
            }
        }

        private void сгенерироватьНаборToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Context.array == null)
            {
                FormGenerate formGenerate = new FormGenerate();
                FormGenerate.form1 = this;
                formGenerate.Show();

                btnSort.Enabled = true;
            }
            else
            {
                MessageBox.Show("Массив уже сгенерирован. Очистите старый набор и повторите попытку");
            }
        }

        public void AddItemsListBox(int first = -1, int second = -1)
        {
            lbOutput.Items.Add("");
            foreach (var item in Context.array)
            {
                if (item == first || item == second)
                {
                    lbOutput.Items[count] += '[' + Convert.ToString(item) + ']' + " ";
                }
                else
                {
                    lbOutput.Items[count] += Convert.ToString(item) + " ";
                }
            }
            count++;
        }
    }
}
