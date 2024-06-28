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
    public partial class Filmler : Form
    {
        public Filmler()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form gerigit = new Musteri_Paneli();
            gerigit.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Satın_Alım.filmadi = label1.Text;
            Satın_Alım.salon_no = "1";
            Form satinal = new Satın_Alım();
            satinal.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Satın_Alım.filmadi = label20.Text;
            Satın_Alım.salon_no = "2";
            Form satinal = new Satın_Alım();
            satinal.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Satın_Alım.filmadi = label35.Text;
            Satın_Alım.salon_no = "3";
            Form satinal = new Satın_Alım();
            satinal.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Satın_Alım.filmadi = label10.Text;
            Satın_Alım.salon_no = "1";
            Form satinal = new Satın_Alım();
            satinal.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Satın_Alım.filmadi = label25.Text;
            Satın_Alım.salon_no = "2";
            Form satinal = new Satın_Alım();
            satinal.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Satın_Alım.filmadi = label40.Text;
            Satın_Alım.salon_no = "3";
            Form satinal = new Satın_Alım();
            satinal.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Satın_Alım.filmadi = label11.Text;
            Satın_Alım.salon_no = "1";
            Form satinal = new Satın_Alım();
            satinal.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Satın_Alım.filmadi = label30.Text;
            Satın_Alım.salon_no = "2";
            Form satinal = new Satın_Alım();
            satinal.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Satın_Alım.filmadi = label45.Text;
            Satın_Alım.salon_no = "3";
            Form satinal = new Satın_Alım();
            satinal.Show();
            this.Hide();
        }


        private void Filmler_Load(object sender, EventArgs e)
        {
            bagla.Open();
            cmd.Connection = bagla;
            cmd.CommandText = "select * from filmler where film_no=3";
            dr = cmd.ExecuteReader();
            dr.Read();
            groupBox1.Text = dr[1].ToString();
            label1.Text = dr[1].ToString();
            label2.Text = dr[2].ToString();
            label3.Text = dr[3].ToString();
            label4.Text = dr[4].ToString();
            label5.Text = dr[5].ToString();
            pictureBox1.ImageLocation = dr[6].ToString();
            bagla.Close();

            bagla.Open();
            cmd.Connection = bagla;
            cmd.CommandText = "select * from filmler where film_no=4";
            dr = cmd.ExecuteReader();
            dr.Read();
            groupBox2.Text = dr[1].ToString();
            label10.Text = dr[1].ToString();
            label9.Text = dr[2].ToString();
            label8.Text = dr[3].ToString();
            label7.Text = dr[4].ToString();
            label6.Text = dr[5].ToString();
            pictureBox2.ImageLocation = dr[6].ToString();
            bagla.Close();
            bagla.Open();
            cmd.Connection = bagla;
            cmd.CommandText = "select * from filmler where film_no=5";
            dr = cmd.ExecuteReader();
            dr.Read();
            groupBox3.Text = dr[1].ToString();
            label11.Text = dr[1].ToString();
            label12.Text = dr[2].ToString();
            label13.Text = dr[3].ToString();
            label14.Text = dr[4].ToString();
            label15.Text = dr[5].ToString();
            pictureBox3.ImageLocation = dr[6].ToString();
            bagla.Close();
            bagla.Open();
            cmd.Connection = bagla;
            cmd.CommandText = "select * from filmler where film_no=6";
            dr = cmd.ExecuteReader();
            dr.Read();
            groupBox4.Text = dr[1].ToString();
            label20.Text = dr[1].ToString();
            label19.Text = dr[2].ToString();
            label18.Text = dr[3].ToString();
            label17.Text = dr[4].ToString();
            label16.Text = dr[5].ToString();
            pictureBox4.ImageLocation = dr[6].ToString();
            bagla.Close();
            bagla.Open();
            cmd.Connection = bagla;
            cmd.CommandText = "select * from filmler where film_no=7";
            dr = cmd.ExecuteReader();
            dr.Read();
            groupBox5.Text = dr[1].ToString();
            label25.Text = dr[1].ToString();
            label24.Text = dr[2].ToString();
            label23.Text = dr[3].ToString();
            label22.Text = dr[4].ToString();
            label21.Text = dr[5].ToString();
            pictureBox5.ImageLocation = dr[6].ToString();
            bagla.Close();
            bagla.Open();
            cmd.Connection = bagla;
            cmd.CommandText = "select * from filmler where film_no=8";
            dr = cmd.ExecuteReader();
            dr.Read();
            groupBox6.Text = dr[1].ToString();
            label30.Text = dr[1].ToString();
            label29.Text = dr[2].ToString();
            label28.Text = dr[3].ToString();
            label27.Text = dr[4].ToString();
            label26.Text = dr[5].ToString();
            pictureBox6.ImageLocation = dr[6].ToString();
            bagla.Close();
            bagla.Open();
            cmd.Connection = bagla;
            cmd.CommandText = "select * from filmler where film_no=9";
            dr = cmd.ExecuteReader();
            dr.Read();
            groupBox7.Text = dr[1].ToString();
            label35.Text = dr[1].ToString();
            label34.Text = dr[2].ToString();
            label33.Text = dr[3].ToString();
            label32.Text = dr[4].ToString();
            label31.Text = dr[5].ToString();
            pictureBox7.ImageLocation = dr[6].ToString();
            bagla.Close();
            bagla.Open();
            cmd.Connection = bagla;
            cmd.CommandText = "select * from filmler where film_no=10";
            dr = cmd.ExecuteReader();
            dr.Read();
            groupBox8.Text = dr[1].ToString();
            label40.Text = dr[1].ToString();
            label39.Text = dr[2].ToString();
            label38.Text = dr[3].ToString();
            label37.Text = dr[4].ToString();
            label36.Text = dr[5].ToString();
            pictureBox8.ImageLocation = dr[6].ToString();
            bagla.Close();
            bagla.Open();
            cmd.Connection = bagla;
            cmd.CommandText = "select * from filmler where film_no=11";
            dr = cmd.ExecuteReader();
            dr.Read();
            groupBox9.Text = dr[1].ToString();
            label45.Text = dr[1].ToString();
            label44.Text = dr[2].ToString();
            label43.Text = dr[3].ToString();
            label42.Text = dr[4].ToString();
            label41.Text = dr[5].ToString();
            pictureBox9.ImageLocation = dr[6].ToString();
            bagla.Close();





        }
        SqlConnection bagla = new SqlConnection(@"Data Source=EMRE;Initial Catalog=sqlsinemasonhali;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        SqlDataAdapter adapt = new SqlDataAdapter();
        DataSet set = new DataSet();

        private void label46_Click(object sender, EventArgs e)
        {

        }

        private void button2_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }
    }
}
