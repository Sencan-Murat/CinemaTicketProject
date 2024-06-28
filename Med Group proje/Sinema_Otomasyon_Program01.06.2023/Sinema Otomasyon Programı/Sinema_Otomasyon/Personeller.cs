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

namespace Sinema_Otomasyon
{
    public partial class Personeller : Form
    {
        public Personeller()
        {
            InitializeComponent();


        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=EMRE;Initial Catalog=sqlsinemasonhali;Integrated Security=True");
        SqlDataAdapter adapt = new SqlDataAdapter();
        DataSet set = new DataSet();
        SqlCommand cmd;
        SqlDataReader dr;
        void gridDoldur()
        {
            baglanti = new SqlConnection(@"Data Source=EMRE;Initial Catalog=sqlsinemasonhali;Integrated Security=True");
            adapt = new SqlDataAdapter("select * from Personeller", baglanti);
            set = new DataSet();
            baglanti.Open();
            adapt.Fill(set, "Personeller");
            dataGridView1.DataSource = set.Tables["Personeller"];
            baglanti.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }



        private void Form1_Load(object sender, EventArgs e)
        {
            gridDoldur();

        }

        public void temizle()
        {
            textBox4.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            comboBox3.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            cmd = new SqlCommand("update Personeller set personel_tc=@personel_tc, personel_ad=@personel_ad, personel_soyad=@personel_soyad, personel_gorev=@personel_gorev, personel_shift=@personel_shift, personel_izin=@personel_izin where personel_tc=@personel_tc", baglanti);
            cmd.Parameters.AddWithValue("@personel_tc", textBox2.Text);
            cmd.Parameters.AddWithValue("@personel_ad", textBox4.Text);
            cmd.Parameters.AddWithValue("@personel_soyad", textBox3.Text);
            cmd.Parameters.AddWithValue("@personel_gorev", comboBox1.Text);
            cmd.Parameters.AddWithValue("@personel_shift", comboBox2.Text);
            cmd.Parameters.AddWithValue("@personel_izin", comboBox3.Text);
            cmd.ExecuteNonQuery();
            baglanti.Close();
            gridDoldur();
            temizle();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (textBox2.Text.Length == 11)
            {
                baglanti.Open();
                cmd = new SqlCommand("insert into Personeller(personel_tc, personel_ad, personel_soyad, personel_gorev, personel_shift, personel_izin) values(@personel_tc,@personel_ad,@personel_soyad,@personel_gorev,@personel_shift,@personel_izin)", baglanti);
                cmd.Parameters.AddWithValue("@personel_tc", textBox2.Text);
                cmd.Parameters.AddWithValue("@personel_ad", textBox4.Text);
                cmd.Parameters.AddWithValue("@personel_soyad", textBox3.Text);
                cmd.Parameters.AddWithValue("@personel_gorev", comboBox1.Text);
                cmd.Parameters.AddWithValue("@personel_shift", comboBox2.Text);
                cmd.Parameters.AddWithValue("@personel_izin", comboBox3.Text);
                cmd.ExecuteNonQuery();
                baglanti.Close();

                gridDoldur();
                temizle();
            }
            else
            {
                MessageBox.Show("Ekleyeceğiniz personelin TC numarası 11 haneli olmalıdır!");
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            cmd = new SqlCommand("delete from Personeller where personel_tc=@personel_tc", baglanti);
            cmd.Parameters.AddWithValue("@personel_tc", textBox2.Text);
            cmd.ExecuteNonQuery();
            baglanti.Close();
            gridDoldur();
            temizle();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form yoneticiekrani = new Yonetici_Paneli();
            yoneticiekrani.Show();
            this.Hide();
        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Personeller_Load(object sender, EventArgs e)
        {
            gridDoldur();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}