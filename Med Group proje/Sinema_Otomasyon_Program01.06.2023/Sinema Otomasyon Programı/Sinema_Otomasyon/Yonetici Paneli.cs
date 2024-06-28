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
    public partial class Yonetici_Paneli : Form
    {
        public Yonetici_Paneli()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=EMRE;Initial Catalog=sqlsinemasonhali;Integrated Security=True");
        SqlDataAdapter adapt = new SqlDataAdapter();
        DataSet set = new DataSet();
        SqlCommand cmd;
        SqlDataReader dr;



        private void button1_Click(object sender, EventArgs e)
        {
            gridDoldur();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {


            if (checkBox1.Checked && checkBox2.Checked)
            {
                MessageBox.Show("İki filtrelemeyi aynı anda seçemezsiniz!");
            }
            else if (checkBox1.Checked)
            {
                adapt = new SqlDataAdapter("select * from Satis_Tablosu where musteri_tc='" + textBox1.Text + "'", baglanti);
                set = new DataSet();
                baglanti.Open();
                adapt.Fill(set, "Satis_Tablosu");
                dataGridView1.DataSource = set.Tables["Satis_Tablosu"];
                baglanti.Close();
            }
            else if (checkBox2.Checked)
            {
                adapt = new SqlDataAdapter("select * from Satis_Tablosu where film_adi='" + textBox2.Text + "'", baglanti);
                set = new DataSet();
                baglanti.Open();
                adapt.Fill(set, "Satis_Tablosu");
                dataGridView1.DataSource = set.Tables["Satis_Tablosu"];
                baglanti.Close();
            }
            else
            {
                MessageBox.Show("Lütfen bir filtreleme seçiniz.");
            }






        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form form = new Personeller();
            form.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form filmyonet = new Form2();
            filmyonet.Show();
            this.Hide();
        }

        private void Yonetici_Paneli_Load(object sender, EventArgs e)
        {
            gridDoldur();
        }

        void gridDoldur()
        {
            adapt = new SqlDataAdapter("select * from Satis_Tablosu", baglanti);
            set = new DataSet();
            baglanti.Open();
            adapt.Fill(set, "Satis_Tablosu");
            dataGridView1.DataSource = set.Tables["Satis_Tablosu"];
            baglanti.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form cikis = new Ana_Ekran();
            cikis.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Yonetici_Paneli_Load_1(object sender, EventArgs e)
        {
            gridDoldur();
         
                
                if (checkBox1.Checked)
            {
                textBox2.Visible = false;
                textBox1.Visible = true;
            }
            else if (checkBox2.Checked)
            {
                textBox2.Visible = true;
                textBox1.Visible = false;
            }


        }

        private void button6_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            cmd = new SqlCommand("update Koltuk_Tablosu set doluluk_orani=0 where koltuk_id between 76 and 114", baglanti);
            cmd.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Salon 1 boşaltılmıştır.");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            cmd = new SqlCommand("update Koltuk_Tablosu set doluluk_orani=0 where koltuk_id between 115 and 153", baglanti);
            cmd.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Salon 2 boşaltılmıştır.");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            cmd = new SqlCommand("update Koltuk_Tablosu set doluluk_orani=0 where koltuk_id between 154 and 192", baglanti);
            cmd.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Salon 3 boşaltılmıştır.");
        }




        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox1.Visible = true;
            }
            else if (!checkBox1.Checked)
            {
                textBox1.Visible = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                textBox2.Visible = true;
            }
            else if (!checkBox2.Checked)
            {
                textBox2.Visible = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            cmd = new SqlCommand("delete from Satis_Tablosu where satis_id=@satis_id", baglanti);
            cmd.Parameters.AddWithValue("@satis_id", textBox3.Text);
            cmd.ExecuteNonQuery();
            baglanti.Close();
            gridDoldur();
            MessageBox.Show("Kayıt silindi.");
           
        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox3.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
