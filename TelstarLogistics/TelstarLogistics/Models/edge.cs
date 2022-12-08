namespace TelstarLogistics.Models
{
    public class edge
    {
        public Guid Id { get; set; }

        public string to { get; set; }
        public string from { get; set; }
        public double cost { get; set; }
        public double timeHours { get; set; }

        public destination fromDestination { get; set; }
        public destination toDestination { get; set; }

    }
}
