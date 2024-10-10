using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Market_Uygulaması
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            loldata();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=YAZILIMSTAJYER\\SQLEXPRESS;Initial Catalog=dbsql;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
        private void button1_Click(object sender, EventArgs e)
        {
          Form7 from7 = new Form7();
          from7.Show();
          this.Hide();
        }
        private void loldata()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM UrunSatıs", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from UrunSatıs where Katogori='" + comboBox1.Text + "'", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = e.RowIndex;
            txtkodno.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txturun.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            combokato.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            txtfiyat.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txtstok.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            this.Hide(); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutsil = new SqlCommand("DELETE FROM UrunSatıs WHERE BarkodNo=@sicil", baglanti);
            komutsil.Parameters.AddWithValue("@sicil", txtkodno.Text);
            komutsil.ExecuteNonQuery();
            baglanti.Close();
            loldata();
            txtfiyat.Clear();
            txtstok.Clear();
            txtkodno.Clear();
            txturun.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtkodno.Text))
            {
                MessageBox.Show("Stok Güncellemek için ÜRÜNÜ seçin.");
                return;
            }

            try
            {
                baglanti.Open();
                SqlCommand komutGuncelle = new SqlCommand("UPDATE UrunSatıs SET UrunIsmi=@p2, Katogori=@p3, Fiyat=@p4, Stok=@p5 WHERE BarkodNo=@p1", baglanti);
                komutGuncelle.Parameters.AddWithValue("@p1", txtkodno.Text);
                komutGuncelle.Parameters.AddWithValue("@p2", txturun.Text);
                komutGuncelle.Parameters.AddWithValue("@p3", combokato.Text);
                komutGuncelle.Parameters.AddWithValue("@p4", txtfiyat.Text);
                komutGuncelle.Parameters.AddWithValue("@p5", txtstok.Text);
                komutGuncelle.ExecuteNonQuery();
                MessageBox.Show("Stok başarıyla Eklendi.");
                loldata();

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

        private void button6_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
            this.Hide();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
