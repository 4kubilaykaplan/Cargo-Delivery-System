using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System.Text;
using Newtonsoft.Json;

namespace CargoDelivery
{
    public partial class TeslimatAdresEkranı : Form
    {
        double lat;
        double longi;
        string musteriadi;
        public List<PointLatLng> points;
        public List<PointLatLng> UserLoc;
        GMarkerGoogle userMarker;
        GMapOverlay  markers;

        public TeslimatAdresEkranı()
        {
            InitializeComponent();
            points = new List<PointLatLng>();
            UserLoc = new List<PointLatLng>();
        }


        private void TeslimatAdresEkranı_Load(object sender, EventArgs e)
        {

        }

        private async void ekle_Click(object sender, EventArgs e)
        {
           

            if (customername.TextLength != 0 && textBoxlat.TextLength != 0 && textBoxlong.TextLength != 0)
            {
                var sonuc =await KargoIslemleri.kargoekle(customername.Text, Convert.ToDouble(textBoxlat.Text),Convert.ToDouble(textBoxlong.Text), "0", Convert.ToDouble(textBoxlat.Text), Convert.ToDouble(textBoxlong.Text));
                Dictionary<string, string> aa = JsonConvert.DeserializeObject<Dictionary<string, string>>(sonuc);
                if (aa["status"] == "success")
                {
                    MessageBox.Show("Kargo Eklendi");
                    Program.add_update_req();
                    this.Hide();
                    TeslimatDurumEkranı td = new TeslimatDurumEkranı();
                    td.Show();
                }
                else
                {
                    MessageBox.Show("Hata Oluştu");
                }

            }
            else
            {
                MessageBox.Show("Lütfen boş alan bırakmayın");
            }
         
        }
        private void LoadMap(PointLatLng point)
        {
            gMapControl1.Position = point;

        }
        private void AddCargoMarker(PointLatLng pointToAdd, GMarkerGoogleType markerType = GMarkerGoogleType.blue)
        {
            
            try
            {
                gMapControl1.Overlays.Remove(markers);
                points.Remove(points[0]);
            }
            catch (Exception)
            {
            }
            
            points.Add(pointToAdd);
            //points.ForEach(a => Console.WriteLine("En son Hali Yazdıracak" + a)); Console.WriteLine("-----------");
            markers= new GMapOverlay("markers");
            var marker = new GMarkerGoogle(pointToAdd, markerType);
            markers.Markers.Add(marker);
            gMapControl1.Overlays.Add(markers);
            RefreshMap(gMapControl1);


        

        }
        public void mapSettings(GMapControl map)
        {
            GMapProviders.GoogleMap.ApiKey = "AIzaSyCxI3rOISy1lEfrQXXLSpcWCcGH81gDp3U";
            map.ShowCenter = false;
            map.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            map.MinZoom = 0; map.MaxZoom = 18; map.Zoom = 12;
            double lat = 40.766666;
            double longi = 29.916668;
            PointLatLng point = new PointLatLng(lat, longi);

            map.Position = point;
            map.DragButton = MouseButtons.Left;
        }
        public void RefreshMap(GMapControl map)
        {
            map.Zoom--;
            map.Zoom++;
        }
        private void customername_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxlat_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxlong_TextChanged(object sender, EventArgs e)
        {

        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {
            mapSettings(gMapControl1);
        }

        private void gMapControl1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var point = gMapControl1.FromLocalToLatLng(e.X, e.Y);
                textBoxlat.Text = point.Lat.ToString();
                textBoxlong.Text = point.Lng.ToString();

                LoadMap(point);
                AddCargoMarker(point);
            }
        }

        private void goster_Click(object sender, EventArgs e)
        {
            lat = Convert.ToDouble(textBoxlat.Text); //37,84501
            longi = Convert.ToDouble(textBoxlong.Text); // 27,83963

            PointLatLng point = new PointLatLng(lat, longi);


            LoadMap(point);
            AddCargoMarker(point);
        }

        private void TeslimatAdresEkranı_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            TeslimatDurumEkranı td = new TeslimatDurumEkranı();
            td.Show();
        }
    }
    }

