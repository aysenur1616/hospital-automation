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
    public partial class FrmSekreterAnaSayfa : Form
    {
        public FrmSekreterAnaSayfa()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();    

        private void FrmSekreterAnaSayfa_Load(object sender, EventArgs e)
        {
            


        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Doktor ",bgl.baglanti());
            da.Fill(dt);    
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable ddt1 = new DataTable();
            SqlDataAdapter dda1 = new SqlDataAdapter("Select * From Tbl_Hasta", bgl.baglanti());
            dda1.Fill(ddt1);    
            dataGridView1.DataSource= ddt1;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataTable dtt2 = new DataTable();
            SqlDataAdapter dat2 = new SqlDataAdapter("Select * From Tbl_Randevular", bgl.baglanti());
            dat2.Fill(dtt2);
            dataGridView1.DataSource= dtt2;
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            FrmTanıtım frt = new FrmTanıtım();
            frt.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            Font myfont = new Font("Palatino Linotype",15);
            textBox1.Font = myfont;
            textBox1.ForeColor = Color.DarkSlateGray;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable datat1= new DataTable();
            SqlDataAdapter data1a = new SqlDataAdapter("Select * From Tbl_PersonelKadrosu ", bgl.baglanti());
            data1a.Fill(datat1);
            dataGridView1.DataSource = datat1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Insert into Tbl_Duyurular (DuyuruTarihi , Duyuru) values (@p1,@p2)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@p2", richTextBox1.Text);

            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Duyuru başarıyla eklendi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void richTextBox1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            Font myyfont = new Font("Palatino Linotype", 13);
            richTextBox1.Font = myyfont;
            richTextBox1.ForeColor = Color.DarkSlateGray;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DataTable dyrtbl = new DataTable();
            SqlDataAdapter dyra = new SqlDataAdapter("Select * From Tbl_Duyurular ", bgl.baglanti());
            dyra.Fill(dyrtbl);
            dataGridView1.DataSource= dyrtbl;
            
        }

   
    }
}
