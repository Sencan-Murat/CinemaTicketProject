using System.Data;
using System.Data.SqlClient;

namespace Sinema_Otomasyon
{
    public partial class Musteri_Paneli : Form
    {

        public Musteri_Paneli()
        {
            string hitap;
            InitializeComponent();
            textBox6.Text = Ana_Ekran.tcnumarasi;
            Satın_Alım.musteritc = textBox6.Text;
            
            
            baglanti.Open();
            cmd = new SqlCommand("select * from Musteriler where musteri_tc= '" + textBox6.Text + "'", baglanti);
            cmd.ExecuteNonQuery();
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                textBox3.Text = dr["musteri_ad"].ToString();
                textBox4.Text = dr["musteri_soyad"].ToString();
                comboBox1.Text = dr["musteri_cinsiyet"].ToString();
                numericUpDown1.Value = Convert.ToInt32(dr["musteri_yas"]);

            }
            if (comboBox1.Text == "erkek")
            {
                hitap = "bey";
            }
            else
            {

                hitap = "hanım";

            }
            label12.Text = textBox3.Text;
            label13.Text = hitap;


            baglanti.Close();

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=EMRE;Initial Catalog=sqlsinemasonhali;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        private void Musteri_Paneli_Load(object sender, EventArgs e)
        {
            gridDoldur();

        }
        


        SqlDataAdapter adapt = new SqlDataAdapter();
        DataSet set = new DataSet();

        void gridDoldur()
        {
            baglanti = new SqlConnection(@"Data Source=EMRE;Initial Catalog=sqlsinemasonhali;Integrated Security=True");
            adapt = new SqlDataAdapter("select * from Satis_Tablosu where musteri_tc=" + textBox6.Text, baglanti);

            set = new DataSet();
            baglanti.Open();
            adapt.Fill(set, "Satis_Tablosu");
            dataGridView1.DataSource = set.Tables["Satis_Tablosu"];
            baglanti.Close();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null && textBox2.Text != null && textBox1.Text == textBox2.Text)
            {
                string sifre = Ana_Ekran.sifre;
                if (sifre == textBox5.Text)
                {
                    baglanti.Open();
                    string kayit = "update Musteriler set musteri_sifre=@musteri_sifre where musteri_tc=@musteri_tc";
                    cmd = new SqlCommand(kayit, baglanti);
                    cmd.Parameters.AddWithValue("@musteri_tc", textBox6.Text);
                    cmd.Parameters.AddWithValue("@musteri_sifre", textBox1.Text);
                    cmd.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Şifreniz başarıyla değiştirildi!");
                }
                else
                {
                    MessageBox.Show("Lütfen bilgilerinizi kontrol ediniz...");
                }

            }
            else
            {
                MessageBox.Show("Lütfen bilgilerinizi kontrol ediniz...");
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form filmler = new Filmler();
            filmler.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form anaekranagit = new Ana_Ekran();
            anaekranagit.Show();
            this.Hide();
        }

        private void button3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            baglanti = new SqlConnection(@"Data Source=EMRE;Initial Catalog=sqlsinemasonhali;Integrated Security=True");
            adapt = new SqlDataAdapter("select * from Satis_Tablosu where musteri_tc=" + textBox6.Text + " order by film_adi asc", baglanti);

            set = new DataSet();
            baglanti.Open();
            adapt.Fill(set, "Satis_Tablosu");
            dataGridView1.DataSource = set.Tables["Satis_Tablosu"];
            baglanti.Close();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            baglanti = new SqlConnection(@"Data Source=EMRE;Initial Catalog=sqlsinemasonhali;Integrated Security=True");
            adapt = new SqlDataAdapter("select * from Satis_Tablosu where musteri_tc=" + textBox6.Text + " order by film_adi desc", baglanti);

            set = new DataSet();
            baglanti.Open();
            adapt.Fill(set, "Satis_Tablosu");
            dataGridView1.DataSource = set.Tables["Satis_Tablosu"];
            baglanti.Close();
        }
        

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
