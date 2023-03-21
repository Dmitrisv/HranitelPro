using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HranitelPro
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            PersonalVisit personalVisit = new PersonalVisit();
            this.Close();
            personalVisit.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

            PersonalVisit personalVisit = new PersonalVisit();
            this.Close();
            personalVisit.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

            GroupVisit groupVisit = new GroupVisit();
            this.Close();
            groupVisit.Show();
        }
    }
}
