using System;
using System.Collections.Generic;
using System.Text;

namespace CargoDelivery
{
    class sifredegistir_json
    {
        public String yenisifre;
        public String eskisifre;
        public String username;
        public sifredegistir_json(String yenisifre,String eskisifre,String username)
        {
            this.yenisifre = yenisifre;
            this.eskisifre = eskisifre;
            this.username = username;
        }
    }
}
