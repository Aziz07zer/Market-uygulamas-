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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=YAZILIMSTAJYER\\SQLEXPRESS;Initial Catalog=dbsql;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
        private void btngir_Click(object sender, EventArgs e)
        {
            // TextBox'lardan alınan değerler
            string AD = txtad.Text;
            string Sifre = txtsifre.Text;

            // Veritabanında kontrol et
            if (ValidateProduct(AD, Sifre))
            {
                // Eğer ürün doğrulandıysa Form2'ye geç
                Form2 form2 = new Form2();
                form2.Show();
                this.Hide(); // Mevcut formu gizle
            }
            else
            {
                MessageBox.Show("Yanlış veya Hatalı Girdiniz!");
            }
        }
        //-------------------------------------------------------------------------------------------
        private bool ValidateProduct(string AD, string Sifre)
        {
            try
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("SELECT COUNT(*) FROM Yonetici WHERE CalısanAd=@AD AND sifre=@Sifre", baglanti);
                komut.Parameters.AddWithValue("@AD", AD);
                komut.Parameters.AddWithValue("@Sifre", Sifre);

                int productCount = (int)komut.ExecuteScalar();
                return productCount > 0; // Ürün bulunursa true döner
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
                return false;
            }
            finally
            {
                baglanti.Close();
            }
        }
        //-------------------------------------------------------------------------------------------
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            label3.Text = label3.Text.Substring(1) + label3.Text.Substring(0, 1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ADI = txtad.Text;
            string Sifre2 = txtsifre.Text;

            // Veritabanında kontrol et
            if (ValidateProduct1(ADI, Sifre2))
            {
                Form3 form3 = new Form3();
                form3.Show();
                this.Hide(); // Mevcut formu gizle
            }
            else
            {
                MessageBox.Show("Yanlış veya Hatalı Girdiniz!");
            }
        }
        private bool ValidateProduct1(string AD, string Sifre)
        {
            try
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("SELECT COUNT(*) FROM Yonetici_Tam_Yetki WHERE YoneticiAdı=@ADI AND sifre=@Sifre2", baglanti);
                komut.Parameters.AddWithValue("@ADI", AD);
                komut.Parameters.AddWithValue("@Sifre2", Sifre);

                int productCount = (int)komut.ExecuteScalar();
                return productCount > 0; // değer bulunursa true döner
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
                return false;
            }
            finally
            {
                baglanti.Close();
            }
        }
    }
}