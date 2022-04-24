using System;
using System.Collections.Generic;
using System.Text;

namespace CargoDelivery
{
    class teslimdurumudegistir_json
    {
        public string CargoID { get; set; }
        public string DeliveryInformation { get; set; }

        public teslimdurumudegistir_json(string cargoId, string deliveryInformation)
        {
            CargoID = cargoId;
            DeliveryInformation = deliveryInformation;
        }
    }
}
