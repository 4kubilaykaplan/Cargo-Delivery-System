using System;
using System.Collections.Generic;
using System.Text;

namespace CargoDelivery
{
    class kargoekle_json
    {
        public String CustomerName;
        public double CustomerLocationLatitude;
        public double CustomerLocationLongitude;
        public String DeliveryInformation;
        public double CargoLocationLatitude;
        public double CargoLocationLongitude;
        public kargoekle_json(String CustomerName, double CustomerLocationLatitude, double CustomerLocationLongitude, String DeliveryInformation, double CargoLocationLatitude, double CargoLocationLongitude)
        {
        this.CustomerName= CustomerName;
        this.CustomerLocationLatitude= CustomerLocationLatitude;
       this.CustomerLocationLongitude = CustomerLocationLongitude;
        this.DeliveryInformation= DeliveryInformation;
        this.CargoLocationLatitude= CargoLocationLatitude;
        this.CargoLocationLongitude= CargoLocationLongitude;
    }
    }
}
