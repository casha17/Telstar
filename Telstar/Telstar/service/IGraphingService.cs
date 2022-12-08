using Dijkstra.NET.ShortestPath;
using Telstar.Models;

namespace Telstar.service
{
    public interface IGraphingService
    {
        public ShortestPathResult getQuickestPath(Shipment shipment, string from, string to);
        public ShortestPathResult getCheapestPath(Shipment shipment, string from, string to);
    }
}
