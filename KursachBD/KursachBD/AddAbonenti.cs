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
    public partial class AddAbonenti : Form
    {
        Abonenti abonenti = new Abonenti();
        public static string F_I_O;
        public static string Operator;
        public static string Tarif;
        public static string Nomer;
        public AddAbonenti(string f_i_o, string Oper, string tarif, string nomer)
        {
            InitializeComponent();
            F_I_O = f_i_o;
            Operator = Oper;
            Tarif = tarif;
            Nomer = nomer;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s1 = textBox1.Text;
            string s2 = textBox2.Text;
            string s3 = textBox3.Text;
            string s4 = textBox4.Text;
            if (this.Text == "Добавление")
            {
                DialogResult result = MessageBox.Show("Вы действительно хотите добавить новую запись?", "Добавление", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    abonenti.abonentiTableAdapter.AddAb(s1, s2, s3, s4);
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("Вы действительно хотите изменить запись?", "Изменение", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    abonenti.abonentiTableAdapter.UpAb(s1, s2, s3, s4,F_I_O);
                }
            }
            Close();
        }

        private void AddAbonenti_Load(object sender, EventArgs e)
        {
            if (this.Text == "Изменение")
            {
                textBox1.Text = F_I_O;
                textBox2.Text = Operator;
                textBox3.Text = Tarif;
                textBox4.Text = Nomer;
            }
        }
    }
}
