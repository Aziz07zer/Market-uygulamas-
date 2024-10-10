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

namespace Market_Uygulaması
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=YAZILIMSTAJYER\\SQLEXPRESS;Initial Catalog=dbsql;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");

        private void Form4_Load(object sender, EventArgs e)
        {
            loldata();
        }
        private void loldata()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM UrunTakibi", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            loldat();
        }
        private void loldat()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM UrunTakibi WHERE UrunIsmi LIKE '%" + textBox1.Text + "%'", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM UrunTakibi WHERE Katogori LIKE '%" + textBox2.Text + "%'", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Öncelikle toplamı tutacak bir değişken oluşturuyoruz
            double toplam = 0;

            // DataGridView'deki satırları döngü ile geziyoruz
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // Seçtiğimiz sütundaki hücreyi alıyoruz (örneğin, 1. sütun için: Cells[0])
                // Eğer hücre boş değilse ve sayı ise topluyoruz
                if (row.Cells[3].Value != null && double.TryParse(row.Cells[3].Value.ToString(), out double deger))
                {
                    toplam += deger;
                }
            }

            // Toplamı bir MessageBox ile gösterebilirsin
            MessageBox.Show("Toplam: " + toplam.ToString());
            label3.Text = ("Toplam Satış: "+toplam.ToString()+" TL");
            label3.ForeColor = Color.Black;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM UrunTakibi WHERE BarkodNo LIKE '%" + textBox3.Text + "%'", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Öncelikle toplamı tutacak bir değişken oluşturuyoruz
            double toplam = 0;

            // DataGridView'deki satırları döngü ile geziyoruz
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // Seçtiğimiz sütundaki hücreyi alıyoruz (örneğin, 1. sütun için: Cells[0])
                // Eğer hücre boş değilse ve sayı ise topluyoruz
                if (row.Cells[4].Value != null && double.TryParse(row.Cells[4].Value.ToString(), out double deger))
                {
                    toplam += deger;
                }
            }

            // Toplamı bir MessageBox ile gösterebilirsin
            MessageBox.Show("Toplam: " + toplam.ToString());
            label3.Text = ("Toplam Satış: " + toplam.ToString() + " Adet");
            label3.ForeColor = Color.White;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM UrunTakibi WHERE Tarih > '"+dateTimePicker1.Value+"'", baglanti);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            baglanti.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }
    }
}
