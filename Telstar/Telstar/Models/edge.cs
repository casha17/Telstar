namespace Telstar.Models
{
    public class Edge
    {
        public Guid Id { get; set; }

        public string To { get; set; }
        public string From { get; set; }
        public double Cost { get; set; }
        public double TimeHours { get; set; }

   

    }
}
