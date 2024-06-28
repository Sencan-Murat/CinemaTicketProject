using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace Sinema_Otomasyon

{
    public partial class Ana_Ekran : Form
    {
        public static string tcnumarasi;
        public static string sifre;
        public Ana_Ekran()
        {
            InitializeComponent();

        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=EMRE;Initial Catalog=sqlsinemasonhali;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Giris_btn_Click(object sender, EventArgs e)
        {
            string sorgu = "SELECT * FROM Musteriler where musteri_tc=@musteri_tc AND musteri_sifre=@musteri_sifre";
            cmd = new SqlCommand(sorgu, baglanti);
            cmd.Parameters.AddWithValue("@musteri_tc", textBox1.Text);
            tcnumarasi = textBox1.Text;
            cmd.Parameters.AddWithValue("@musteri_sifre", textBox2.Text);
            sifre = textBox2.Text;
            baglanti.Open();

            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Tebrikler! Baþarýlý bir þekilde giriþ yaptýnýz.");
                formdegistir();
            }
            else
            {
                MessageBox.Show("Girilen bilgilere ait bir müþteri kaydý bulunamamýþtýr");
            }
            baglanti.Close();

        }

        public void formdegistir()
        {
            Form musteri_panel = new Musteri_Paneli();
            musteri_panel.Show();
            this.Hide();
        }
        private void Ana_Ekran_Load(object sender, EventArgs e)
        {

        }

        private void Kayit_btn_Click(object sender, EventArgs e)
        {
            if (Kayit_Grpbox.Visible == true)
            {
                Kayit_Grpbox.Visible = false;
            }
            else
            {
                Kayit_Grpbox.Visible = true;
            }
        }

        public void kayitEkle()
        {
            try
            {
                baglanti.Close();
                baglanti.Open();
                string kayit = "insert into Musteriler(musteri_tc,musteri_ad,musteri_soyad,musteri_cinsiyet,musteri_yas,musteri_sifre) values (@p1,@p2,@p3,@p4,@p5,@p6)";
                SqlCommand ekle = new SqlCommand(kayit, baglanti);
                ekle.Parameters.AddWithValue("@p1", textBox6.Text);
                ekle.Parameters.AddWithValue("@p2", textBox3.Text);
                ekle.Parameters.AddWithValue("@p3", textBox4.Text);
                ekle.Parameters.AddWithValue("@p4", comboBox1.Text);
                ekle.Parameters.AddWithValue("@p5", numericUpDown1.Value);
                ekle.Parameters.AddWithValue("@p6", textBox5.Text);
                ekle.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kayit basariyla olusturuldu!");
                textBox6.Clear();
                textBox3.Clear();
                textBox4.Clear();
                comboBox1.Text = "";
                numericUpDown1.Text = "";
                textBox5.Clear();
            }
            catch (System.Data.SqlClient.SqlException)
            {
                MessageBox.Show("Ayný TC ile Bir kayýt mevcut, Kaydýnýz oluþturulamadý.");

            }
            finally
            {
                baglanti.Close();
            
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox6.Text.Length !=11)
            {
                MessageBox.Show("TC Numaranýz 11 haneli olmalýdýr.");
            }
            else if (numericUpDown1.Value < 18)
            {
                MessageBox.Show("Üyelik açabilmek için 18 yaþ üzeri olmanýz gerekmektedir!");
            }
            else if (comboBox1.Text!="erkek"&& comboBox1.Text != "kadin")
            {
                MessageBox.Show("Cinsiyet Seçiminiz hatalý");
            }
            else
            {
                kayitEkle();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sorgu = "SELECT * FROM Yoneticiler where yonetici_tc=@yonetici_tc AND yonetici_sifre=@yonetici_sifre";
            cmd = new SqlCommand(sorgu, baglanti);
            cmd.Parameters.AddWithValue("@yonetici_tc", textBox1.Text);
            cmd.Parameters.AddWithValue("@yonetici_sifre", textBox2.Text);
            baglanti.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Tebrikler! Baþarýlý bir þekilde giriþ yaptýnýz.");
                Form yonetici = new Yonetici_Paneli();
                yonetici.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Girilen bilgilere ait bir yönetici kaydý bulunamamýþtýr");
            }
            baglanti.Close();
        }

        private void Ana_Ekran_Load_1(object sender, EventArgs e)
        {

        }

        private void button2_Enter(object sender, EventArgs e)
        {

        }

        private void Kayit_Grpbox_Enter(object sender, EventArgs e)
        {

        }
    }
}