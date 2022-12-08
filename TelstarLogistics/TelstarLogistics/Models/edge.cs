namespace TelstarLogistics.Models
{
    public class Edge
    {
        public Guid Id { get; set; }

        public string To { get; set; }
        public string From { get; set; }
        public double Cost { get; set; }
        public double TimeHours { get; set; }

        public Destination FromDestination { get; set; }
        public Destination ToDestination { get; set; }

    }
}
