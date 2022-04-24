
namespace CargoDelivery
{
    partial class TeslimatAdresEkranı
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
            this.gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.customername = new System.Windows.Forms.TextBox();
            this.textBoxlat = new System.Windows.Forms.TextBox();
            this.textBoxlong = new System.Windows.Forms.TextBox();
            this.ekle = new System.Windows.Forms.Button();
            this.goster = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // gMapControl1
            // 
            this.gMapControl1.Bearing = 0F;
            this.gMapControl1.CanDragMap = true;
            this.gMapControl1.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl1.GrayScaleMode = false;
            this.gMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl1.LevelsKeepInMemory = 5;
            this.gMapControl1.Location = new System.Drawing.Point(16, 15);
            this.gMapControl1.Margin = new System.Windows.Forms.Padding(4);
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
            this.gMapControl1.Size = new System.Drawing.Size(745, 609);
            this.gMapControl1.TabIndex = 0;
            this.gMapControl1.Zoom = 0D;
            this.gMapControl1.Load += new System.EventHandler(this.gMapControl1_Load);
            this.gMapControl1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gMapControl1_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(804, 91);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Müşteri Adı";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(804, 135);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Kargo Konumu (lat)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(804, 180);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Kargo Konumu (long)";
            // 
            // customername
            // 
            this.customername.Location = new System.Drawing.Point(989, 91);
            this.customername.Margin = new System.Windows.Forms.Padding(4);
            this.customername.Name = "customername";
            this.customername.Size = new System.Drawing.Size(227, 22);
            this.customername.TabIndex = 4;
            this.customername.TextChanged += new System.EventHandler(this.customername_TextChanged);
            // 
            // textBoxlat
            // 
            this.textBoxlat.Location = new System.Drawing.Point(989, 132);
            this.textBoxlat.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxlat.MaxLength = 16;
            this.textBoxlat.Name = "textBoxlat";
            this.textBoxlat.Size = new System.Drawing.Size(227, 22);
            this.textBoxlat.TabIndex = 5;
            this.textBoxlat.TextChanged += new System.EventHandler(this.textBoxlat_TextChanged);
            // 
            // textBoxlong
            // 
            this.textBoxlong.Location = new System.Drawing.Point(989, 171);
            this.textBoxlong.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxlong.MaxLength = 16;
            this.textBoxlong.Name = "textBoxlong";
            this.textBoxlong.Size = new System.Drawing.Size(227, 22);
            this.textBoxlong.TabIndex = 6;
            this.textBoxlong.TextChanged += new System.EventHandler(this.textBoxlong_TextChanged);
            // 
            // ekle
            // 
            this.ekle.Location = new System.Drawing.Point(933, 272);
            this.ekle.Margin = new System.Windows.Forms.Padding(4);
            this.ekle.Name = "ekle";
            this.ekle.Size = new System.Drawing.Size(184, 43);
            this.ekle.TabIndex = 7;
            this.ekle.Text = "Ekle";
            this.ekle.UseVisualStyleBackColor = true;
            this.ekle.Click += new System.EventHandler(this.ekle_Click);
            // 
            // goster
            // 
            this.goster.Location = new System.Drawing.Point(1080, 198);
            this.goster.Margin = new System.Windows.Forms.Padding(4);
            this.goster.Name = "goster";
            this.goster.Size = new System.Drawing.Size(137, 24);
            this.goster.TabIndex = 8;
            this.goster.Text = "Haritada göster";
            this.goster.UseVisualStyleBackColor = true;
            this.goster.Click += new System.EventHandler(this.goster_Click);
            // 
            // TeslimatAdresEkranı
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1260, 639);
            this.Controls.Add(this.goster);
            this.Controls.Add(this.ekle);
            this.Controls.Add(this.textBoxlong);
            this.Controls.Add(this.textBoxlat);
            this.Controls.Add(this.customername);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gMapControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TeslimatAdresEkranı";
            this.Text = "TeslimatAdresEkranı";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TeslimatAdresEkranı_FormClosed);
            this.Load += new System.EventHandler(this.TeslimatAdresEkranı_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gMapControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox customername;
        private System.Windows.Forms.TextBox textBoxlat;
        private System.Windows.Forms.TextBox textBoxlong;
        private System.Windows.Forms.Button ekle;
        private System.Windows.Forms.Button goster;
    }
}