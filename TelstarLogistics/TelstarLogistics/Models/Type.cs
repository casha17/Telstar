namespace TelstarLogistics.Models
{
    public class Type
    {
        public static string ANIMAL_TYPE = "animal";

        public Guid id { get; set; }
        public string name { get; set; }
        public double priceModifier { get; set; }

        public List<Shipment> shipments { get; set; }
    }
}
