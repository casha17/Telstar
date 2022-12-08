namespace Telstar.Models
{
    public class Destination
    {
        public string City { get; set; }

        public Guid Id { get; set; }

        public List<Edge> FromEdges { get; set; }
        public List<Edge> ToEdges { get; set; }
    }
}
