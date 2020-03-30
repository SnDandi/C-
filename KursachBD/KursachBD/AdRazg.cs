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
    public partial class AdRazg : Form
    {
        Razgovori razgovori = new Razgovori();
        public static int ID;
        public static DateTime Data;
        public static int ID_Ab;
        public static string Nach_razg;
        public static int Dlit;
        public AdRazg(int id,DateTime data, int ab, string nach_razg, int dlit)
        {
            InitializeComponent();
            ID = id;
            Data = data;
            ID_Ab = ab;
            Nach_razg = nach_razg;
            Dlit = dlit;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DateTime s1 = DateTime.Parse(textBox5.Text);
            int s2 = int.Parse(textBox6.Text);
            string s3 = textBox7.Text;
            int s4 = int.Parse(textBox8.Text);
            if (this.Text == "Добавление")
            {
                DialogResult result = MessageBox.Show("Вы действительно хотите добавить новую запись?", "Добавление", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    razgovori.peregovoriTableAdapter.AddRazg(s1, s2, s3, s4);
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("Вы действительно хотите изменить запись?", "Изменение", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    razgovori.peregovoriTableAdapter.UpRazg(s1, s2, s3, s4, ID);
                }
            }
            Close();
        }

        private void AdRazg_Load(object sender, EventArgs e)
        {
            if (this.Text == "Изменение")
            {
                textBox5.Text = Convert.ToString(Data);
                textBox6.Text = Convert.ToString(ID_Ab);
                textBox7.Text = Convert.ToString(Nach_razg);
                textBox8.Text = Convert.ToString(Dlit);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
