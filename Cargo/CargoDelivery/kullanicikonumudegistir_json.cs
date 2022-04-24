using System;
using System.Collections.Generic;
using System.Text;

namespace CargoDelivery
{
    class kullanicikonumudegistir_json { 
    
        public double UserLocationLatitude;
        public double UserLocationLongitude;

        public kullanicikonumudegistir_json(double UserLocationLatitude,double UserLocationLongitude)
        {
            this.UserLocationLatitude = UserLocationLatitude;
            this.UserLocationLongitude = UserLocationLongitude;
        }
    }
}
