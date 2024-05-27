using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cleveland_Clinic_Project_1
{
    public partial class FrmTanıtım : Form
    {
        public FrmTanıtım()
        {
            InitializeComponent();
        }

  
        private void BtnHakimizda_Click(object sender, EventArgs e)
        {
            FrmHakkimizda frh = new FrmHakkimizda();
            frh.Show();
            this.Hide();
        }

        private void BtnIletisim_Click(object sender, EventArgs e)
        {
            FrmIletisimkonumsecim frmiks = new FrmIletisimkonumsecim();
            frmiks.Show();
            this.Hide();
        }

        private void BtnKonumveYol_Click(object sender, EventArgs e)
        {
            // KONUMA GİDİYOR 
            System.Diagnostics.Process.Start("https://www.google.com/maps/dir//Carnegie+Ave,+Cleveland,+OH+44103,+Amerika+Birle%C5%9Fik+Devletleri/@41.501319,-81.7367244,12z/data=!4m8!4m7!1m0!1m5!1m1!1s0x8830fa56c04865fd:0x87ee15779c2bf65f!2m2!1d-81.6543236!2d41.5013484?entry=ttu"); 
        }

        private void BtnNedenBiz_Click(object sender, EventArgs e)
        {
            FrmIletisimkonumsecim frmiks = new FrmIletisimkonumsecim();
            frmiks.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Çıkışı Onaylıyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                FrmTanıtım frt =new FrmTanıtım();
                frt.Show();
            }
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Haberin olduğu adrese gidiyor 
            System.Diagnostics.Process.Start("https://newsroom.clevelandclinic.org/2023/09/20/cleveland-clinic-names-dr-jamanda-haddock-chief-of-staff-for-cleveland-clinic-london/");
        }
        private void BtnHaber1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://newsroom.clevelandclinic.org/2023/09/20/cleveland-clinic-names-dr-jamanda-haddock-chief-of-staff-for-cleveland-clinic-london/");
        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Haberin olduğu adrese gidiyor 
            System.Diagnostics.Process.Start("https://newsroom.clevelandclinic.org/2023/09/15/cleveland-clinic-london-is-the-first-private-hospital-in-the-uk-to-be-awarded-with-himss-emram-stage-6-accreditation/");
        }
        private void BtnHaber2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://newsroom.clevelandclinic.org/2023/09/15/cleveland-clinic-london-is-the-first-private-hospital-in-the-uk-to-be-awarded-with-himss-emram-stage-6-accreditation/");
        }
        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Haberin olduğu adrese gidiyor 
            System.Diagnostics.Process.Start("https://newsroom.clevelandclinic.org/2023/08/24/about-cleveland-clinic-london/");
        }

        private void BtnHaber3_Click(object sender, EventArgs e)
        {
             System.Diagnostics.Process.Start("https://newsroom.clevelandclinic.org/2023/08/24/about-cleveland-clinic-london/");
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Haberin olduğu adrese gidiyor 
            System.Diagnostics.Process.Start("https://newsroom.clevelandclinic.org/2023/08/16/cleveland-clinic-london-patient-receives-londons-first-total-knee-replacement-surgery-assisted-by-augmented-reality/");
        }

        private void BtnHaber4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://newsroom.clevelandclinic.org/2023/08/16/cleveland-clinic-london-patient-receives-londons-first-total-knee-replacement-surgery-assisted-by-augmented-reality/");
        }

        private void BtnHastaGiris_Click(object sender, EventArgs e)
        {
            FrmHastaGiris frg = new FrmHastaGiris();
            frg.Show();
            this.Hide();
        }

        private void BtnDoktorGiris_Click(object sender, EventArgs e)
        {
            FrmDoktorveSekreterGirisi frds = new FrmDoktorveSekreterGirisi  ();
            frds.Show();    
            this.Hide();
        }

        private void BtnSekreterGiris_Click(object sender, EventArgs e)
        {
            FrmDoktorveSekreterGirisi frds = new FrmDoktorveSekreterGirisi();
            frds.Show();
            this.Hide();
        }
    }
}
