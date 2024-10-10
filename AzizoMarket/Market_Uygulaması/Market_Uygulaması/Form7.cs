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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
            
        }
        SqlConnection baglanti = new SqlConnection("Data Source=YAZILIMSTAJYER\\SQLEXPRESS;Initial Catalog=dbsql;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand kayıtekle = new SqlCommand("INSERT INTO UrunSatıs (BarkodNo, UrunIsmi, Katogori, Fiyat, Stok) VALUES (@p1, @p2, @p3, @p4, @p5)", baglanti);
            kayıtekle.Parameters.AddWithValue("@p1", txtkodno.Text);
            kayıtekle.Parameters.AddWithValue("@p2", txturun.Text);
            kayıtekle.Parameters.AddWithValue("@p3", combokato.Text);
            kayıtekle.Parameters.AddWithValue("@p4", nudfiyat.Text);
            kayıtekle.Parameters.AddWithValue("@p5", nudstok.Text);
            kayıtekle.ExecuteNonQuery();
            baglanti.Close();
            loldata();
            txtkodno.Clear();
            txturun.Clear();
        }
        private void loldata()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM UrunSatıs", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            loldata();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }
    }
}
