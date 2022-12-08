namespace Telstar.Models
{
    public class Type
    {
        public static string ANIMAL_TYPE = "animal";
        public static string FRAGILE_TYPE = "fragile";
        public static string REFRIGERATED_TYPE = "refrigerated";

        public Guid id { get; set; }
        public string name { get; set; }
        public double priceModifier { get; set; }

        public List<Shipment> shipments { get; set; }
    }
}
