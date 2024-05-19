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

namespace kullanıcıgiriş
{
    public partial class Form5 : Form
    {
        SqlConnection baglantı = new SqlConnection("Data Source=DESKTOP-4PM5V54\\SQLEXPRESS;Initial Catalog=kullanıcılar;Integrated Security=True;TrustServerCertificate=True;");

        public Form5()
        {
            InitializeComponent();
        }
        
       

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            

        }

        private void Form5_Load_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("select * from tbl_kullanıcı_bilgileri", baglantı);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            baglantı.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglantı.Open();

            SqlCommand komut = new SqlCommand("UPDATE tbl_kullanıcı_bilgileri SET İsim=@p1, soyisim=@p2,Kullanıcı_adı=@p3, Mail_Adresi=@p4, Şifre=@p5, Telefon_numarası=@p6 WHERE İsim=@p1", baglantı);
            komut.Parameters.AddWithValue("@p1", txtisim.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyisim.Text);
            komut.Parameters.AddWithValue("@p3", txtkullanıcıadı.Text);
            komut.Parameters.AddWithValue("@p4", txtmail.Text);
            komut.Parameters.AddWithValue("@p5", txtsifre.Text);
            komut.Parameters.AddWithValue("@p6", txttelno.Text);
            
            komut.ExecuteNonQuery();
            baglantı.Close();
            dataGridView2.DataSource = null; // Mevcut veri kaynağını temizle
            SqlCommand yeniKomut = new SqlCommand("SELECT * FROM tbl_kullanıcı_bilgileri", baglantı);
            SqlDataAdapter adapter = new SqlDataAdapter(yeniKomut);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView2.DataSource = dt; // Yeni veri kaynağını ata
            baglantı.Close();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtisim.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtsoyisim.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtkullanıcıadı.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtmail.Text = dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtsifre.Text = dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();
            txttelno.Text = dataGridView2.Rows[e.RowIndex].Cells[6].Value.ToString();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("DELETE FROM tbl_kullanıcı_bilgileri WHERE İsim=@p1 OR Soyisim=@p2 OR Kullanıcı_adı=@p3 OR Mail_Adresi=@p4 OR Şifre=@p5 OR Telefon_numarası=@p6", baglantı);
            komut.Parameters.AddWithValue("@p1", txtisim.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyisim.Text);
            komut.Parameters.AddWithValue("@p3", txtkullanıcıadı.Text);
            komut.Parameters.AddWithValue("@p4", txtmail.Text);
            komut.Parameters.AddWithValue("@p5", txtsifre.Text);
            komut.Parameters.AddWithValue("@p6", txttelno.Text);

            komut.ExecuteNonQuery();

            dataGridView2.DataSource = null; // Mevcut veri kaynağını temizle
            SqlCommand yeniKomut = new SqlCommand("SELECT * FROM tbl_kullanıcı_bilgileri", baglantı);
            SqlDataAdapter adapter = new SqlDataAdapter(yeniKomut);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView2.DataSource = dt; // Yeni veri kaynağını ata
            baglantı.Close();


        }

        private void çıkışYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kullanici_giris frm=new kullanici_giris();  
            frm.Show();
            this.Hide();
        }

        private void ürünTakipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            urunsayfası frm=new urunsayfası();
            frm.Show();
            this.Hide();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("insert into tbl_kullanıcı_bilgileri (isim,soyisim,Kullanıcı_adı,Mail_Adresi,Şifre,Telefon_Numarası) values(@p1, @p2, @p3, @p4, @p5,@p6) ",baglantı);
            komut.Parameters.AddWithValue("@p1", txtisim.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyisim.Text);
            komut.Parameters.AddWithValue("@p3", txtkullanıcıadı.Text);
            komut.Parameters.AddWithValue("@p4", txtmail.Text);
            komut.Parameters.AddWithValue("@p5", txtsifre.Text);
            komut.Parameters.AddWithValue("@p6", txttelno.Text);
            komut.ExecuteNonQuery();
            dataGridView2.DataSource = null; // Mevcut veri kaynağını temizle
            SqlCommand yeniKomut = new SqlCommand("SELECT * FROM tbl_kullanıcı_bilgileri", baglantı);
            SqlDataAdapter adapter = new SqlDataAdapter(yeniKomut);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView2.DataSource = dt; // Yeni veri kaynağını ata
            baglantı.Close();
        }
    }
}
