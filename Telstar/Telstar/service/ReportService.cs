using System.Linq.Expressions;
using Telstar.Data;

namespace Telstar.service
{
    public class ReportService : IReportService
    {

        private readonly ApplicationDbContext _dbContext;

        public ReportService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public double GetTotalPrice() {
            var all_prices = _dbContext.shipments.ToList();
            var totalProfit = 0.0;

            foreach (var shipment in all_prices)
            {
                totalProfit += shipment.totalCostInUSD - (shipment.paidToOAInUSD + shipment.paidToEICInUSD);
            }
            return totalProfit;
        }

        public int GetTotalBookings() {
            var all_bookings = _dbContext.shipments.ToList();
            return all_bookings.Count();
        }
    }
}
