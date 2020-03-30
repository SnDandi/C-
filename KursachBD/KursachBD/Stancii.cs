using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KursachBD
{
    public partial class Stancii : Form
    {
        public Stancii()
        {
            InitializeComponent();
        }

        private void stanciiBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.stanciiBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bDDataSet);

        }

        private void Stancii_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bDDataSet.Stancii". При необходимости она может быть перемещена или удалена.
            this.stanciiTableAdapter.Fill(this.bDDataSet.Stancii);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new AdStancii(0, "", "").ShowDialog();
            this.Validate();
            this.stanciiBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bDDataSet);
            this.stanciiTableAdapter.Fill(this.bDDataSet.Stancii);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int pp = stanciiBindingSource.Position;
                int id = (int)stanciiDataGridView.Rows[pp].Cells[0].Value;
                string gorod = (string)stanciiDataGridView.Rows[pp].Cells[1].Value;
                string oblast = (string)stanciiDataGridView.Rows[pp].Cells[2].Value;
                AdStancii add = new AdStancii(id, gorod, oblast);
                add.Text = "Изменение";
                add.button1.Text = "Изменить";
                add.ShowDialog();
            }
            catch
            { MessageBox.Show("В таблице отсутствуют данные!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            this.Validate();
            this.stanciiBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bDDataSet);
            this.stanciiTableAdapter.Fill(this.bDDataSet.Stancii);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int pp = stanciiBindingSource.Position;
                DialogResult r = MessageBox.Show($"Вы хотите удалить данные?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (r == DialogResult.Yes)
                {
                    bDDataSet.Stancii.Rows[pp].Delete();
                }
            }
            catch
            { MessageBox.Show("В таблице отсутствуют данные!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            this.Validate();
            this.stanciiBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bDDataSet);
            this.stanciiTableAdapter.Fill(this.bDDataSet.Stancii);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (radioButton5.Checked == true)
                    if (stanciiDataGridView.DataSource == stanciiBindingSource)
                        stanciiBindingSource.Filter = $"[Gorod] like \'{textBox1.Text}%\'";
                if (radioButton4.Checked == true)
                    if (stanciiDataGridView.DataSource == stanciiBindingSource)
                        stanciiBindingSource.Filter = $"[Oblast] like \'{textBox1.Text}%\'";
            }
            else
                stanciiBindingSource.Filter = $"[Gorod] like \'{textBox1.Text}%\'";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            stanciiBindingSource.Sort = "ID_St";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            stanciiBindingSource.Sort = "Gorod";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            stanciiBindingSource.Sort = "Oblast";
        }
    }
}
