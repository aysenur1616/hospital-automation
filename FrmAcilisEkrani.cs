using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cleveland_Clinic_Project_1
{
    public partial class FrmAcilisEkrani : Form
    {
        public FrmAcilisEkrani()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(2);

            if(progressBar1.Value == 100 ) 
            {
                timer1.Stop();
                this.Close();
                FrmTanıtım frt = new FrmTanıtım();
                frt.Show();
            }
        }

        private void FrmAcilisEkrani_Load(object sender, EventArgs e)
        {
          




        }
    }
}
