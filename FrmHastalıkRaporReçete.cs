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
    public partial class FrmHastalıkRaporReçete : Form
    {
        public FrmHastalıkRaporReçete()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();

        public string HastaTc;
        private void FrmHastalıkRaporReçete_Load(object sender, EventArgs e)
        {
            // TC ÇEKME 
            LblHastaTC.Text = HastaTc;

            // Hasta Ad Soyad Çekme
            SqlCommand komut9 = new SqlCommand("Select HastaAdSoyad From Tbl_Randevular Where HastaTC=" + HastaTc, bgl.baglanti());
            SqlDataReader dr9 = komut9.ExecuteReader();
            while (dr9.Read())
            {
                LblAdSoyad.Text = dr9[0].ToString();
            }
            bgl.baglanti().Close();

            //DataGrid'lere verileri çekme ( tanı reçete rapor)
            DataTable dataTable = new DataTable();  
            SqlDataAdapter dA = new SqlDataAdapter("Select HastaTeshis From Tbl_RaporRecete Where HastaTC="+ HastaTc,bgl.baglanti());
            dA.Fill(dataTable);
            dgvHastaliklarim.DataSource = dataTable;

            DataTable dataTAble = new DataTable();
            SqlDataAdapter DataA = new SqlDataAdapter("Select HastaRecete From Tbl_RaporRecete Where HastaTC=" + HastaTc, bgl.baglanti());
            DataA.Fill(dataTAble);
            dgvRecetelerim.DataSource = dataTAble;

            DataTable dataTABLE = new DataTable();
            SqlDataAdapter dADAPTER = new SqlDataAdapter("Select HastaRapor,BaslangicTarihi,BitisTarihi From Tbl_RaporRecete Where HastaTC=" + HastaTc, bgl.baglanti());
            dADAPTER.Fill(dataTABLE);
            dgvRaporlarim.DataSource = dataTABLE;


        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmHastaAnaSayfa frhastaana = new FrmHastaAnaSayfa();
            frhastaana.TC = LblHastaTC.Text;
            frhastaana.Show();
            this.Hide();
        }
    }
}
