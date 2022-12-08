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

        public bool isSuitableForTelstar (Shipment shipment, float transportDurationInHours)
        {
            return shipment.weightInKg <= 40 && (shipment.type.name.ToLower() == Models.Type.ANIMAL_TYPE.ToLower() ? transportDurationInHours <= 30 : true);
        }

        public Company[] findAllowedExternalCompanies(Shipment shipment)
        {
            Company[] result = { };
            if (isSuitableForEITC(shipment))
            {
                result.Append(Company.EITC);
            }
            if (isSuitableForOA(shipment))
            {
                result.Append(Company.OA);
            }
            return result;
        }

        private bool isSuitableForEITC(Shipment shipment)
        {
            return shipment.weightInKg <= 100;
        }

        private bool isSuitableForOA(Shipment shipment)
        {
            return shipment.weightInKg <= 20 && shipment.lengthInCm <= 200 && shipment.type.name.ToLower() != Models.Type.ANIMAL_TYPE.ToLower() ;
        }
    }
}
