namespace Telstar.DTOs
{
    public class EdgeRequestDTO
    {
        public string name { get; set; }
        public double length { get; set; }
        public double width { get; set; }
        public double height { get; set; }
        public double weight { get; set; }
        public string type { get; set; }
        public string timestamp { get; set; }
        public bool recommended { get; set; }
    }
}
