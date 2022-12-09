namespace Telstar.DTOs
{
    public class OARequestDTO : RequestDto
    {
        public int depth { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int weight { get; set; }
        public string type { get; set; }
    }
}
