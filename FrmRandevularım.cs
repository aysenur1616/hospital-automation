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
    public partial class FrmRandevularım : Form
    {
        public FrmRandevularım()
        {
            InitializeComponent();
        }


        public string TCKimlik;
        // Sql Bağlantsı
        SqlBaglantisi bgl = new SqlBaglantisi();
       

        private void FrmRandevularım_Load(object sender, EventArgs e)
        {
            // Hasta TC Çekme 
            LblHastaTC.Text = TCKimlik;

            // Hasta Ad Soyad Çekme 

            SqlCommand Komut1 = new SqlCommand("Select HastaAdSoyad From Tbl_Randevular Where HastaTC=" + TCKimlik , bgl.baglanti());
            SqlDataReader dr = Komut1.ExecuteReader();
            while (dr.Read())
            {
                LblAdSoyad.Text = dr[0].ToString();
            }
            bgl.baglanti().Close();

            // Hastanın Randevularını DataGride'e Çekme
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select HastaTC, HastaAdSoyad, RandevuTarih, RandevuSaat,RandevuPoliklinik,RandevuDoktor From Tbl_Randevular Where RandevuTarih > '03.01.2024' and HastaTC =" + TCKimlik, bgl.baglanti());
            
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            FrmHastaAnaSayfa frhas = new   FrmHastaAnaSayfa();
            frhas.TC = LblHastaTC.Text;
            frhas.Show();
            this.Hide();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
