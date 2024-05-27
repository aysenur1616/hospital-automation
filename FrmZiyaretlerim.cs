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
using System.Data.Common;

namespace Cleveland_Clinic_Project_1
{
    public partial class FrmZiyaretlerim : Form
    {
        public FrmZiyaretlerim()
        {
            InitializeComponent();
        }

        public string Tc;
        SqlBaglantisi bgl = new SqlBaglantisi();
       
        private void FrmZiyaretlerim_Load(object sender, EventArgs e)
        {
            // Tc Çekme 
           LblTC.Text = Tc;

            // Ad Soyad Çekme 
            SqlCommand Komut = new SqlCommand("Select HastaAdSoyad From Tbl_Ziyaretlerim Where HastaTC="+Tc,bgl.baglanti());
            Komut.Parameters.AddWithValue("@p1", LblTC.Text);
            SqlDataReader dr = Komut.ExecuteReader();
            while (dr.Read()) 
            {
                LblAdSoyad.Text = dr[0].ToString();
            }
            bgl.baglanti().Close();

            // Hastanın hastane ziyartelerini DataGride'e Çekme 
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Randevular Where RandevuTarih < '03.01.2024' and  HastaTC=" + Tc, bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            


        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            FrmHastaAnaSayfa fr = new FrmHastaAnaSayfa  ();
            fr.TC= LblTC.Text;  
            fr.Show();
            this.Hide();
        }
    }
}
