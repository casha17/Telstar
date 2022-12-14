using Telstar.Models;

namespace Telstar.service
{
    public interface IshipmentService
    {
        public Shipment CreateShipment(Shipment shipment);

        public List<Destination> GetDestination();

        public List<string> GetRutes();

        //public bool isSuitableForTelstar(Shipment shipment, float transportDurationInHours);
        public List<Company> findAllowedExternalCompanies(Shipment shipment);

        public double calculateAdjustedPrice(Shipment shipment, Company company, double totalPrice);
    }
}
