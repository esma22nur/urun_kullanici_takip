using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kullanıcıgiriş
{
    public partial class urunsayfası : Form
    {
        SqlConnection baglantı = new SqlConnection("Data Source=DESKTOP-4PM5V54\\SQLEXPRESS;Initial Catalog=kullanıcılar;Integrated Security=True;TrustServerCertificate=True;");

        public urunsayfası()
        {
            InitializeComponent();
        }

        private void urunsayfası_Load(object sender, EventArgs e)
        {

        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("select * from tbl_ürün", baglantı);            
            SqlDataAdapter da= new SqlDataAdapter(komut);
            DataTable dt= new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglantı.Close();


        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            baglantı.Open();

            SqlCommand komut = new SqlCommand("INSERT INTO tbl_ürün (Ürün_ad, Ürün_Kodu, Ürün_Marka, Ürün_Stok, Ürün_Alıs_Fiyati, Ürün_Satıs_Fiyati, Kategori) VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7)", baglantı);
            komut.Parameters.AddWithValue("@p1", txturunad.Text);
            komut.Parameters.AddWithValue("@p2", txturunkod.Text);
            komut.Parameters.AddWithValue("@p3", txtmarka.Text);
            komut.Parameters.AddWithValue("@p4", Convert.ToInt32( txtstok.Text));
            komut.Parameters.AddWithValue("@p5", Convert.ToInt32(txtalısfiyat.Text));
            komut.Parameters.AddWithValue("@p6", Convert.ToInt32(txtsatısfiyat.Text));
            komut.Parameters.AddWithValue("@p7", tkategori.Text); // Burada @p7 parametresi için txtkategori.Text'i kullandım, çünkü txtmarka.Text tekrarlandı.

            komut.ExecuteNonQuery();
            dataGridView1.DataSource = null; // Mevcut veri kaynağını temizle
            SqlCommand yeniKomut = new SqlCommand("SELECT * FROM tbl_ürün", baglantı);
            SqlDataAdapter adapter = new SqlDataAdapter(yeniKomut);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt; // Yeni veri kaynağını ata
            baglantı.Close();
      
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
           
                baglantı.Open();

                SqlCommand komut = new SqlCommand("UPDATE tbl_ürün SET Ürün_ad=@p1, Ürün_Kodu=@p2, Ürün_Marka=@p3, Ürün_Stok=@p4, Ürün_Alıs_Fiyati=@p5, Ürün_Satıs_Fiyati=@p6, Kategori=@p7 WHERE Ürün_ad=@p1", baglantı);
                komut.Parameters.AddWithValue("@p1", txturunad.Text);
                komut.Parameters.AddWithValue("@p2", txturunkod.Text);
                komut.Parameters.AddWithValue("@p3", txtmarka.Text);
                komut.Parameters.AddWithValue("@p4", Convert.ToInt32(txtstok.Text));
                komut.Parameters.AddWithValue("@p5", Convert.ToDecimal(txtalısfiyat.Text));
                komut.Parameters.AddWithValue("@p6", Convert.ToDecimal(txtsatısfiyat.Text));
                komut.Parameters.AddWithValue("@p7", tkategori.Text);
                komut.ExecuteNonQuery();
                baglantı.Close() ;
                dataGridView1.DataSource = null; // Mevcut veri kaynağını temizle
                SqlCommand yeniKomut = new SqlCommand("SELECT * FROM tbl_ürün", baglantı);
                SqlDataAdapter adapter = new SqlDataAdapter(yeniKomut);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt; // Yeni veri kaynağını ata
                baglantı.Close();
                
           
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("delete from tbl_ürün where Ürün_ad=@p1 or Ürün_Kodu=@p2 or Ürün_Marka=@p3 or Ürün_Stok=@p4 or Ürün_Alıs_Fiyati=@p5 or Ürün_Satıs_Fiyati=@p6 or Kategori=@p7", baglantı);
            komut.Parameters.AddWithValue("@p1", txturunad.Text);
            komut.Parameters.AddWithValue("@p2", txturunkod.Text);
            komut.Parameters.AddWithValue("@p3", txtmarka.Text);
            komut.Parameters.AddWithValue("@p4", Convert.ToInt32(txtstok.Text));
            komut.Parameters.AddWithValue("@p5", Convert.ToDecimal(txtalısfiyat.Text));
            komut.Parameters.AddWithValue("@p6", Convert.ToDecimal(txtsatısfiyat.Text));
            komut.Parameters.AddWithValue("@p7", tkategori.Text);
           
            komut.ExecuteNonQuery();



            dataGridView1.DataSource = null; // Mevcut veri kaynağını temizle
            SqlCommand yeniKomut = new SqlCommand("SELECT * FROM tbl_ürün", baglantı);
            SqlDataAdapter adapter = new SqlDataAdapter(yeniKomut);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt; // Yeni veri kaynağını ata
            baglantı.Close();
            

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txturunad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txturunkod.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtmarka.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            tkategori.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtstok.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtalısfiyat.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtsatısfiyat.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        private void btnara_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("select * from tbl_ürün where Ürün_ad=@p1 or Kategori=@p7 or Ürün_Kodu=@p2 or Ürün_Marka=@p3", baglantı);
            komut.Parameters.AddWithValue("@p1", txturunad.Text);
            komut.Parameters.AddWithValue("@p2", txturunkod.Text);
            komut.Parameters.AddWithValue("@p3", txtmarka.Text);
            komut.Parameters.AddWithValue("@p7", tkategori.Text);
            SqlDataAdapter da= new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglantı.Close();

        }

        private void kullanıcıKayıtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kullanici_kayit  frm= new kullanici_kayit();
            frm.Show();
            this.Hide();
        }

        private void analizlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 frm = new Form4();
            frm.Show();
            this.Hide();
            
        }

        private void ürünTakipEkranıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            urunsayfası frm = new urunsayfası();
            frm.Show();
            this.Hide();
        }

        private void çıkışYapToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            kullanici_giris frm = new kullanici_giris();
            frm.Show();
            this.Hide();
        }

        private void çıkışYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 fr = new Form5();
            fr.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
