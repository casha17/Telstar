namespace TelstarLogistics.Models
{
    public class Shipment
    {
        public Guid Id { get; set; }
        public double weightInKg{ get; set; }
        public double lengthInCm { get; set; }
        public double widthInCm { get; set; }
        public double heightInCm { get; set; }
        public string timestamp { get; set; }
        public double totalCostInUSD { get; set; }
        public double paidToOAInUSD { get; set; }
        public double paidToEICInUSD { get; set; }
    }
}
