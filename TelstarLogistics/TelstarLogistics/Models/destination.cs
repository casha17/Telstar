namespace TelstarLogistics.Models
{
    public class destination
    {
        public string city { get; set; }

        public Guid id { get; set; }

        public List<edge> fromEdges { get; set; }
        public List<edge> toEdges { get; set; }
    }
}
