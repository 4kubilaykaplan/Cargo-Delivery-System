using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace CargoDelivery
{
    class KullaniciIslemleri
    {
        public static  async Task<String> girisyap(String Username, String Password)
        {
             var logininfo = new girisyap_json(Username, Password);
            Console.WriteLine("--");
               var json = JsonConvert.SerializeObject(logininfo);
               var data = new StringContent(json, Encoding.UTF8, "application/json");


            var url = Program.url + "/girisyap";

               var response = await Program.client.PostAsync(url, data);
             
               string result = response.Content.ReadAsStringAsync().Result;
            return result;
          
        }

        public static async Task<String> cikisyap()
        {
            var content = await Program.client.GetStringAsync(Program.url+"/logout");

            return content;

        }
        public static async Task<String> sifredegistir(String yenisifre,String eskisifre, String username )
        {
            var sd = new sifredegistir_json(yenisifre,eskisifre,username);
            Console.WriteLine("--");
            var json = JsonConvert.SerializeObject(sd);
            var data = new StringContent(json, Encoding.UTF8, "application/json");



            var url = Program.url + "/sifredegistir";
            var response = await Program.client.PostAsync(url, data);

            string result = response.Content.ReadAsStringAsync().Result;
            return result;

        }
        public static async Task<String> kayitol(String username, String email, String password)
        {
            var reg = new kayitol_json(username, email, password);
            Console.WriteLine("--");
            var json = JsonConvert.SerializeObject(reg);
            var data = new StringContent(json, Encoding.UTF8, "application/json");



            var url = Program.url + "/kayitol";
            var response = await Program.client.PostAsync(url, data);

            string result = response.Content.ReadAsStringAsync().Result;
            return result;

        }
        public static async Task<String> kullanicikonumudegistir_json(double lat, double longi )
        {
            var reg = new kullanicikonumudegistir_json(lat, longi );
            var json = JsonConvert.SerializeObject(reg);
            var data = new StringContent(json, Encoding.UTF8, "application/json");



            var url = Program.url + "/kullanicikonumudegistir";
            var response = await Program.client.PostAsync(url, data);

            string result = response.Content.ReadAsStringAsync().Result;
            return result;

        }
        public static async Task<String> logincheck()
        {
            var content = await Program.client.GetStringAsync(Program.url + "/logincheck");

            return content;

        }
        public static async Task<String> userid()
        {
            var content = await Program.client.GetStringAsync(Program.url + "/userid");

            return content;

        }
        public static async Task<String> userinfo()
        {
            var content = await Program.client.GetStringAsync(Program.url + "/userinfo");

            return content;

        }
    }
}
