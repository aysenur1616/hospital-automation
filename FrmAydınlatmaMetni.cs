using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cleveland_Clinic_Project_1
{
    public partial class FrmAydınlatmaMetni : Form
    {
        public FrmAydınlatmaMetni()
        {
            InitializeComponent();
        }

       // Sql Bağlantısı
        SqlBaglantisi bgl = new SqlBaglantisi();

        public string TCKİMLİK;

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            FrmHastaAnaSayfa fr = new FrmHastaAnaSayfa();
            fr.TC = LblTC.Text;
            fr.Show();
            this.Hide();
        }

        
        private void FrmAydınlatmaMetni_Load(object sender, EventArgs e)
        {
            // Hasta TC Çekme 
            LblTC.Text = TCKİMLİK;

            // Hasta Ad Soyad Çekme 

            SqlCommand Komut1 = new SqlCommand("Select HastaAdSoyad From Tbl_Randevular Where HastaTC=" + TCKİMLİK, bgl.baglanti());
            SqlDataReader dr1 = Komut1.ExecuteReader();
            while (dr1.Read())
            {
                LblAdSoyad.Text = dr1[0].ToString();
            }
            bgl.baglanti().Close();

        }
    }
}
