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
    public partial class AdStancii : Form
    {
        Stancii stancii = new Stancii();
        public static int ID;
        public static string Gorod;
        public static string Oblast;
        public AdStancii(int id, string gorod, string oblast)
        {
            InitializeComponent();
            ID = id;
            Gorod = gorod;
            Oblast = oblast;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s1 = textBox1.Text;
            string s2 = textBox2.Text;
            if (this.Text == "Добавление")
            {
                DialogResult result = MessageBox.Show("Вы действительно хотите добавить новую запись?", "Добавление", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    stancii.stanciiTableAdapter.AddStacii(s1, s2);
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("Вы действительно хотите изменить запись?", "Изменение", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    stancii.stanciiTableAdapter.UpStacii(s1, s2, ID);
                }
            }
            Close();
        }

        private void AdStancii_Load(object sender, EventArgs e)
        {
            if (this.Text == "Изменение")
            {
                textBox1.Text = Gorod;
                textBox2.Text = Oblast;
            }
        }
    }
}
