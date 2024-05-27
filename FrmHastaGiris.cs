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
    public partial class FrmHastaGiris : Form
    {
        public FrmHastaGiris()
        {
            InitializeComponent();
        }

        // Sql baglantisi 
        SqlBaglantisi bgl = new SqlBaglantisi(); 
         
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmTanıtım frt = new FrmTanıtım ();
            frt.Show();
            this.Hide();
        }

        private void BtnHastaKayıt_Click(object sender, EventArgs e)
        {
            FrmHastaKayıt frk = new FrmHastaKayıt();
            frk.Show();
            this.Hide();
        }

        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            // Hasta Giris 

            SqlCommand giriskontrol =new SqlCommand("Select * From Tbl_Hasta Where HastaTCKimlik = @p1 and HastaSifre = @p2",bgl.baglanti());
            giriskontrol.Parameters.AddWithValue("@p1", MskTCKimlik.Text);
            giriskontrol.Parameters.AddWithValue("@p2", MskParola.Text);
            SqlDataReader dr = giriskontrol.ExecuteReader();
            if(dr.Read())
            {
                FrmHastaAnaSayfa fr = new FrmHastaAnaSayfa();
                fr.TC = MskTCKimlik.Text;
                fr.Show();   
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı veya yanlış giriş yaptınız.\nKontrol edip tekrar deneyiniz", "HATALI GİRİŞ",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            bgl.baglanti().Close();
        }
      
    }
}
