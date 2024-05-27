using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cleveland_Clinic_Project_1
{
    public partial class FrmIletisimkonumsecim : Form
    {
        public FrmIletisimkonumsecim()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmTanıtım frt = new FrmTanıtım ();
            frt.Show();
            this.Hide();
        }

   
    }
}
