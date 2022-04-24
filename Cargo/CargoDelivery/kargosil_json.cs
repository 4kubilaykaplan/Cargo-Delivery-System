using System;
using System.Collections.Generic;
using System.Text;

namespace CargoDelivery
{
    class kargosil_json
    {
        public string CargoID { get; set; }

        public kargosil_json(string cargoId)
        {
            CargoID = cargoId;
        }
    }
}
