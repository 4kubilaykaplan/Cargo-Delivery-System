using System;
using System.Collections.Generic;
using System.Text;

namespace   CargoDelivery
{
    class customerdetay_json
    {
        public String CustomerID { get; set; }

        public customerdetay_json(String customerId)
        {
            CustomerID = customerId;
        }
    }
}
