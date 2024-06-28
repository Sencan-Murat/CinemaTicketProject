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

namespace Sinema_Otomasyon
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form geridon = new Yonetici_Paneli();
            geridon.Show();
            this.Hide();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=EMRE;Initial Catalog=sqlsinemasonhali;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter adapt;
        DataSet set;

        void gridDoldur()
        {
            adapt = new SqlDataAdapter("select * from Filmler", baglanti);
            set = new DataSet();
            baglanti.Open();
            adapt.Fill(set, "Filmler");
            dataGridView1.DataSource = set.Tables["Filmler"];
            baglanti.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            gridDoldur();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            cmd = new SqlCommand("insert into Filmler(film_adi, film_tanitim_metni, film_tur, film_yonetmen, film_sure, film_no, film_kapak) values(@p1,@p2,@p3,@p4,@p5,@p6,@p7)", baglanti);
            cmd.Parameters.AddWithValue("@p1", textBox1.Text);
            cmd.Parameters.AddWithValue("@p2", textBox2.Text);
            cmd.Parameters.AddWithValue("@p3", textBox5.Text);
            cmd.Parameters.AddWithValue("@p4", textBox4.Text);
            cmd.Parameters.AddWithValue("@p5", textBox6.Text);
            cmd.Parameters.AddWithValue("@p6", textBox3.Text);
            cmd.Parameters.AddWithValue("@p7", textBox7.Text);
            cmd.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Film başarıyla eklenmiştir!");
            gridDoldur();
            temizle();
        }

        public void temizle()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            pictureBox1.Image = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox3.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            pictureBox1.ImageLocation = textBox7.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            cmd = new SqlCommand("delete from Filmler where film_no=@film_no", baglanti);
            cmd.Parameters.AddWithValue("@film_no", textBox3.Text);
            cmd.ExecuteNonQuery();
            baglanti.Close();
            gridDoldur();
            temizle();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            cmd = new SqlCommand("update Filmler set film_adi=@p1, film_tanitim_metni=@p2, film_tur=@p3, film_yonetmen=@p4, film_sure=@p5, film_kapak=@p8, film_no=@p7 where film_no=@p6", baglanti);
            cmd.Parameters.AddWithValue("@p1", textBox1.Text);
            cmd.Parameters.AddWithValue("@p2", textBox2.Text);
            cmd.Parameters.AddWithValue("@p3", textBox5.Text);
            cmd.Parameters.AddWithValue("@p4", textBox4.Text);
            cmd.Parameters.AddWithValue("@p5", textBox6.Text);
            cmd.Parameters.AddWithValue("@p6", textBox3.Text);
            cmd.Parameters.AddWithValue("@p7", textBox3.Text);
            cmd.Parameters.AddWithValue("@p8", textBox7.Text);
            cmd.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Film bilgileri başarıyla güncellendi!");
            gridDoldur();
            temizle();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
            textBox7.Text = openFileDialog1.FileName;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            textBox7.Clear();
        }
    }
}
