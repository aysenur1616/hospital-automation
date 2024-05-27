using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Cleveland_Clinic_Project_1
{
    public partial class FrmDoktorveSekreterGirisi : Form
    {
        public FrmDoktorveSekreterGirisi()
        {
            InitializeComponent();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmTanıtım frt = new FrmTanıtım ();
            frt.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkışı Onaylıyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                FrmDoktorveSekreterGirisi frds = new FrmDoktorveSekreterGirisi();
                frds.Show();
            }
        }

        //Sql Baglantısı
        SqlBaglantisi bgl = new SqlBaglantisi();

        private void BtnDoktorGirisYap_Click(object sender, EventArgs e)
        {
            // Doktor Girişi 
            SqlCommand giris = new SqlCommand("Select * From Tbl_Doktor Where DoktorTC =@p1 and DoktorSifre = @p2",bgl.baglanti());
            giris.Parameters.AddWithValue("@p1", MskDoktorTc.Text);
            giris.Parameters.AddWithValue("@p2", MskDoktorSifre.Text);
            SqlDataReader dr = giris.ExecuteReader();
            if(dr.Read())
            {
                FrmDoktorAnaSayfa frdas = new FrmDoktorAnaSayfa();
                frdas.DOKTORTC = MskDoktorTc.Text;
                frdas.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş Yaptınız\nTekrar Deneyiniz!","Hatalı Giriş",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void BtnSekreterGirisYap_Click(object sender, EventArgs e)
        {
            // Sekreter Girişi

            SqlCommand giris = new SqlCommand("Select * From Tbl_Sekreter Where KurumsalNo =@p1 and SektreterParola = @p2", bgl.baglanti());
            giris.Parameters.AddWithValue("@p1", MskKurumsalNo.Text);
            giris.Parameters.AddWithValue("@p2", MskSekreterParola.Text);
            SqlDataReader dr = giris.ExecuteReader();
            if (dr.Read())
            {
                FrmSekreterAnaSayfa frsas = new FrmSekreterAnaSayfa();
                frsas.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş Yaptınız\nTekrar Deneyiniz!", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
