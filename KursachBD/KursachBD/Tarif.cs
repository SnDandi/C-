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
    public partial class Tarif : Form
    {
        public Tarif()
        {
            InitializeComponent();
        }

        private void tarifBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tarifBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bDDataSet);

        }

        private void Tarif_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bDDataSet.Tarif". При необходимости она может быть перемещена или удалена.
            this.tarifTableAdapter.Fill(this.bDDataSet.Tarif);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new AdTarif(0,"", 0, 0, 0).ShowDialog();
            this.Validate();
            this.tarifBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bDDataSet);
            this.tarifTableAdapter.Fill(this.bDDataSet.Tarif);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int pp = tarifBindingSource.Position;
                int id = (int)tarifDataGridView.Rows[pp].Cells[0].Value;
                string tarif = (string)tarifDataGridView.Rows[pp].Cells[1].Value;
                int minuti = (int)tarifDataGridView.Rows[pp].Cells[2].Value;
                int mb = (int)tarifDataGridView.Rows[pp].Cells[3].Value;
                decimal stoimost = (decimal)tarifDataGridView.Rows[pp].Cells[4].Value;
                AdTarif add = new AdTarif(id, tarif, minuti, mb, stoimost);
                add.Text = "Изменение";
                add.button1.Text = "Изменить";
                add.ShowDialog();
            }
            catch
            { MessageBox.Show("В таблице отсутствуют данные!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            this.Validate();
            this.tarifBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bDDataSet);
            this.tarifTableAdapter.Fill(this.bDDataSet.Tarif);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int pp = tarifBindingSource.Position;
                DialogResult r = MessageBox.Show($"Вы хотите удалить данные?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (r == DialogResult.Yes)
                {
                    bDDataSet.Tarif.Rows[pp].Delete();
                }
            }
            catch
            { MessageBox.Show("В таблице отсутствуют данные!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            this.tarifBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bDDataSet);
            this.tarifTableAdapter.Fill(this.bDDataSet.Tarif);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            tarifBindingSource.Sort = "ID_Tr";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            tarifBindingSource.Sort = "Tarif";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            tarifBindingSource.Sort = "Minuti";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            tarifBindingSource.Sort = "MB";
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            tarifBindingSource.Sort = "Stoimost";
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }
    }
}
