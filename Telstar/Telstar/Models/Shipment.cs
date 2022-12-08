namespace Telstar.Models
{
    public class Shipment
    {
        public Guid Id { get; set; }
        public string weightInKg{ get; set; }
        public string lengthInCm { get; set; }
        public string widthInCm { get; set; }
        public string heightInCm { get; set; }
        public DateTime timestamp { get; set; }
        public double totalCostInUSD { get; set; }
        public double paidToOAInUSD { get; set; }
        public double paidToEICInUSD { get; set; }
        public ShipmentType type { get; set; }

        public string from { get; set; }

        public string to { get; set; }
    }
}
