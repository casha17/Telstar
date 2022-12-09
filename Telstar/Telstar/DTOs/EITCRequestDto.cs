namespace Telstar.DTOs
{
    public class EITCRequestDto : RequestDto
    {

        public string name { get; set; }
        public int weight { get; set; }
        public string type { get; set; }
        public string timestamp { get; set; }

        public bool recommended { get; set; }
    }
}
