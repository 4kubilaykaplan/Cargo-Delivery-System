
namespace CargoDelivery
{
    partial class TeslimatDurumEkranı
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.CargoId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DeliveryInformation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.teslimdurumudegistir = new System.Windows.Forms.Button();
            this.sil = new System.Windows.Forms.Button();
            this.guncelle = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CargoId,
            this.DeliveryInformation});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(351, 435);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            this.listView1.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView1_ItemSelectionChanged);
            // 
            // CargoId
            // 
            this.CargoId.Text = "Kargo Id";
            this.CargoId.Width = 175;
            // 
            // DeliveryInformation
            // 
            this.DeliveryInformation.Text = "Teslim Durumu";
            this.DeliveryInformation.Width = 175;
            // 
            // teslimdurumudegistir
            // 
            this.teslimdurumudegistir.Location = new System.Drawing.Point(369, 12);
            this.teslimdurumudegistir.Name = "teslimdurumudegistir";
            this.teslimdurumudegistir.Size = new System.Drawing.Size(138, 45);
            this.teslimdurumudegistir.TabIndex = 1;
            this.teslimdurumudegistir.Text = "Teslim Durumu Değiştir";
            this.teslimdurumudegistir.UseVisualStyleBackColor = true;
            this.teslimdurumudegistir.Click += new System.EventHandler(this.teslimdurumudegistir_Click);
            // 
            // sil
            // 
            this.sil.Location = new System.Drawing.Point(369, 63);
            this.sil.Name = "sil";
            this.sil.Size = new System.Drawing.Size(138, 45);
            this.sil.TabIndex = 2;
            this.sil.Text = "Sil";
            this.sil.UseVisualStyleBackColor = true;
            this.sil.Click += new System.EventHandler(this.sil_Click);
            // 
            // guncelle
            // 
            this.guncelle.Location = new System.Drawing.Point(369, 114);
            this.guncelle.Name = "guncelle";
            this.guncelle.Size = new System.Drawing.Size(138, 45);
            this.guncelle.TabIndex = 3;
            this.guncelle.Text = "Güncelle";
            this.guncelle.UseVisualStyleBackColor = true;
            this.guncelle.Click += new System.EventHandler(this.guncelle_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(369, 165);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(138, 45);
            this.button3.TabIndex = 4;
            this.button3.Text = "Ekle";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(369, 392);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 55);
            this.button1.TabIndex = 5;
            this.button1.Text = "Kullanıcı Konumu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // TeslimatDurumEkranı
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 457);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.guncelle);
            this.Controls.Add(this.sil);
            this.Controls.Add(this.teslimdurumudegistir);
            this.Controls.Add(this.listView1);
            this.Name = "TeslimatDurumEkranı";
            this.Text = "Teslimat Durum Ekranı";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button teslimdurumudegistir;
        private System.Windows.Forms.ColumnHeader CargoId;
        private System.Windows.Forms.ColumnHeader DeliveryInformation;
        private System.Windows.Forms.Button sil;
        private System.Windows.Forms.Button guncelle;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
    }
}