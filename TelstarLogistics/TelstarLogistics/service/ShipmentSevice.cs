using TelstarLogistics.Data;
using TelstarLogistics.Models;

namespace TelstarLogistics.service
{
    public class ShipmentSevice : IshipmentService
    {
        private readonly ApplicationDbContext _dbContext;
        public ShipmentSevice(ApplicationDbContext dbContext) {
            _dbContext= dbContext;
        }
        public Shipment CreateShipment(Shipment shipment)
        {
            throw new NotImplementedException();
        }

        public List<Destination> GetDestination()
        {
            return _dbContext.destinations.ToList();
        }

        public List<string> GetRutes()
        {
            throw new NotImplementedException();
        }
    }
}
