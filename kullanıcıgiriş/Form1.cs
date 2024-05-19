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

namespace kullanıcıgiriş
{
    
    public partial class kullanici_giris : Form
    {
        SqlConnection baglantı = new SqlConnection("Data Source=DESKTOP-4PM5V54\\SQLEXPRESS;Initial Catalog=kullanıcılar;Integrated Security=True;TrustServerCertificate=True;");

        public kullanici_giris()
        {
            InitializeComponent();
        }

        private void btnkayıtol_Click(object sender, EventArgs e)
        {
            kullanici_kayit frm=new kullanici_kayit();
            frm.Show();
            this.Hide();
        }

        private void btngirisyap_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM tbl_kullanıcı_bilgileri WHERE Kullanıcı_Adı = @p1 AND Şifre = @p2\r\n", baglantı);
            komut.Parameters.AddWithValue("@p1", txtkullaniciadi.Text);
            komut.Parameters.AddWithValue("@p2", txtsifre.Text);
            SqlDataReader reader = komut.ExecuteReader();
            if (reader.Read())
            {
                urunsayfası fr=new urunsayfası();
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya Şifreniz hatalı.Tekrar deneyiniz!");
            }
            baglantı.Close();
        }
    }
}
