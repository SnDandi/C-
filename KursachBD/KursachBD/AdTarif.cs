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
    public partial class AdTarif : Form
    {
        Tarif tarif = new Tarif();
        public static int ID;
        public static string Tarif;
        public static int Minuti;
        public static int MB;
        public static decimal Stoimost;
        public AdTarif(int id,string tarif, int minuti, int mb, decimal stoimost)
        {
            InitializeComponent();
            ID = id;
            Tarif = tarif;
            Minuti = minuti;
            MB = mb;
            Stoimost = stoimost;
        }

        private void AdTarif_Load(object sender, EventArgs e)
        {
            if (this.Text == "Изменение")
            {
                textBox1.Text = Tarif;
                textBox2.Text = Convert.ToString(Minuti);
                textBox3.Text = Convert.ToString(MB);
                textBox4.Text = Convert.ToString(Stoimost);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s1 = textBox1.Text;
            int s2 = int.Parse(textBox2.Text);
            int s3 = int.Parse(textBox3.Text);
            decimal s4 = decimal.Parse(textBox4.Text);
            if (this.Text == "Добавление")
            {
                DialogResult result = MessageBox.Show("Вы действительно хотите добавить новую запись?", "Добавление", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    tarif.tarifTableAdapter.AddTarif(s1, s2, s3, s4);
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("Вы действительно хотите изменить запись?", "Изменение", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    tarif.tarifTableAdapter.UpTarif(s1, s2, s3, s4, ID);
                }
            }
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
