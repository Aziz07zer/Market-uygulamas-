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
    public partial class Form2 : Form
    {
        private List<string> urunler = new List<string>();
        private decimal toplamFiyat = 0;
        //------------------------------------------------
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=YAZILIMSTAJYER\\SQLEXPRESS;Initial Catalog=dbsql;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
        private void button2_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM UrunSatıs", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
        

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int secilen = e.RowIndex;
                txtbarkod.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
                txtUrun.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
                txtKata.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
                txtFiyat.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
                txtStok.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            }
            catch { }
            }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from UrunSatıs where Katogori='" + comboBox1.Text + "'", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void loldata()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM UrunSatıs", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }




        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
               
                int sayi1 = int.Parse(txtFiyat.Text);  // txtSayi1, ilk sayı için TextBox
                int sayi2 = int.Parse(numericUpDown1.Text); 
                int sayi3 =int.Parse(txtStok.Text);
                int sayi4 = int.Parse(numericUpDown1.Text);
                int carpim = sayi1 * sayi2;
                int stok = sayi3 - sayi4;
                // Sonucu Label'a yaz
                if (stok < 0)
                {
                    MessageBox.Show("Yeterli stok yok. İşlem iptal edildi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;  // Eğer stok yetersizse işlemi durdur
                }
                lblsonuc.Text = carpim.ToString();  // lblSonuc, sonucu göstermek için Label
                lblstok.Text = stok.ToString();

                baglanti.Open();
                SqlCommand kayıtekle = new SqlCommand("INSERT INTO UrunTakibi (BarkodNo, UrunIsmi, Katogori, Fiyat, Adet, Tarih) VALUES (@p1, @p2, @p3, @p4, @p5, @p6)", baglanti);
                kayıtekle.Parameters.AddWithValue("@p1", txtbarkod.Text);
                kayıtekle.Parameters.AddWithValue("@p2", txtUrun.Text);
                kayıtekle.Parameters.AddWithValue("@p3", txtKata.Text);
                kayıtekle.Parameters.AddWithValue("@p4", lblsonuc.Text);
                kayıtekle.Parameters.AddWithValue("@p5", numericUpDown1.Value);
                kayıtekle.Parameters.AddWithValue("@p6", dtpTarih.Value);
                kayıtekle.ExecuteNonQuery();




                //---------------------------------------------------------------------------
                
                //---------------------------------------------------------------------------

                SqlCommand komutGuncelle = new SqlCommand("UPDATE UrunSatıs SET UrunIsmi=@p2, Katogori=@p3, Fiyat=@p4, Stok=@p5 WHERE BarkodNo=@p1", baglanti);
                komutGuncelle.Parameters.AddWithValue("@p1", txtbarkod.Text);
                komutGuncelle.Parameters.AddWithValue("@p2", txtUrun.Text);
                komutGuncelle.Parameters.AddWithValue("@p3", txtKata.Text);
                komutGuncelle.Parameters.AddWithValue("@p4", txtFiyat.Text);
                komutGuncelle.Parameters.AddWithValue("@p5", lblstok.Text);
                komutGuncelle.ExecuteNonQuery();
                baglanti.Close();
                //
                //
              MessageBox.Show("Başarılı şekilde eklendi.");
                loldata();
                //
                //
                //
                //
                //
                //
                //
                // Girişlerin doğruluğunu kontrol et
                if (string.IsNullOrWhiteSpace(txtUrun.Text) ||
                    string.IsNullOrWhiteSpace(numericUpDown1.Text) ||
                    string.IsNullOrWhiteSpace(txtFiyat.Text)||
                    string.IsNullOrWhiteSpace(dtpTarih.Text))
                {
                    MessageBox.Show("Lütfen tüm alanları doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Adet ve fiyatın geçerli sayılar olup olmadığını kontrol et
                if (!int.TryParse(numericUpDown1.Text, out int adet) || adet <= 0)
                {
                    MessageBox.Show("Lütfen geçerli bir adet giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(txtFiyat.Text, out decimal fiyat) || fiyat <= 0)
                {
                    MessageBox.Show("Lütfen geçerli bir fiyat giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Ürünün toplam fiyatı
                decimal toplamUrunFiyati = adet * fiyat;

                // Ürünleri listeye ekle
                urunler.Add($"{adet} x {txtUrun.Text} - ₺{toplamUrunFiyati:0.00}");//tl logosunu getirme

                // Toplam fiyatı güncelle
                toplamFiyat += toplamUrunFiyati;

                // ListBox'a eklenen ürünleri göster
                listBox1.Items.Add($"{adet} x {txtUrun.Text} - ₺{toplamUrunFiyati:0.00}");
                //////////////////////////////////////////////////////////////////////////
                
                /////////////////////////////////////////////////////////////////////////
            }
            catch
            {
                MessageBox.Show("lütfen listeden seçtiğinizden emin olun.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide(); // Mevcut formu gizle
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            loldata();
        }

        private void btnfis_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBox2.Text))
            {
                MessageBox.Show("Lütfen kasiyer seçimi yapın!!!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (urunler.Count == 0)
            {
                MessageBox.Show("Fişi oluşturmak için önce ürün eklemelisiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string fis = "╔═══════════════════════════════╗\n";
            fis += "     ** AZIZO MARKET **    \n";
            fis += "╚═══════════════════════════════╝\n";
            fis += $"KASİYER: {comboBox2.Text.PadRight(18)}\n";
            fis += $"TARİH:   {dtpTarih.Value.ToString("dd/MM/yyyy HH:mm")}\n";
            fis += "════════════════════════════\n";

            // Ürünlerin listelenmesi
            fis += "ÜRÜNLER:\n";
            

            // Listeye eklenen her ürünü fişe ekleyelim
            foreach (var urun in urunler)
            {
                fis += urun + "\n"; // Ürün formatı önceden hazırlanmış
            }

            fis += "--------------------------------\n";

            // En son toplam fiyatı ekleyelim
            fis += $"TOPLAM TUTAR:".PadRight(22) + $"₺{toplamFiyat:0.00}".PadLeft(10) + "\n";
            fis += "════════════════════════════\n";

            // Kapanış mesajı
            fis += " TEŞEKKÜR EDERİZ  \n";
            fis += " YİNE BEKLERİZ! \n";
            fis += "════════════════════════════";

            // MessageBox ile fişi göster
            MessageBox.Show(fis, "Fiş", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Label'a fişi yazdır
            label8.Text = fis;

            // Listeyi ve toplam fiyatı sıfırla
            urunler.Clear();
            toplamFiyat = 0;
            listBox1.Items.Clear();

            /////////////////////////////////////////////////////////////////////////////////////////
            baglanti.Open();
            SqlCommand kayıtekleSatıs = new SqlCommand("INSERT INTO USatıslar (Kasiyer, Fis, Tarih) VALUES (@p1, @p2, @p3)", baglanti);
            kayıtekleSatıs.Parameters.AddWithValue("@p1", comboBox2.Text);
            kayıtekleSatıs.Parameters.AddWithValue("@p2", label8.Text);
            kayıtekleSatıs.Parameters.AddWithValue("@p3", dtpTarih.Value);
            kayıtekleSatıs.ExecuteNonQuery();
            baglanti.Close();
            ////////////////////////////////////////////////////////////////////////////////////////
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}