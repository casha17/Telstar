using Microsoft.Extensions.DependencyInjection;
using Telstar.service;
using Telstar.Models;
using Telstar.Data;
using Microsoft.EntityFrameworkCore;

namespace Telstar.test
{
    [TestClass]
    public class EnsureCompaniesAreAllowedToBookShipping
    {

        private IshipmentService shipmentService { get; set; }
        [TestMethod]
        public void EnsureCompaniesAreAllowedToBookShipping_ShouldPass()
        {
            //Arrange
            var services = new ServiceCollection();
            services.AddTransient<IshipmentService, ShipmentSevice>();
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(@"Data Source=dbs-tl-dk1.database.windows.net;Initial Catalog=db-tl-dk1;User ID=admin-tl-dk1;Password=telStarRox16;"));

            var serviceProvider = services.BuildServiceProvider();

            shipmentService = serviceProvider.GetService<IshipmentService>();

            var shipment = new Shipment()
            {
                from = "Tripoli",
                heightInCm = 2.2,
                Id = Guid.NewGuid(),
                lengthInCm = 2.2,
                paidToEICInUSD = 10,
                paidToOAInUSD = 10,
                timestamp = DateTime.Now,
                to = "Tanger",
                totalCostInUSD = 10,
                type = new ShipmentType
                {
                    id = Guid.NewGuid(),
                    name = "Animal",
                    priceModifier = 2,
                },
                weightInKg = 10,
                widthInCm = 10

            };

            var list = new List<Company>()
            {
                Company.EITC
            };

            // Act
            var s = shipmentService.findAllowedExternalCompanies(shipment);
            

            // Assert
            CollectionAssert.AreEquivalent(list, s);
            

        }
    }
}