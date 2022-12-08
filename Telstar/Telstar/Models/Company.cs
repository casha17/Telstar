namespace Telstar.Models
{
    public class Company
    {
        private static Uri EITC_URI = new UriBuilder("http://wa-eit-dk1.azurewebsites.net").Uri;
        private static Uri OA_URI = new UriBuilder("https://wa-oa-dk1.azurewebsites.net/external/getconnections").Uri;
        public static Company EITC = new Company("EITC", EITC_URI);
        public static Company OA = new Company("EITC", OA_URI);

        public string name { get; set; }
        public Uri uri;

        public Company(string name, Uri uri)
        {
            this.name = name;
            this.uri = uri;
        }
    }
}
