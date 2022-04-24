using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.MapProviders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using GMap.NET.WindowsForms.Markers;
using Newtonsoft.Json;

namespace CargoDelivery
{
    public partial class GUI2 : Form
    {
        public List<PointLatLng> points;
        public PointLatLng UserLoc;
        GMarkerGoogle userMarker;
        GMapOverlay markers;
        public GUI2()
        {
            CheckForIllegalCrossThreadCalls = false;

            InitializeComponent();

            Thread t = new Thread(check_quee);
            t.Start();
            basla();
        }
        
        void check_quee()
        {
            while (true)
            {
                if(Program.get_update_req().Count > 0)
                {
                    this.basla();
                    Program.remove_update_req();
                }
            }

        }
        public void mapSettings(GMapControl map)
        {
            GMapProviders.GoogleMap.ApiKey = "AIzaSyCxI3rOISy1lEfrQXXLSpcWCcGH81gDp3U";
            map.ShowCenter = false;
            map.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            map.MinZoom = 0; map.MaxZoom = 18; map.Zoom = 12;
            double lat = 40.766666;
            double longi = 29.916668;
            PointLatLng point = new PointLatLng(lat, longi);

            map.Position = point;
            map.DragButton = MouseButtons.Left;
        }
        private void gMapControl1_Load(object sender, EventArgs e)
        {
            mapSettings(gMapControl1);
        }
        public double uzaklikHesapla(PointLatLng pt1, PointLatLng pt2)
        {
            GMapOverlay routes = new GMapOverlay("routes");
            List<PointLatLng> points = new List<PointLatLng>();
            points.Add(pt1);
            points.Add(pt2);
        
            GMapRoute route = new GMapRoute(points, ".");
            route.Stroke = new Pen(Color.Red, 3);
            routes.Routes.Add(route);
            return route.Distance;
        }
     
     
            private void AddCargoMarker(PointLatLng pointToAdd, GMarkerGoogleType markerType = GMarkerGoogleType.blue)
        {

          /*  try
            {
                gMapControl1.Overlays.Remove(markers);
                points.Remove(points[0]);
            }
            catch (Exception)
            {
            }*/

            
            markers = new GMapOverlay("markers");
            var marker = new GMarkerGoogle(pointToAdd, markerType);
            markers.Markers.Add(marker);
            gMapControl1.Overlays.Add(markers);




        }
        public void AddCargoRoute(PointLatLng pt1, PointLatLng pt2)
        {
            /*GMapOverlay routes = new GMapOverlay("routes");
            List<PointLatLng> points = new List<PointLatLng>();
            points.Add(pt1);
            points.Add(pt2);
          
            GMapRoute route = new GMapRoute(points, " ");
            route.Stroke = new Pen(Color.Red, 3);
            routes.Routes.Add(route);
            gMapControl1.Overlays.Add(routes);*/

            var rota = GoogleMapProvider.Instance.GetRoute(pt1, pt2, false, false, 12);
            var r = new GMapRoute(rota.Points, "mmmmmm ");
             r.Stroke = new Pen(Color.Blue, 1);
           
            
            var routes = new GMapOverlay("routes");
            routes.Routes.Add(r);
            gMapControl1.Overlays.Add(routes);
           
        }
        public void RefreshMap(GMapControl map)
        {
            map.Zoom--;
            map.Zoom++;
        }

        public async void basla()
        {
            gMapControl1.Overlays.Clear();
            var userinfo = await KullaniciIslemleri.userinfo();
            Dictionary<string, string> sonucc = JsonConvert.DeserializeObject<Dictionary<string, string>>(userinfo);
       

            points = new List<PointLatLng>();
            UserLoc = new PointLatLng(Convert.ToDouble(sonucc["UserLocationLatitude"].Replace(".",",")), Convert.ToDouble(sonucc["UserLocationLongitude"].Replace(".", ",")));
            points.Add(UserLoc);
            var aa = await KargoIslemleri.kargolistele();
            List<Dictionary<string, string>> sonuc = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(aa);
            foreach (Dictionary<string, string> kv in sonuc)
            {
                if (kv["DeliveryInformation"] == "0")
                {
            
                    PointLatLng pt = new PointLatLng(Convert.ToDouble(kv["CargoLocationLatitude"].Replace(".", ",")), Convert.ToDouble(kv["CargoLocationLongitude"].Replace(".", ",")));
                    points.Add(pt);
                    AddCargoMarker(pt, GMarkerGoogleType.blue);
                    //gMapControl1.Position = pt;
             

                }
            }
            gMapControl1.Zoom--;
            gMapControl1.Zoom++;
            /* double[,] cc =
                    //0,1,2,3
                    {{0,3,42,7},      //0
                        {3,0,3,11},         //1
                        {42,3,0,42},         //2
                        {7,11,42,0}         //3
                         };*/
            double[,] cc= new double[points.Count,points.Count];
            for (int i = 0; i < points.Count; i++)
            {
                for (int j = 0; j < points.Count; j++)
                {
                    double u = uzaklikHesapla(points[i], points[j]);
                    cc[i,j] = u;
                }
            }
            PrimAlg G = new PrimAlg(cc);
            var res=G.Prim();
            for (int i = 0; i < res.GetLength(0); i++)
            {
                //Console.WriteLine(res[i, 0] + " : " + res[i, 1]);
                AddCargoRoute(points[res[i, 0]],points[res[i, 1]]);
            }
            //PointLatLng tt = new PointLatLng(40.739746, 29.955247);
            //AddCargoRoute(UserLoc, tt);
            AddCargoMarker(UserLoc, GMarkerGoogleType.red);
            //gMapControl1.Position = UserLoc;
            RefreshMap(gMapControl1);


            /*var d=uzaklikHesapla(new PointLatLng(43.122, 42.111), new PointLatLng(43.122, 42.111));
            MessageBox.Show(Convert.ToString(d));*/

        }
    }
}
