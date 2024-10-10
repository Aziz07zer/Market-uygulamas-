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

namespace Market_Uygulaması
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=YAZILIMSTAJYER\\SQLEXPRESS;Initial Catalog=dbsql;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");

        private void Form6_Load(object sender, EventArgs e)
        {
            loldata();
        }
        private void loldata()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Yonetici", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand kayıtekle = new SqlCommand("INSERT INTO Yonetici (CalısanAd, sifre) VALUES (@p1, @p2)", baglanti);
            kayıtekle.Parameters.AddWithValue("@p1", textBox1.Text);
            kayıtekle.Parameters.AddWithValue("@p2", textBox2.Text);
            kayıtekle.ExecuteNonQuery();
            baglanti.Close();
            loldata();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutsil = new SqlCommand("DELETE FROM Yonetici WHERE CalısanAd=@sicil", baglanti);
            komutsil.Parameters.AddWithValue("@sicil", textBox1.Text);
            komutsil.ExecuteNonQuery();
            baglanti.Close();
            loldata();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int secilen = e.RowIndex;
                textBox1.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            }

            catch { }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Şifresi Güncellenecek Kasiyeri Seçin.");
                return;
            }

            try
            {
                baglanti.Open();
                SqlCommand komutGuncelle = new SqlCommand("UPDATE Yonetici SET sifre=@p2 WHERE CalısanAd=@p1", baglanti);
                komutGuncelle.Parameters.AddWithValue("@p1", textBox1.Text);
                komutGuncelle.Parameters.AddWithValue("@p2", textBox2.Text);
                komutGuncelle.ExecuteNonQuery();
                MessageBox.Show("Kasiyer Şifresi Başarıyla Güncellendi.");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }
    }
}
