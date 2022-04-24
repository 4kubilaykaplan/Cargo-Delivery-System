
namespace CargoDelivery
{
    public partial class kargoguncelle_json
    {
        public string CargoID { get; set; }
        public string CustomerName { get; set; }
        public double CustomerLocationLatitude { get; set; }
        public double CustomerLocationLongitude { get; set; }
        public string DeliveryInformation { get; set; }
        public double CargoLocationLatitude { get; set; }
        public double CargoLocationLongitude { get; set; }

        public kargoguncelle_json(string cargoId, string customerName, double customerLocationLatitude, double customerLocationLongitude, string deliveryInformation, double cargoLocationLatitude, double cargoLocationLongitude)
        {
            CargoID = cargoId;
            CustomerName = customerName;
            CustomerLocationLatitude = customerLocationLatitude;
            CustomerLocationLongitude = customerLocationLongitude;
            DeliveryInformation = deliveryInformation;
            CargoLocationLatitude = cargoLocationLatitude;
            CargoLocationLongitude = cargoLocationLongitude;
        }
    }

}
