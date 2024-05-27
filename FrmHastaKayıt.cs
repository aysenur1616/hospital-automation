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
    public partial class FrmHastaKayıt : Form
    {
        public FrmHastaKayıt()
        {
            InitializeComponent();
        }

        // Sql Baglantısı
        SqlBaglantisi bgl = new SqlBaglantisi();    

  

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmHastaGiris frhg = new FrmHastaGiris();
            frhg.Show();
            this.Hide();
        }

        private void BtnHastaKayıtEtme_Click(object sender, EventArgs e)
        {
            // Hasta Kayıt 

            SqlCommand kayıt = new SqlCommand("insert into Tbl_Hasta (HastAd,HastaSoyad,HastaCinsiyet,HastaDogumTarihi,HastaTCKimlik,HastaKanGrubu,HastaTelefon,HastaEmail,HastaSifre) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", bgl.baglanti());
            kayıt.Parameters.AddWithValue("@p1", TxtAd.Text);
            kayıt.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            kayıt.Parameters.AddWithValue("@p3", CmbCinsiyet.Text);
            kayıt.Parameters.AddWithValue("@p4", MskDogumtarihi.Text);
            kayıt.Parameters.AddWithValue("@p5", MskHastaTC.Text);
            kayıt.Parameters.AddWithValue("@p6", CmbKanGrubu.Text);
            kayıt.Parameters.AddWithValue("@p7", MskTelefonNo.Text);
            kayıt.Parameters.AddWithValue("@p8", MskMail.Text);
            kayıt.Parameters.AddWithValue("@p9", MskParola.Text);

            kayıt.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kaydınız Başarıyla Tamamlanmıştır", "KAYIT ONAY",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
