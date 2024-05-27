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
    public partial class FrmDoktorAnaSayfa : Form
    {
        public FrmDoktorAnaSayfa()
        {
            InitializeComponent();
        }

        // SQL BAĞLANTISI 
        SqlBaglantisi bgl = new SqlBaglantisi();

        public string DOKTORTC;
        public string HastaTC;
        public string DoktorAdSoyad;

        void Temizle()
        {
            TxtHastaId.Text = " ";
            TxtAd.Text = " ";
            TxtSoyad.Text = " ";
            TxtCinsiyet.Text = " ";
            TxtKanGrubu.Text = " ";
            TxtTC.Text = " ";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Çift tıklanan verinin seçilmesi
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            TxtTC.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();

            // Hasta Bilgilerini TextBox'lara Aktarma 

            SqlCommand komut01 = new SqlCommand("Select HastaID, HastAd, HastaSoyad, HastaCinsiyet, HastaDogumTarihi, HastaKanGrubu From Tbl_Hasta Where HastaTCKimlik =" + TxtTC.Text, bgl.baglanti());
            SqlDataReader DR1 = komut01.ExecuteReader();
            while (DR1.Read())
            {
                TxtHastaId.Text = DR1[0].ToString();
                TxtAd.Text = DR1[1].ToString();
                TxtSoyad.Text = DR1[2].ToString();
                TxtCinsiyet.Text = DR1[3].ToString();
                TXxtDogumTarihi.Text = DR1[4].ToString();
                TxtKanGrubu.Text = DR1[5].ToString();
            }
            bgl.baglanti().Close();
        }

        private void FrmDoktorAnaSayfa_Load(object sender, EventArgs e)
        {
            // Doktor TC Çekme 
           LblDoktorTC.Text = DOKTORTC;
           LblHastaTC.Text= HastaTC;
           LblAdSoyad.Text = DoktorAdSoyad;
           


            // Doktor Adını Getirme 
            SqlCommand komut = new SqlCommand("Select DoktorAd ,DoktorSoyad From Tbl_Doktor  Where DoktorTC=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", DOKTORTC);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                LblAdSoyad.Text = dr[0] + " " + dr[1];

            }
            bgl.baglanti().Close();


            // Doktora Ait Randevuları DataGride'e Çekme 
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select HastaTC, HastaAdSoyad, RandevuTarih, RandevuSaat From Tbl_Randevular Where DoktorTC ='" + DOKTORTC + "'",bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // TextBox'da yazılı verileri temizleme 
            Temizle();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {

            // Hasta Recete Tanı Rapor Bilgilerini Girme 
            SqlCommand KomuT = new SqlCommand("Insert into Tbl_RaporRecete (HastaTC, HastaTeshis, HastaRecete, HastaRapor, BaslangicTarihi, BitisTarihi) values(@p1,@p2,@p3,@p4,@p5,@p6)", bgl.baglanti());
            KomuT.Parameters.AddWithValue("@p1", TxtTC.Text);
            KomuT.Parameters.AddWithValue("@p2", RchTxtTanı.Text);
            KomuT.Parameters.AddWithValue("@p3", TxtRecete.Text);
            KomuT.Parameters.AddWithValue("@p4", MskRapor.Text);
            KomuT.Parameters.AddWithValue("@p5", MskBaslangicT.Text);
            KomuT.Parameters.AddWithValue("@p6", MskBitisT.Text);

            KomuT.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Bilgiler Başarıyla Eklendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            FrmTanıtım frm = new FrmTanıtım();
            frm.Show();
            this.Hide();
            

        }
    }
}
