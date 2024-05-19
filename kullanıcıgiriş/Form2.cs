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
    
    public partial class kullanici_kayit : Form
    {
        SqlConnection baglantı = new SqlConnection("Data Source=DESKTOP-4PM5V54\\SQLEXPRESS;Initial Catalog=kullanıcılar;Integrated Security=True;TrustServerCertificate=True;");

        public kullanici_kayit()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnkayıtol_Click(object sender, EventArgs e)
        {
            baglantı.Open();

            // Kullanıcı adı kontrolü
            SqlCommand kontrolKomut = new SqlCommand("SELECT COUNT(*) FROM tbl_kullanıcı_bilgileri WHERE Kullanıcı_adı = @p3", baglantı);
            kontrolKomut.Parameters.AddWithValue("@p3", txtkayıtkullanıcıadı.Text);
            int kullaniciAdiSayisi = (int)kontrolKomut.ExecuteScalar();

            if (kullaniciAdiSayisi > 0)
            {
                MessageBox.Show("Bu kullanıcı adı zaten kullanımda.");
                return;
            }

            // Telefon numarası uzunluğu kontrolü
            if (txtkayıtnumara.Text.Length < 11)
            {
                MessageBox.Show("Telefon numarası 11 haneden küçük olamaz.");
                return;
            }
            if (txtkayıtnumara.Text.Length>11)
            {
                MessageBox.Show("Telefon numarası 11 haneden büyük olamaz.");
                return;
            }
            SqlCommand komut = new SqlCommand("insert into tbl_kullanıcı_bilgileri (İsim,Soyisim,Kullanıcı_adı,Mail_Adresi,Şifre,Telefon_Numarası) values(@p1,@p2,@p3,@p4,@p5,@p6)", baglantı);
            komut.Parameters.AddWithValue("@p1",txtkayıtisim.Text);
            komut.Parameters.AddWithValue("@p2", txtkayıtsoyisim.Text);
            komut.Parameters.AddWithValue("@p3", txtkayıtkullanıcıadı.Text);
            komut.Parameters.AddWithValue("@p4",txtkayıtmail.Text);
            komut.Parameters.AddWithValue("@p5",txtkayıtsifre.Text);
            komut.Parameters.AddWithValue("@p6", txtkayıtnumara.Text);
           

            komut.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("Kayıt başarılı.Giriş ekranına yönlendiriliyorsunuz.");
            kullanici_giris fr=new kullanici_giris();
            fr.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kullanici_giris frm=new kullanici_giris();
            frm.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void kullanici_kayit_Load(object sender, EventArgs e)
        {

        }

        private void txtkayıtkullanıcıadı_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void ürünTakipEkranıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            urunsayfası frm = new urunsayfası();
            frm.Show();
            this.Hide();
        }

        private void çıkışYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kullanici_giris frm = new kullanici_giris();
            frm.Show();
            this.Hide();
        }

        private void kullanıcılarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

        }
    }
}
