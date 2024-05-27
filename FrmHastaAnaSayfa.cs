

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
using System.Security.AccessControl;
using System.Globalization;

namespace Cleveland_Clinic_Project_1
{
    public partial class FrmHastaAnaSayfa : Form
    {
        public FrmHastaAnaSayfa()
        {
            InitializeComponent();
        }

        // SQL BAĞANTISI 
        SqlBaglantisi bgl = new SqlBaglantisi();
        private void BtnZiyaretlerim_Click(object sender, EventArgs e)
        {
            FrmZiyaretlerim frz = new FrmZiyaretlerim();
            frz.Tc = LblTc.Text;
            frz.Show();
            this.Hide();
        }

        // Temizleme Metodu Oluşturma 

        void Temizle()
        {
            CmbPoliklinik.Text = "";
            CmbHekim.Text = "";
            MskRandevuSaat.Text = "";
            MskRandevuTarih.Text = "";
        }



        public string TC;
        private void FrmHastaAnaSayfa_Load(object sender, EventArgs e)
        {
            // TC Çekme İşlemi 
            LblTc.Text = TC;

            // Ad Soyad Çekme 
            SqlCommand komut9 = new SqlCommand("Select HastaAdSoyad From Tbl_Randevular Where HastaTC=" + TC, bgl.baglanti());
            SqlDataReader dr = komut9.ExecuteReader();
            while (dr.Read())
            {
                LblAdSoyad.Text = dr[0].ToString();
            }
            bgl.baglanti().Close();


            // ComboBox'a  Poliklinikleri Getirme 
            SqlCommand Komut2 = new SqlCommand("Select PoliklinikAd From Tbl_Poliklinik", bgl.baglanti());
            SqlDataReader dr2 = Komut2.ExecuteReader();
            while(dr2.Read())
            {
                CmbPoliklinik.Items.Add(dr2[0]);
            }
            bgl.baglanti() .Close();

            // Kişisel Özellikleri Label'lara Aktarma 
            SqlCommand sqlCommand = new SqlCommand("Select HastaAdSoyad,HastaYas,HastaKilo,HastaBoy From Tbl_HastaKisiselOzellikler Where HastaTC ="+ TC , bgl.baglanti());    
            SqlDataReader dr0 = sqlCommand.ExecuteReader();
            while(dr0.Read())
            {
                LblAdSoyad.Text = dr0[0].ToString();
                LblYas.Text = dr0[1].ToString();
                LblKilo.Text = dr0[2].ToString();
                LblBoy.Text = dr0[3].ToString();
            }
            bgl.baglanti() .Close();


            //Hastaya Ait Fotografları Getirme 

            /*SqlCommand komutf = new SqlCommand("Select HastaFotograf From Tbl_HastaKisiselOzellikler Where HastaTC="+TC ,bgl.baglanti());
            SqlDataReader drf = komutf.ExecuteReader();
            while (drf.Read())
            {
               // pictureBox8.DataBindings= dr[0];
            }*/
        }

        private void BtnAydınlatmaMetni_Click(object sender, EventArgs e)
        {
            FrmAydınlatmaMetni fr = new FrmAydınlatmaMetni();
            fr.TCKİMLİK=LblTc.Text; 
            fr.Show();
            this.Hide();
        }

        private void BtnRandevularım_Click(object sender, EventArgs e)
        {
            FrmRandevularım fr = new FrmRandevularım();
            fr.TCKimlik = LblTc.Text;
            fr.Show();
            this.Hide();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
         FrmTanıtım fr = new FrmTanıtım ();
            fr.Show();
            this.Hide();
        }

        private void CmbPoliklinik_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Seçilen Poliklinğe Göre ComboBox'a Doktorları Getirme 

            CmbHekim.Items.Clear();
            SqlCommand Komut3 = new SqlCommand("Select DoktorTC, DoktorAd,DoktorSoyad From Tbl_Doktor Where DoktorBrans = @p1", bgl.baglanti());
            Komut3.Parameters.AddWithValue("@p1", CmbPoliklinik.Text);
            SqlDataReader dr3 = Komut3.ExecuteReader();
            while (dr3.Read())
            {
                CmbHekim.Items.Add(dr3[1] + " " + dr3[2]); 
                
            }
            

            bgl.baglanti().Close();
        }

        private void BtnRandevuOlustur_Click(object sender, EventArgs e)
        {
            //Seçilen doktorun TC'sini getirme 

            SqlCommand Komutt3 = new SqlCommand("Select DoktorTC From Tbl_DoktorYedek Where DoktorAdSoyad = @p1", bgl.baglanti());
            Komutt3.Parameters.AddWithValue("@p1", CmbHekim.Text);
            SqlDataReader dr33 = Komutt3.ExecuteReader();
            while (dr33.Read())
            {
                LblDoktorrtc.Text = dr33[0].ToString();
            }
            bgl.baglanti().Close();

            // Randevu Oluşturma 
            SqlCommand komut4 = new SqlCommand("Insert into Tbl_Randevular (HastaTC, HastaAdSoyad,RandevuTarih,RandevuSaat,RandevuPoliklinik,RandevuDoktor,DoktorTC) values(@p1,@p2,@p3,@p4,@p5,@p6,@p7)", bgl.baglanti());
            komut4.Parameters.AddWithValue("@p1", LblTc.Text);
            komut4.Parameters.AddWithValue("@p2", LblAdSoyad.Text);
            komut4.Parameters.AddWithValue("@p3", MskRandevuTarih.Text);
            komut4.Parameters.AddWithValue("@p4", MskRandevuSaat.Text);
            komut4.Parameters.AddWithValue("@p5", CmbPoliklinik.Text);
            komut4.Parameters.AddWithValue("@p6", CmbHekim.Text);
            komut4.Parameters.AddWithValue("@p7", LblDoktorrtc.Text);

            komut4.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Randevunuz Başarıyla Oluşturulmuştur.\nRandevuya gidememe durumunda randevunu iptal etmeyi ununtmayınız");
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void BtnHastalıklarım_Click(object sender, EventArgs e)
        {
            FrmHastalıkRaporReçete frm = new FrmHastalıkRaporReçete();
            frm.HastaTc=LblTc.Text;
            frm.Show();
            this.Hide();
        }

        private void BBtnRaporlarım_Click(object sender, EventArgs e)
        {
            FrmHastalıkRaporReçete frm = new FrmHastalıkRaporReçete();
            frm.HastaTc = LblTc.Text;
            frm.Show();
            this.Hide();

        }

        private void BtnRecetelerim_Click(object sender, EventArgs e)
        {
            FrmHastalıkRaporReçete frm = new FrmHastalıkRaporReçete();
            frm.HastaTc = LblTc.Text;
            frm.Show();
            this.Hide();
        }

    }
}
