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
    public partial class Razgovori : Form
    {
        public Razgovori()
        {
            InitializeComponent();
        }

        private void Razgovori_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bDDataSet.Peregovori". При необходимости она может быть перемещена или удалена.
            this.peregovoriTableAdapter.Fill(this.bDDataSet.Peregovori);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bDDataSet.Kto". При необходимости она может быть перемещена или удалена.
            this.ktoTableAdapter.Fill(this.bDDataSet.Kto);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dt;
            dt = DateTime.Now;
            new AdRazg(0,dt, 0, "", 0).ShowDialog();
            this.Validate();
            this.peregovoriBindingSource.EndEdit();
            this.ktoBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bDDataSet);
            this.peregovoriTableAdapter.Fill(this.bDDataSet.Peregovori);
            this.ktoTableAdapter.Fill(this.bDDataSet.Kto);
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int pp = ktoBindingSource.Position;
                DialogResult r = MessageBox.Show($"Вы хотите удалить данные?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (r == DialogResult.Yes)
                {
                    bDDataSet.Kto.Rows[pp].Delete();
                }
            }
            catch
            { MessageBox.Show("В таблице отсутствуют данные!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            this.Validate();
            this.peregovoriBindingSource.EndEdit();
            this.ktoBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bDDataSet);
            this.peregovoriTableAdapter.Fill(this.bDDataSet.Peregovori);
            this.ktoTableAdapter.Fill(this.bDDataSet.Kto);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ktoBindingSource.Sort = "ID_Pp";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            ktoBindingSource.Sort = "F_I_O";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            ktoBindingSource.Sort = "Nomer";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            ktoBindingSource.Sort = "Data";
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            ktoBindingSource.Sort = "Nach_razg";
        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {
            ktoBindingSource.Sort = "Dlit_razg_min";
        }
    }
}
