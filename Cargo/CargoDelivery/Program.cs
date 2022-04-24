using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Threading;

namespace CargoDelivery
{
    static class Program
    {
        
        public static HttpClient client = new HttpClient();
        public static string url = "http://ws-env.eba-dzpji2n6.us-east-2.elasticbeanstalk.com";
        public static List<int> quee = new List<int>();
        public static void add_update_req()
        {
            lock (quee)
            {

                quee.Add(1);
            }
        }
        public static void remove_update_req()
        {
            lock (quee) 
            {

                quee.Clear();
            }
        }
        public static List<int> get_update_req()
        {
            lock (quee)
            {
                return quee;
            }
        }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
    
        static void Main()
        {

          



            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new WelcomePage());;
            Application.Run(new WelcomePage());

        }
   
    }
}
