using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CargoDelivery
{
    class KargoIslemleri
    {
 
        public static async Task<String> kargoekle(String CustomerName, double CustomerLocationLatitude,double CustomerLocationLongitude,String DeliveryInformation,double CargoLocationLatitude,double CargoLocationLongitude)
        {
            var logininfo = new kargoekle_json( CustomerName,  CustomerLocationLatitude,  CustomerLocationLongitude,  DeliveryInformation,  CargoLocationLatitude,  CargoLocationLongitude);
           
            var json = JsonConvert.SerializeObject(logininfo);
            var data = new StringContent(json, Encoding.UTF8, "application/json");


            var url = Program.url + "/kargoekle";

            var response = await Program.client.PostAsync(url, data);

            string result = response.Content.ReadAsStringAsync().Result;
            return result;

        }
        public static async Task<String> kargoguncelle(String CargoID, String CustomerName, double CustomerLocationLatitude, double CustomerLocationLongitude, String DeliveryInformation, double CargoLocationLatitude, double CargoLocationLongitude)
        {
            var logininfo = new kargoguncelle_json(CargoID,CustomerName, CustomerLocationLatitude, CustomerLocationLongitude, DeliveryInformation, CargoLocationLatitude, CargoLocationLongitude);

            var json = JsonConvert.SerializeObject(logininfo);
            var data = new StringContent(json, Encoding.UTF8, "application/json");


            var url = Program.url + "/kargoguncelle";

            var response = await Program.client.PostAsync(url, data);

            string result = response.Content.ReadAsStringAsync().Result;
            return result;

        }
        public static async Task<String> customerdetay(String CustomerID)
        {
            var logininfo = new customerdetay_json(CustomerID);

            var json = JsonConvert.SerializeObject(logininfo);
            var data = new StringContent(json, Encoding.UTF8, "application/json");


            var url = Program.url + "/customerdetay";

            var response = await Program.client.PostAsync(url, data);

            string result = response.Content.ReadAsStringAsync().Result;
            return result;

        }
        public static async Task<String> teslimdurumudegistir(String CargoID,String DeliveryInfortmation)
        {
            var logininfo = new teslimdurumudegistir_json(CargoID,DeliveryInfortmation);

            var json = JsonConvert.SerializeObject(logininfo);
            var data = new StringContent(json, Encoding.UTF8, "application/json");


            var url = Program.url + "/teslimdurumudegistir";

            var response = await Program.client.PostAsync(url, data);

            string result = response.Content.ReadAsStringAsync().Result;
            return result;

        }
        public static async Task<String> kargolistele()
        {
            var content = await Program.client.GetStringAsync(Program.url + "/kargolistele");

            return content;

        }
        public static async Task<String> kargosil(String CargoID)
        {
            var logininfo = new kargosil_json(CargoID);

            var json = JsonConvert.SerializeObject(logininfo);
            var data = new StringContent(json, Encoding.UTF8, "application/json");


            var url = Program.url + "/kargosil";

            var response = await Program.client.PostAsync(url, data);

            string result = response.Content.ReadAsStringAsync().Result;
            return result;

        }
    }

}
