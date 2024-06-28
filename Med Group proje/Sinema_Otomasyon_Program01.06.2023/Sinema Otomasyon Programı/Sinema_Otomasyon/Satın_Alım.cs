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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Sinema_Otomasyon
{
    public partial class Satın_Alım : Form
    {
        public static string salon_no;


        public Satın_Alım()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form filmlerekrani = new Filmler();
            filmlerekrani.Show();
            this.Hide();

        }
        void gridDoldur_salon1()
        {
            baglanti = new SqlConnection(@"Data Source=EMRE;Initial Catalog=sqlsinemasonhali;Integrated Security=True");
            adapt = new SqlDataAdapter("select * from Koltuk_Tablosu where doluluk_orani='0' and koltuk_id between 76 and 114", baglanti);
            set = new DataSet();
            baglanti.Open();
            adapt.Fill(set, "Koltuk_Tablosu");
            dataGridView1.DataSource = set.Tables["Koltuk_Tablosu"];
            this.dataGridView1.Columns["doluluk_orani"].Visible = false;
            this.dataGridView1.Columns["koltuk_id"].Visible = false;
            baglanti.Close();
        }
        void gridDoldur_salon2()
        {
            baglanti = new SqlConnection(@"Data Source=EMRE;Initial Catalog=sqlsinemasonhali;Integrated Security=True");
            adapt = new SqlDataAdapter("select * from Koltuk_Tablosu where doluluk_orani='0' and koltuk_id between 115 and 153", baglanti);
            set = new DataSet();
            baglanti.Open();
            adapt.Fill(set, "Koltuk_Tablosu");
            dataGridView1.DataSource = set.Tables["Koltuk_Tablosu"];
            this.dataGridView1.Columns["doluluk_orani"].Visible = false;
            this.dataGridView1.Columns["koltuk_id"].Visible = false;
            baglanti.Close();
        }


        void gridDoldur_salon3()
        {
            baglanti = new SqlConnection(@"Data Source=EMRE;Initial Catalog=sqlsinemasonhali;Integrated Security=True");
            adapt = new SqlDataAdapter("select * from Koltuk_Tablosu where doluluk_orani='0' and koltuk_id between 154 and 192", baglanti);
            set = new DataSet();
            baglanti.Open();
            adapt.Fill(set, "Koltuk_Tablosu");
            dataGridView1.DataSource = set.Tables["Koltuk_Tablosu"];
            this.dataGridView1.Columns["doluluk_orani"].Visible = false;
            this.dataGridView1.Columns["koltuk_id"].Visible = false;
            baglanti.Close();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=EMRE;Initial Catalog=sqlsinemasonhali;Integrated Security=True");
        SqlDataAdapter adapt = new SqlDataAdapter();
        DataSet set = new DataSet();
        SqlCommand cmd;
        SqlDataReader dr;

        private void Satın_Alım_Load(object sender, EventArgs e)
        {
            textBox1.Text = salon_no;
            if (salon_no == "1")
            {
                gridDoldur_salon1();
            }
            else if (salon_no == "2")
            {
                gridDoldur_salon2();
            }
            else
            {
                gridDoldur_salon3();
            }


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        int fiyat;
        string biletturu;
        public static string musteritc;
        public static string filmadi;
        string time;
        string koltukid;

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {
            label3.Text = "100";
            fiyat = 100;
            biletturu = "vip";
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            label3.Text = "70";
            fiyat = 70;
            biletturu = "tam";
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            label3.Text = "50";
            fiyat = 50;
            biletturu = "ogrenci";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            koltukid = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Close();
                baglanti.Open();
                cmd = new SqlCommand("insert into Satis_Tablosu(musteri_tc, film_adi, koltuk_id, bilet_tur, seans, fiyat, salon_no) values(@p1,@p2,@p3,@p4,@p5,@p6,@p7)", baglanti);
                cmd.Parameters.AddWithValue("@p1", musteritc);
                cmd.Parameters.AddWithValue("@p2", filmadi);
                cmd.Parameters.AddWithValue("@p3", koltukid);
                cmd.Parameters.AddWithValue("@p4", biletturu);
                cmd.Parameters.AddWithValue("@p5", time);
                cmd.Parameters.AddWithValue("@p6", fiyat);
                cmd.Parameters.AddWithValue("@p7", salon_no);
                cmd.ExecuteNonQuery();
                baglanti.Close();

                baglanti.Open();
                cmd = new SqlCommand("update Koltuk_Tablosu set doluluk_orani=1 where koltuk_id=@p8", baglanti);
                cmd.Parameters.AddWithValue("@p8", Convert.ToInt32(koltukid));
                cmd.ExecuteNonQuery();
                if (textBox1.Text == "1")
                {
                    gridDoldur_salon1();
                }
                else if (textBox1.Text == "2")
                {
                    gridDoldur_salon2();
                }
                else if (textBox1.Text == "3")
                {
                    gridDoldur_salon3();
                }
                baglanti.Close();

                MessageBox.Show("Satın alma işlemi başarıyla tamamlandı!");
                textBox1.Clear();
                textBox2.Clear();
            }
            catch (System.Data.SqlClient.SqlException)
            {
                MessageBox.Show("Bilet türünü seçmediniz.");

            }
            finally {
                baglanti.Close();

            }



        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            time = "12:00";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            time = "14:00";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            time = "16:00";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            time = "18:00";
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            time = "20:00";
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            time = "22:00";
        }

        private void A1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
