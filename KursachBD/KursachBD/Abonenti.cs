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
    public partial class Abonenti : Form
    {
        public Abonenti()
        {
            InitializeComponent();
        }

        private void abonentiBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.abonentiBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bDDataSet);

        }

        private void Abonenti_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bDDataSet.Abonenti". При необходимости она может быть перемещена или удалена.
            this.abonentiTableAdapter.Fill(this.bDDataSet.Abonenti);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new AddAbonenti("", "", "", "").ShowDialog();
            this.Validate();
            this.abonentiBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bDDataSet);
            this.abonentiTableAdapter.Fill(this.bDDataSet.Abonenti);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int pp = abonentiBindingSource.Position;
                string f_i_o = (string)abonentiDataGridView.Rows[pp].Cells[1].Value;
                string Oper = (string)abonentiDataGridView.Rows[pp].Cells[2].Value;
                string tarif = (string)abonentiDataGridView.Rows[pp].Cells[3].Value;
                string nomer = (string)abonentiDataGridView.Rows[pp].Cells[4].Value;
                AddAbonenti add = new AddAbonenti(f_i_o, Oper, tarif, nomer);
                add.Text = "Изменение";
                add.button1.Text = "Изменить";
                add.ShowDialog();
            }
            catch
            { MessageBox.Show("В таблице отсутствуют данные!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            this.Validate();
            this.abonentiBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bDDataSet);
            this.abonentiTableAdapter.Fill(this.bDDataSet.Abonenti);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int pp = abonentiBindingSource.Position;
                DialogResult r = MessageBox.Show($"Вы хотите удалить данные?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (r == DialogResult.Yes)
                {
                    bDDataSet.Abonenti.Rows[pp].Delete();
                }
            }
            catch
            { MessageBox.Show("В таблице отсутствуют данные!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            this.Validate();
            this.abonentiBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bDDataSet);
            this.abonentiTableAdapter.Fill(this.bDDataSet.Abonenti);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            abonentiBindingSource.Sort = "ID_Ab";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            abonentiBindingSource.Sort = "F_I_O";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            abonentiBindingSource.Sort = "Operator";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            abonentiBindingSource.Sort = "Tarif";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (radioButton9.Checked == true)
                    if (abonentiDataGridView.DataSource == abonentiBindingSource)
                        abonentiBindingSource.Filter = $"[F_I_O] like \'{textBox1.Text}%\'";
                if (radioButton8.Checked == true)
                    if (abonentiDataGridView.DataSource == abonentiBindingSource)
                        abonentiBindingSource.Filter = $"[Operator] like \'{textBox1.Text}%\'";
                if (radioButton7.Checked == true)
                    if (abonentiDataGridView.DataSource == abonentiBindingSource)
                        abonentiBindingSource.Filter = $"[Tarif] like \'{textBox1.Text}%\'";
                if (radioButton6.Checked == true)
                    if (abonentiDataGridView.DataSource == abonentiBindingSource)
                        abonentiBindingSource.Filter = $"[Nomer] like \'{textBox1.Text}%\'";
            }
            else
                abonentiBindingSource.Filter = $"[F_I_O] like \'{textBox1.Text}%\'";
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            abonentiBindingSource.Sort = "Tarif";
        }
    }
}
