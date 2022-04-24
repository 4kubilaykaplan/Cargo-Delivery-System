
namespace CargoDelivery
{
    partial class GuncellemeEkranı
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
            this.goster = new System.Windows.Forms.Button();
            this.guncelle = new System.Windows.Forms.Button();
            this.textBoxlong = new System.Windows.Forms.TextBox();
            this.textBoxlat = new System.Windows.Forms.TextBox();
            this.customername = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
            this.SuspendLayout();
            // 
            // goster
            // 
            this.goster.Location = new System.Drawing.Point(820, 161);
            this.goster.Name = "goster";
            this.goster.Size = new System.Drawing.Size(103, 20);
            this.goster.TabIndex = 17;
            this.goster.Text = "Haritada göster";
            this.goster.UseVisualStyleBackColor = true;
            this.goster.Click += new System.EventHandler(this.goster_Click_1);
            // 
            // guncelle
            // 
            this.guncelle.Location = new System.Drawing.Point(710, 221);
            this.guncelle.Name = "guncelle";
            this.guncelle.Size = new System.Drawing.Size(138, 35);
            this.guncelle.TabIndex = 16;
            this.guncelle.Text = "Güncelle";
            this.guncelle.UseVisualStyleBackColor = true;
            this.guncelle.Click += new System.EventHandler(this.guncelle_Click);
            // 
            // textBoxlong
            // 
            this.textBoxlong.Location = new System.Drawing.Point(752, 139);
            this.textBoxlong.MaxLength = 16;
            this.textBoxlong.Name = "textBoxlong";
            this.textBoxlong.Size = new System.Drawing.Size(171, 20);
            this.textBoxlong.TabIndex = 15;
            // 
            // textBoxlat
            // 
            this.textBoxlat.Location = new System.Drawing.Point(752, 107);
            this.textBoxlat.MaxLength = 16;
            this.textBoxlat.Name = "textBoxlat";
            this.textBoxlat.Size = new System.Drawing.Size(171, 20);
            this.textBoxlat.TabIndex = 14;
            // 
            // customername
            // 
            this.customername.Location = new System.Drawing.Point(752, 74);
            this.customername.Name = "customername";
            this.customername.Size = new System.Drawing.Size(171, 20);
            this.customername.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(614, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Kargo Konumu (long)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(614, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Kargo Konumu (lat)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(614, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Müşteri Adı";
            // 
            // gMapControl1
            // 
            this.gMapControl1.Bearing = 0F;
            this.gMapControl1.CanDragMap = true;
            this.gMapControl1.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl1.GrayScaleMode = false;
            this.gMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl1.LevelsKeepInMemory = 5;
            this.gMapControl1.Location = new System.Drawing.Point(22, 12);
            this.gMapControl1.MarkersEnabled = true;
            this.gMapControl1.MaxZoom = 2;
            this.gMapControl1.MinZoom = 2;
            this.gMapControl1.MouseWheelZoomEnabled = true;
            this.gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl1.Name = "gMapControl1";
            this.gMapControl1.NegativeMode = false;
            this.gMapControl1.PolygonsEnabled = true;
            this.gMapControl1.RetryLoadTile = 0;
            this.gMapControl1.RoutesEnabled = true;
            this.gMapControl1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl1.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl1.ShowTileGridLines = false;
            this.gMapControl1.Size = new System.Drawing.Size(559, 495);
            this.gMapControl1.TabIndex = 9;
            this.gMapControl1.Zoom = 0D;
            this.gMapControl1.Load += new System.EventHandler(this.gMapControl1_Load_1);
            this.gMapControl1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gMapControl1_MouseClick_1);
            // 
            // GuncellemeEkranı
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 519);
            this.Controls.Add(this.goster);
            this.Controls.Add(this.guncelle);
            this.Controls.Add(this.textBoxlong);
            this.Controls.Add(this.textBoxlat);
            this.Controls.Add(this.customername);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gMapControl1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "GuncellemeEkranı";
            this.Text = "GuncellemeEkranı";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GuncellemeEkranı_FormClosed);
            this.Load += new System.EventHandler(this.GuncellemeEkranı_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button goster;
        private System.Windows.Forms.Button guncelle;
        private System.Windows.Forms.TextBox textBoxlong;
        private System.Windows.Forms.TextBox textBoxlat;
        private System.Windows.Forms.TextBox customername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private GMap.NET.WindowsForms.GMapControl gMapControl1;
    }
}