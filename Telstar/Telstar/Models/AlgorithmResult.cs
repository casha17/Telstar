namespace Telstar.Models
{
    public class AlgorithmResult
    {
        public double Cheapest { get; set; }
        public double Fastest { get; set; }

        public Shipment shipment { get; set; }

        public bool fastest { get; set; }

        public bool cheapest { get; set; }
    }
}
