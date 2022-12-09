namespace Telstar.Models
{
    public class ShipmentType
    {
        public static string ANIMAL_TYPE = "Live Animals";
        public static string FRAGILE_TYPE = "Cautious Parcels";
        public static string REFRIGERATED_TYPE = "Refrigerated Goods";
        public static string REGULAR_TYPE = "Regular";
        public static string WEAPONS_TYPE = "Weapons";

        public Guid id { get; set; }
        public string name { get; set; }
        public double priceModifier { get; set; }

        public List<Shipment> shipments { get; set; }
    }
}
