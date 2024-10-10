namespace Market_Uygulaması
{
    partial class Form7
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.combokato = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txturun = new System.Windows.Forms.TextBox();
            this.txtkodno = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.nudfiyat = new System.Windows.Forms.NumericUpDown();
            this.nudstok = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudfiyat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudstok)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(232, 15);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(565, 527);
            this.dataGridView1.TabIndex = 0;
            // 
            // combokato
            // 
            this.combokato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combokato.FormattingEnabled = true;
            this.combokato.Items.AddRange(new object[] {
            "Cipsler",
            "Çikolatalar",
            "Bisküvi ve Gofretler",
            "Sekerlemeler",
            "Dondurulmus Atistirmaliklar",
            "Kahveler",
            "Çaylar",
            "Gazli İçecekler",
            "Meyve Sulari",
            "Protein ve Enerji Barlari"});
            this.combokato.Location = new System.Drawing.Point(124, 107);
            this.combokato.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.combokato.Name = "combokato";
            this.combokato.Size = new System.Drawing.Size(100, 24);
            this.combokato.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(80, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 16);
            this.label5.TabIndex = 25;
            this.label5.Text = "Stok:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(79, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 16);
            this.label4.TabIndex = 24;
            this.label4.Text = "Fiyat:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(57, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 16);
            this.label3.TabIndex = 23;
            this.label3.Text = "Katogori:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(53, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 16);
            this.label2.TabIndex = 22;
            this.label2.Text = "Ürün İsmi:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(3, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 16);
            this.label1.TabIndex = 21;
            this.label1.Text = "Barkod Numarası:";
            // 
            // txturun
            // 
            this.txturun.Location = new System.Drawing.Point(124, 79);
            this.txturun.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txturun.Name = "txturun";
            this.txturun.Size = new System.Drawing.Size(100, 22);
            this.txturun.TabIndex = 18;
            // 
            // txtkodno
            // 
            this.txtkodno.Location = new System.Drawing.Point(124, 49);
            this.txtkodno.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtkodno.Name = "txtkodno";
            this.txtkodno.Size = new System.Drawing.Size(100, 22);
            this.txtkodno.TabIndex = 17;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(7, 214);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(219, 54);
            this.button1.TabIndex = 27;
            this.button1.Text = "Ürün Ekle";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(16, 15);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(91, 28);
            this.button2.TabIndex = 28;
            this.button2.Text = "<<<Geri";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // nudfiyat
            // 
            this.nudfiyat.Location = new System.Drawing.Point(124, 140);
            this.nudfiyat.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudfiyat.Name = "nudfiyat";
            this.nudfiyat.Size = new System.Drawing.Size(102, 22);
            this.nudfiyat.TabIndex = 29;
            this.nudfiyat.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudstok
            // 
            this.nudstok.Location = new System.Drawing.Point(124, 168);
            this.nudstok.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudstok.Name = "nudstok";
            this.nudstok.Size = new System.Drawing.Size(102, 22);
            this.nudstok.TabIndex = 30;
            this.nudstok.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Form7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(813, 554);
            this.Controls.Add(this.nudstok);
            this.Controls.Add(this.nudfiyat);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.combokato);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txturun);
            this.Controls.Add(this.txtkodno);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form7";
            this.Text = "Ürün Ekleme";
            this.Load += new System.EventHandler(this.Form7_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudfiyat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudstok)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox combokato;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txturun;
        private System.Windows.Forms.TextBox txtkodno;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NumericUpDown nudfiyat;
        private System.Windows.Forms.NumericUpDown nudstok;
    }
}