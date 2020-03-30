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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Abonenti f1 = new Abonenti();
            f1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Tarif f1 = new Tarif();
            f1.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Stancii f1 = new Stancii();
            f1.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Razgovori f1 = new Razgovori();
            f1.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void абонентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new View1(bDDataSet, "", "KursachBD.Report1.rdlc", "Abonenti")).ShowDialog();
        }

        private void разговорыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new View2(bDDataSet, "", "KursachBD.Report2.rdlc", "Kto").ShowDialog();
        }

        private void тарифыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new View3(bDDataSet, "", "KursachBD.Report3.rdlc", "Tarif").ShowDialog();
        }

        private void станцииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new View4(bDDataSet, "", "KursachBD.Report4.rdlc", "Stancii").ShowDialog();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Prog f1 = new Prog();
            f1.ShowDialog();
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
