using TelstarLogistics.Models;

namespace TelstarLogistics.service
{
    public interface IshipmentService
    {
        public Shipment CreateShipment(Shipment shipment);

        public List<destination> GetDestination();

        public List<string> GetRutes();
    }
}
