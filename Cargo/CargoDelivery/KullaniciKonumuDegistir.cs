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
    public partial class KullaniciKonumuDegistir : Form
    {
        double lat;
        double longi;

        public List<PointLatLng> points;
        public List<PointLatLng> UserLoc;

        GMapOverlay markers;
        public KullaniciKonumuDegistir()
        {
            InitializeComponent();
            points = new List<PointLatLng>();
            UserLoc = new List<PointLatLng>();
            this.l_data();
        }

        public async void l_data()
        {
            var userinfo= await KullaniciIslemleri.userinfo();
            Dictionary<string, string> sonuc = JsonConvert.DeserializeObject<Dictionary<string, string>>(userinfo);
           textBoxlat.Text = sonuc["UserLocationLatitude"].ToString().Replace(".",",");
            textBoxlong.Text = sonuc["UserLocationLongitude"].ToString().Replace(".", ",");
            PointLatLng pt = new PointLatLng(Convert.ToDouble(textBoxlat.Text.Replace(".",",")), Convert.ToDouble(textBoxlong.Text.Replace(".",",")));
            LoadMap(pt);
            AddCargoMarker(pt);
        }

        private void gMapControl1_Load_1(object sender, EventArgs e)
            {
                mapSettings(gMapControl1);

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
            markers = new GMapOverlay("markers");
            var marker = new GMarkerGoogle(pointToAdd, markerType);
            markers.Markers.Add(marker);
            gMapControl1.Overlays.Add(markers);
            RefreshMap(gMapControl1);




        }

        private void gMapControl1_MouseClick_1(object sender, MouseEventArgs e)
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

        private async void guncelle_Click(object sender, EventArgs e)
        {
            if ( textBoxlat.TextLength != 0 && textBoxlong.TextLength != 0)
            {
                var sonuc = await KullaniciIslemleri.kullanicikonumudegistir_json(Convert.ToDouble(textBoxlat.Text), Convert.ToDouble(textBoxlong.Text));
                Dictionary<string, string> aa = JsonConvert.DeserializeObject<Dictionary<string, string>>(sonuc);
                if (aa["status"] == "success")
                {
                    MessageBox.Show("Kullanıcı Konumu Güncellendi");
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

        private void KullaniciKonumuDegistir_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            TeslimatDurumEkranı t = new TeslimatDurumEkranı();
            t.Show();
        }
    }
}
