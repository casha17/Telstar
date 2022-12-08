using Microsoft.EntityFrameworkCore.Infrastructure;
using Telstar.Data;
using Telstar.Models;

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
        /*
        public bool isSuitableForTelstar (Shipment shipment, float transportDurationInHours)
        {
            return shipment.weightInKg <= 40 && (shipment.type.name.ToLower() == Telstar.Models.Type.ANIMAL_TYPE.ToLower() ? transportDurationInHours <= 30 : true);
        }*/

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

        public double calculateAdjustedPrice(Shipment shipment, Company company, double totalPrice)
        {
            string typeName = shipment.type.name.ToLower();
            if (typeName == Telstar.Models.ShipmentType.ANIMAL_TYPE)
            {
                totalPrice *= 1.5;
            } else if (typeName == Telstar.Models.ShipmentType.FRAGILE_TYPE)
            {
                totalPrice *= 1.75;
            } else if (typeName == Telstar.Models.ShipmentType.REFRIGERATED_TYPE)
            {
                totalPrice *= 1.1;
            }
            if (company == Company.OA)
            {
                totalPrice *= 1.05;
            }
            return totalPrice;
        }

        private bool isSuitableForEITC(Shipment shipment)
        {
            return true; //shipment.weightInKg <= 100;
        }

        private bool isSuitableForOA(Shipment shipment)
        {
            return true;// shipment.weightInKg <= 20 && shipment.lengthInCm <= 200 && shipment.type.name.ToLower() != Telstar.Models.ShipmentType.ANIMAL_TYPE.ToLower() ;
        }
    }
}
