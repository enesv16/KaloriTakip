using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VeeritabaniProje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        NpgsqlConnection con = new NpgsqlConnection("server= localHost;port=5432; Database= KaloriTakip; user ID= postgres; password=126316");

        

       

        private void tabPage1_Click(object sender, EventArgs e)
        {
            string sorgu = "select * from egzersiz";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

    

        private void Form1_Load(object sender, EventArgs e)
        {
            string sorgu3 = "SELECT * FROM \"kullanicilar\" INNER JOIN \"profil\"  ON \"kullanicilar\".\"kullanici_adi\" = \"profil\".\"kullanici_adi\"";
            NpgsqlDataAdapter da3 = new NpgsqlDataAdapter(sorgu3, con);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            dataGridView6.DataSource = ds3.Tables[0];

            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            string sorgu = "select * from kahvalti";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView3.DataSource = ds.Tables[0];

            string sorgu4 = "select * from ogle_yemegi";
            NpgsqlDataAdapter da4 = new NpgsqlDataAdapter(sorgu4, con);
            DataSet ds4 = new DataSet();
            da4.Fill(ds4);
            dataGridView4.DataSource = ds4.Tables[0];

            string sorgu5 = "select * from aksam_yemegi";
            NpgsqlDataAdapter da5 = new NpgsqlDataAdapter(sorgu5, con);
            DataSet ds5 = new DataSet();
            da5.Fill(ds5);
            dataGridView5.DataSource = ds5.Tables[0];

            string sorgu2 = "select * from diyetler";
            NpgsqlDataAdapter da2 = new NpgsqlDataAdapter(sorgu2, con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            dataGridView2.DataSource = ds2.Tables[0];

            string sorgu3 = "select * from egzersiz";
            NpgsqlDataAdapter da3 = new NpgsqlDataAdapter(sorgu3, con);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            dataGridView1.DataSource = ds3.Tables[0];

            string sorgu6 = "select * from besinler";
            NpgsqlDataAdapter da6 = new NpgsqlDataAdapter(sorgu6, con);
            DataSet ds6 = new DataSet();
            da6.Fill(ds6);
            dataGridView7.DataSource = ds6.Tables[0];

            string sorgu7 = "select * from tarifler";
            NpgsqlDataAdapter da7 = new NpgsqlDataAdapter(sorgu7, con);
            DataSet ds7 = new DataSet();
            da7.Fill(ds7);
            dataGridView9.DataSource = ds7.Tables[0];

            string sorgu8 = "select * from su_takibi";
            NpgsqlDataAdapter da8 = new NpgsqlDataAdapter(sorgu8, con);
            DataSet ds8 = new DataSet();
            da8.Fill(ds8);
            dataGridView11.DataSource = ds8.Tables[0];
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            con.Open();
            NpgsqlCommand komut = new NpgsqlCommand("insert into diyetler(diyet_adi, diyet_turu, k_besin_adi, oy_besin_adi, ay_besin_adi) values (@p1, @p2,@p3,@p4,@p5)", con);
            komut.Parameters.AddWithValue("@p1", textBox6.Text);
            komut.Parameters.AddWithValue("@p2", comboBox4.Text);
            komut.Parameters.AddWithValue("@p3", comboBox1.Text);
            komut.Parameters.AddWithValue("@p4", comboBox2.Text);
            komut.Parameters.AddWithValue("@p5", comboBox3.Text);
            komut.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Başarıyla eklendi..");
            string sorgu2 = "select * from diyetler";
            NpgsqlDataAdapter da2 = new NpgsqlDataAdapter(sorgu2, con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            dataGridView2.DataSource = ds2.Tables[0];
        }

        private void button7_Click(object sender, EventArgs e)
        {
            con.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand("Delete From diyetler where diyet_adi =@p1", con);
            komut2.Parameters.AddWithValue("@p1", comboBox5.Text);
            komut2.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Diyet silindi..");
            string sorgu2 = "select * from diyetler";
            NpgsqlDataAdapter da2 = new NpgsqlDataAdapter(sorgu2, con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            dataGridView2.DataSource = ds2.Tables[0];
        }

        private void button8_Click(object sender, EventArgs e)
        {
            con.Open();
            NpgsqlCommand komut = new NpgsqlCommand("Update diyetler set diyet_turu = @p1, k_besin_adi = @p3, oy_besin_adi = @p4, ay_besin_adi = @p5 where diyet_adi = @p2", con);

            if (textBox6.Text != "")
            {
                komut.Parameters.AddWithValue("@p2", textBox6.Text);
            }
            komut.Parameters.AddWithValue("@p1", comboBox4.Text);
            komut.Parameters.AddWithValue("@p3", comboBox1.Text);
            komut.Parameters.AddWithValue("@p4", comboBox2.Text);
            komut.Parameters.AddWithValue("@p5", comboBox3.Text);
            komut.ExecuteNonQuery();
            con.Close();
            

            string sorgu2 = "select * from diyetler";
            NpgsqlDataAdapter da2 = new NpgsqlDataAdapter(sorgu2, con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            dataGridView2.DataSource = ds2.Tables[0];
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            string sorgu3 = "Select * From egzersiz where egzersiz_tipi='" + textBox7.Text + "'";
            NpgsqlDataAdapter da3 = new NpgsqlDataAdapter(sorgu3, con);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            dataGridView1.DataSource = ds3.Tables[0];
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            con.Open();
            NpgsqlCommand komut = new NpgsqlCommand("insert into egzersiz(yakilan_kalori, egzersiz_tipi, egzersiz_zorlugu,egzersiz_icerigi) values (@p1, @p2,@p3,@p4)", con);
            komut.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
            komut.Parameters.AddWithValue("@p2", textBox2.Text);
            komut.Parameters.AddWithValue("@p3", comboBox6.Text);
            komut.Parameters.AddWithValue("@p4", textBox4.Text);
            komut.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Başarıyla eklendi..");

            string sorgu = "select * from egzersiz";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
        private void button9_Click(object sender, EventArgs e)
        {
            con.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand("Delete From egzersiz where egzersiz_tipi =@p1", con);
            komut2.Parameters.AddWithValue("@p1", textBox5.Text);
            komut2.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Egzersiz silindi..");
            string sorgu = "select * from egzersiz";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            textBox5.Clear();
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            NpgsqlCommand komut = new NpgsqlCommand("Update egzersiz set yakilan_kalori = @p1, egzersiz_zorlugu = @p3, egzersiz_icerigi = @p4 where egzersiz_tipi = @p2", con);


            komut.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
            komut.Parameters.AddWithValue("@p2", textBox2.Text);
            komut.Parameters.AddWithValue("@p3", comboBox6.Text);
            komut.Parameters.AddWithValue("@p4", textBox4.Text);
            komut.ExecuteNonQuery();
            con.Close();
            textBox1.Clear();
            textBox4.Clear();
            textBox6.Clear();

            string sorgu = "select * from egzersiz";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            NpgsqlCommand komut = new NpgsqlCommand("insert into kullanicilar(kullanici_adi, eposta, sehir, yas, boy, kilo, adi_soyadi) values (@p1, @p2,@p3,@p4,@p5,@p6,@p7)", con);
            komut.Parameters.AddWithValue("@p1", textBox8.Text);
            komut.Parameters.AddWithValue("@p2", textBox9.Text);
            komut.Parameters.AddWithValue("@p3", comboBox7.Text);
            komut.Parameters.AddWithValue("@p4", int.Parse(textBox3.Text));
            komut.Parameters.AddWithValue("@p5", int.Parse(textBox11.Text));
            komut.Parameters.AddWithValue("@p6", int.Parse(textBox12.Text));
            komut.Parameters.AddWithValue("@p7", textBox10.Text);
            komut.ExecuteNonQuery();
            con.Close();

            con.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand("insert into profil(kullanici_adi, hedef_kilo, hedef_adim, kullanim_hedefi, beslenme_tipi) values (@p1, @p2,@p3,@p4,@p5)", con);
            komut2.Parameters.AddWithValue("@p1", textBox8.Text);
            komut2.Parameters.AddWithValue("@p2", int.Parse(textBox13.Text));
            komut2.Parameters.AddWithValue("@p3", int.Parse(textBox14.Text));
            komut2.Parameters.AddWithValue("@p4", comboBox8.Text);
            komut2.Parameters.AddWithValue("@p5", comboBox9.Text);
            komut2.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Başarıyla eklendi..");

            string sorgu3 = "SELECT * FROM \"kullanicilar\" INNER JOIN \"profil\"  ON \"kullanicilar\".\"kullanici_adi\" = \"profil\".\"kullanici_adi\"";
            NpgsqlDataAdapter da3 = new NpgsqlDataAdapter(sorgu3, con);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            dataGridView6.DataSource = ds3.Tables[0];

        }

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            NpgsqlCommand komut3 = new NpgsqlCommand("Delete From profil where kullanici_adi =@p1", con);
            komut3.Parameters.AddWithValue("@p1", textBox15.Text);
            komut3.ExecuteNonQuery();
            con.Close();

            con.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand("Delete From kullanicilar where kullanici_adi =@p1", con);
            komut2.Parameters.AddWithValue("@p1", textBox15.Text);
            komut2.ExecuteNonQuery();
            con.Close();

           

            MessageBox.Show("Kullanici silindi..");
            string sorgu3 = "SELECT * FROM \"kullanicilar\" INNER JOIN \"profil\"  ON \"kullanicilar\".\"kullanici_adi\" = \"profil\".\"kullanici_adi\"";
            NpgsqlDataAdapter da3 = new NpgsqlDataAdapter(sorgu3, con);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            dataGridView6.DataSource = ds3.Tables[0];
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string sorgu4 = "Select * From kullanicilar where kullanici_adi='" + comboBox10.Text + "'";
            NpgsqlDataAdapter da4 = new NpgsqlDataAdapter(sorgu4, con);
            DataSet ds4 = new DataSet();
            da4.Fill(ds4);
            dataGridView6.DataSource = ds4.Tables[0];
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string sorgu4 = "Select * From diyetler where diyet_adi='" + comboBox11.Text + "'";
            NpgsqlDataAdapter da4 = new NpgsqlDataAdapter(sorgu4, con);
            DataSet ds4 = new DataSet();
            da4.Fill(ds4);
            dataGridView2.DataSource = ds4.Tables[0];
        }

        private void dataGridView8_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label42_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            string sorgu4 = "Select * From besinler where besin_adi='" + comboBox12.Text + "'";
            NpgsqlDataAdapter da4 = new NpgsqlDataAdapter(sorgu4, con);
            DataSet ds4 = new DataSet();
            da4.Fill(ds4);
            dataGridView8.DataSource = ds4.Tables[0];
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void label45_Click(object sender, EventArgs e)
        {

        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {

        }

        private void label50_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            con.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand("insert into tarifler(tarif_adi, kalori, yapilis_talimati, porsiyon, malzemeler) values (@p1, @p2,@p3,@p4,@p5)", con);
            komut2.Parameters.AddWithValue("@p1", textBox17.Text);
            komut2.Parameters.AddWithValue("@p2", int.Parse(textBox18.Text));
            komut2.Parameters.AddWithValue("@p3", textBox19.Text);
            komut2.Parameters.AddWithValue("@p4", int.Parse(textBox20.Text));
            komut2.Parameters.AddWithValue("@p5", textBox16.Text);
            komut2.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Tarif eklendi.");

            string sorgu3 = "select * from tarifler";
            NpgsqlDataAdapter da3 = new NpgsqlDataAdapter(sorgu3, con);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            dataGridView9.DataSource = ds3.Tables[0];
        }

        private void button13_Click(object sender, EventArgs e)
        {
            string sorgu4 = "Select * From tarifler where tarif_adi='" + comboBox13.Text + "'";
            NpgsqlDataAdapter da4 = new NpgsqlDataAdapter(sorgu4, con);
            DataSet ds4 = new DataSet();
            da4.Fill(ds4);
            dataGridView10.DataSource = ds4.Tables[0];
        }

        private void button14_Click(object sender, EventArgs e)
        {
            con.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand("Delete From tarifler where tarif_adi =@p1", con);
            komut2.Parameters.AddWithValue("@p1", textBox21.Text);
            komut2.ExecuteNonQuery();
            con.Close();

            string sorgu3 = "select * from tarifler";
            NpgsqlDataAdapter da3 = new NpgsqlDataAdapter(sorgu3, con);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            dataGridView9.DataSource = ds3.Tables[0];
        }

        private void label57_Click(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            con.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand("insert into su_takibi(alinan_su_miktari, hedef_miktar, kullanici_adi, tarih) values (@p1, @p2,@p3,@p4)", con);
            komut2.Parameters.AddWithValue("@p1", comboBox16.Text);
            komut2.Parameters.AddWithValue("@p2", comboBox15.Text);
            komut2.Parameters.AddWithValue("@p3", comboBox14.Text);
            komut2.Parameters.AddWithValue("@p4", dateTimePicker1.Value);
            komut2.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Güncelleme eklendi.");

            string sorgu8 = "select * from su_takibi";
            NpgsqlDataAdapter da8 = new NpgsqlDataAdapter(sorgu8, con);
            DataSet ds8 = new DataSet();
            da8.Fill(ds8);
            dataGridView11.DataSource = ds8.Tables[0];
        }

        private void textBox24_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
        private void label59_Click(object sender, EventArgs e)
        {

        }

        private void label64_Click(object sender, EventArgs e)
        {

        }

        private void label65_Click(object sender, EventArgs e)
        {

        }

        private void label66_Click(object sender, EventArgs e)
        {

        }

        private void label67_Click(object sender, EventArgs e)
        {

        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox23_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox24_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {
            con.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand("insert into besinler(besin_adi, kalori, miktar) values (@p1, @p2,@p3)", con);
            komut2.Parameters.AddWithValue("@p1", textBox22.Text);
            komut2.Parameters.AddWithValue("@p2", int.Parse(textBox24.Text));
            komut2.Parameters.AddWithValue("@p3", textBox23.Text);
            komut2.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Besin eklendi.");

            string sorgu6 = "select * from besinler";
            NpgsqlDataAdapter da6 = new NpgsqlDataAdapter(sorgu6, con);
            DataSet ds6 = new DataSet();
            da6.Fill(ds6);
            dataGridView7.DataSource = ds6.Tables[0];
        }

        private void button18_Click(object sender, EventArgs e)
        {
            con.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand("Delete From besinler where besin_adi =@p1", con);
            komut2.Parameters.AddWithValue("@p1", comboBox17.Text);
            komut2.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Besin silindi.");

            string sorgu6 = "select * from besinler";
            NpgsqlDataAdapter da6 = new NpgsqlDataAdapter(sorgu6, con);
            DataSet ds6 = new DataSet();
            da6.Fill(ds6);
            dataGridView7.DataSource = ds6.Tables[0];
        }
    }
}
